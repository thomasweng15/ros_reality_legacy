using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyItself : MonoBehaviour {

	 // string of which arm to control. Valid values are "left" and "right"
    public string arm;
    private string grip_label;
    private string trigger_label;
	 TFListener TFListener;
    //scale represents how resized the virtual robot is
    float scale;
	public Transform prefab;
	public List<String> ghostCommands = new List<String>();
    
	void Start()
    {
		if (arm == "left") {
            grip_label = "Left Grip";
            trigger_label = "Left Trigger";
        }
        else if (arm == "right") {
            grip_label = "Right Grip";
            trigger_label = "Right Trigger";
            Debug.Log("right grip");
        }
        else
            Debug.LogError("arm variable is not set correctly");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
	internal void drawGhost(){
        Instantiate(prefab, this.transform.position, this.transform.rotation);
		Transform currentTransform = GetComponent<Transform>();
		addCommand(currentTransform);
	}

	private void addCommand(Transform ghost){
		 scale = TFListener.scale;

        //Convert the Unity position of the hand controller to a ROS position (scaled)
        Vector3 outPos = UnityToRosPositionAxisConversion(GetComponent<Transform>().position) / scale;
        //Convert the Unity rotation of the hand controller to a ROS rotation (scaled, quaternions)
        Quaternion outQuat = UnityToRosRotationAxisConversion(GetComponent<Transform>().rotation);
        //construct the Ein message to be published
        string message = "";
        //Allows movement control with controllers if menu is disabled

        //if deadman switch held in, move to new pose
        if (Input.GetAxis(grip_label) > 0.5f) {
            //construct message to move to new pose for the robot end effector 
            message = outPos.x + " " + outPos.y + " " + outPos.z + " " +
            outQuat.x + " " + outQuat.y + " " + outQuat.z + " " + outQuat.w + " moveToEEPose";
            //if touchpad is pressed (Crane game), incrementally move in new direction
        }

        //If trigger pressed, open the gripper. Else, close gripper
        if (Input.GetAxis(trigger_label) > 0.5f) {
            message += " openGripper ";
        }
        else {
            message += " closeGripper ";
        }
	}

	//Convert 3D Unity position to ROS position 
    Vector3 UnityToRosPositionAxisConversion(Vector3 rosIn) {
        return new Vector3(-rosIn.x, -rosIn.z, rosIn.y);
    }

    //Convert 4D Unity quaternion to ROS quaternion
    Quaternion UnityToRosRotationAxisConversion(Quaternion qIn) {

        Quaternion temp = (new Quaternion(qIn.x, qIn.z, -qIn.y, qIn.w)) * (new Quaternion(0, 1, 0, 0));
        return temp;

        //return new Quaternion(-qIn.z, qIn.x, -qIn.w, -qIn.y);
        //return new Quaternion(-qIn.z, qIn.w, -qIn.x, -qIn.y);
        //return new Quaternion(-qIn.z, qIn.w, -qIn.x, -qIn.y);
        //return new Quaternion(-qIn.z, qIn.x, qIn.w, qIn.y);
    }
}
