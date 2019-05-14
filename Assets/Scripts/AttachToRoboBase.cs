using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Note from HCI team:
  
We want to ensure that the ghost end effectors destroy themselves as the actual robot model moves through them. 
In order to do that with non-rigidbody items (notice the ghost end effectors only have colliders on them, not rigidbodies)
without the ghosts triggering each others self destruction, we need to have a seperate rigidbody with a colllider run
through them to trigger the 'destroyItself' script on the ghost prefab

This script is meant to be attached to an invisible rigidbody collider object, so that on start it puts that obj. to the 
robot's right gripper base.

*/
public class AttachToRoboBase : MonoBehaviour {

	// Use this for initialization
	private GameObject roboBaseGripper;
	void Start () {
		roboBaseGripper = GameObject.Find("right_electric_gripper_basePivot"); //you won't find this part until the game is running and the robots manifested
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<Transform>().position = roboBaseGripper.GetComponent<Transform>().position;
	}
}
