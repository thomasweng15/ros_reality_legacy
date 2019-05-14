using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Note from HCI Team:
this is the script that can be attached to signage to make sure it always rotates to face the user. 
Originally we simply set the objects' rotation to the camera's, but the better way to do it is using
Unity's lookAt function that calculates rotation based off another vector3 

*/
public class BillboardIt : MonoBehaviour {
	private GameObject cam;
	void Start () {
		cam = GameObject.FindWithTag("MainCamera");
	}

	void Update () {
		//this.transform.rotation = cam.transform.rotation; //original method
		this.transform.LookAt(cam.transform, Vector3.up); 
	}
}

