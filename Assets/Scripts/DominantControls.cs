using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominantControls : MonoBehaviour {


	private SteamVR_TrackedObject objTracked;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;

	private GameObject electricFingers;

	internal bool drawPressed;

	void Start () {
		objTracked = GetComponent<SteamVR_TrackedObject>();
		controller = GetComponent<SteamVR_TrackedController>();
		electricFingers = GameObject.FindWithTag("EndEffector");

		drawPressed = false;
	}
	void Update () {
		device = SteamVR_Controller.Input((int)objTracked.index);

		if(controller.padPressed){
			drawPressed = true;
			//get the grandchild electric fingers, because it has the copyItselfScript
			electricFingers.GetComponent<copyItself>().drawGhost();
			print("DRAW PRESSED");
		}else{
			drawPressed = false;
			print("DRAW NOT PRESSED");
		} 

		if (Input.GetAxis("Right Trigger") > 0.1f){
			//need to animate the gripper to close also need to figure out ghost and command
		}
	}
}
