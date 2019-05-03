using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToRoboBase : MonoBehaviour {

	// Use this for initialization
	private GameObject roboBaseGripper;
	void Start () {
		roboBaseGripper = GameObject.Find("right_electric_gripper_basePivot");
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<Transform>().position = roboBaseGripper.GetComponent<Transform>().position;
	}
}
