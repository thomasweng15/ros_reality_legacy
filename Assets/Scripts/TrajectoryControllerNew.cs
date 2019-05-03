using UnityEngine;
using System; //This allows the IComparable Interface
using System.Collections.Generic;

//this is our modification of the original tragectory controller, b ut with the end effector snapping directyly to the controller on squeezing siude grips
public class TrajectoryControllerNew : MonoBehaviour {

    public string arm;
    private string grip_label;
    private string trigger_label;

    public GameObject targetModel;
    Transform tf;
    private WebsocketClient wsc;
    TFListener TFListener;
    float scale;
    Vector3 lastControllerPosition;
    Vector3 lastArmPosition;
    Quaternion lastControllerRotation;
    Quaternion lastArmRotation;
    Transform lastArmTF;
    Transform targetTransform;
    string message;

    //the list of commands for the websocket
    List<String> ghostCommands;

    //nonodominant and dominant control objects need them for playPressed and drawPressed
    GameObject nDom;
    GameObject dom;

    // Use this for initialization
    void Start() {
        nDom = GameObject.Find("Controller (left)");
        dom = GameObject.Find("Controller (right)");

        ghostCommands = new List<string>();
        GameObject wso = GameObject.FindWithTag("WebsocketTag");
        wsc = wso.GetComponent<WebsocketClient>();

        wsc.Advertise("ein/" + arm + "/forth_commands", "std_msgs/String");
        TFListener = GameObject.Find("TFListener").GetComponent<TFListener>();
        tf = GetComponent<Transform>();

        //last positions/rotation of the controller (calculate relative displacement of controller at each update)
        lastControllerPosition = tf.position;
        lastControllerRotation = tf.rotation;
        targetTransform = targetModel.GetComponent<Transform>();
        Invoke("FindArm", 2f); //update position of lastArm position and rotation
        InvokeRepeating("sendMessage", 1.2f, .1f); //send message to move arm by displacement of current controller position/rotation with previous position/rotation

        if (arm == "right") {
            grip_label = "Right Grip";
            trigger_label = "Right Trigger";
        }
        else {
            Debug.LogError("arm variable is not set correctly");
        }
    }

    void FindArm() { //update the lastArm with the current position/rotation of the controller
        lastArmTF = GameObject.Find(arm + "_electric_gripper_basePivot").GetComponent<Transform>();
        lastArmPosition = lastArmTF.position;
        lastArmRotation = lastArmTF.rotation;
        targetTransform.position = lastArmPosition;
        targetTransform.rotation = lastArmRotation;
    }

    void sendMessage() { //send an ein message to arm
        if(nDom.GetComponent<NondominantControls>().playPressed && ghostCommands.Count > 0){
            string ghostMessage = ghostCommands[0];
            ghostCommands.RemoveAt(0);
            wsc.SendEinMessage(ghostMessage, arm);
            print("SENDING POSITION TO ROBOT" + ghostMessage);
        } else if (ghostCommands.Count == 0){
            nDom.GetComponent<NondominantControls>().playPressed = false;
			// print("PLAY SET TO NOT PRESSED");
        }
    }

    void Update() {
        scale = TFListener.scale;

        Vector3 deltaPos = tf.position - lastControllerPosition; //displacement of current controller position to old controller position
        lastControllerPosition = tf.position;

        Quaternion deltaRot = tf.rotation * Quaternion.Inverse(lastControllerRotation); //delta of current controller rotation to old controller rotation
        lastControllerRotation = tf.rotation;

        //message to be sent over ROs network
        message = "";

        //Allows movement control with controllers if menu is disabled //used to be deadman enabled         
        if (dom.GetComponent<DominantControls>().drawPressed) {

            lastArmPosition = lastArmPosition + deltaPos; //new arm position
            lastArmRotation = deltaRot * lastArmRotation; //new arm rotation

            if ((Vector3.Distance(new Vector3(0f, 0f, 0f), lastArmPosition)) < 1.5) { //make sure that the target stays inside a 1.5 meter sphere around the robot
                // targetTransform.position = lastArmPosition + 0.09f * lastArmTF.up;
                targetTransform.position = lastArmPosition;
                // Vector3 customDisplacement = new Vector3(0.0f, 0.0f, 0.0f);
                // targetTransform.position = tf.position + customDisplacement;
            }
            // targetTransform.rotation = tf.rotation;
            targetTransform.rotation = lastArmRotation;

            Vector3 outPos = UnityToRosPositionAxisConversion(lastArmPosition) / scale;
            Quaternion outQuat = UnityToRosRotationAxisConversion(lastArmRotation);

            message = outPos.x + " " + outPos.y + " " + outPos.z + " " + outQuat.x + " " + outQuat.y + " " + outQuat.z + " " + outQuat.w + " moveToEEPose";
            if (Input.GetAxis(trigger_label) > 0.5f) {
                message += " closeGripper ";
            }
            else {
                message += " openGripper ";
            }

            if(Time.frameCount % 6 == 0){
                ghostCommands.Add(message);
                Debug.Log(message);
            }

        }
        //Debug.Log(lastArmPosition);

        // print("PRINTING LIST COUNT: " + ghostCommands.Count);
    } 

    Vector3 UnityToRosPositionAxisConversion(Vector3 rosIn) {
        return new Vector3(-rosIn.x, -rosIn.z, rosIn.y);
    }

    Quaternion UnityToRosRotationAxisConversion(Quaternion qIn) {
        // Quaternion temp = (new Quaternion(qIn.x, qIn.z, -qIn.y, qIn.w)) * (new Quaternion(0, 1, 0, 0));
        // return temp;

        return new Quaternion(qIn.x, qIn.z, -qIn.y, qIn.w);

        // ROS to Unity
        // x y z w
        // x -z y w
        // return new Quaternion (rosIn.x, -rosIn.z, rosIn.y, rosIn.w);
    }

}

