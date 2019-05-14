using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominantControls : MonoBehaviour {

	/* The following three all refer to the vive controller, and unfortunately must all be present to refer to control inputs */
	private SteamVR_TrackedObject objTracked;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;

	private GameObject electricFingers; // this is the name we gave the ghost end effector...

	internal bool drawPressed; // drawPressed is 'internal' in order for other scripts to reference it (but the unity GUI doesn't have access)

	void Start () {
		objTracked = GetComponent<SteamVR_TrackedObject>();
		controller = GetComponent<SteamVR_TrackedController>();
		electricFingers = GameObject.FindWithTag("EndEffector"); //you'll notice that the ghost end effector obj in the GUI is tagged with this 

		drawPressed = false;
	}
	void Update () {
		device = SteamVR_Controller.Input((int)objTracked.index);

		if(controller.padPressed){
			drawPressed = true;
			// get the electric fingers has the copyItselfScript
			electricFingers.GetComponent<copyItself>().drawGhost();
			print("DRAW PRESSED");
		}else{
			drawPressed = false;
			print("DRAW NOT PRESSED");
		} 

		if (Input.GetAxis("Right Trigger") > 0.1f){
			// need to animate the robot's gripper to close also need to figure out ghost and command
		}
	}
}
