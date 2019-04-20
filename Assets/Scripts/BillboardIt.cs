using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BillboardIt : MonoBehaviour {

	// Use this for initialization

	private GameObject cam;
	void Start () {
		cam = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = cam.transform.rotation;
	}
}

