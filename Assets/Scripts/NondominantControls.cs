using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NondominantControls : MonoBehaviour {

	// Use this for initialization
	public Transform prefab;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Left Trigger") > 0.5f)
        {
			Debug.Log("Left Trigger Press");
        }
	}
}
