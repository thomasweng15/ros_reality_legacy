﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyItself : MonoBehaviour {

	// Use this for initialization
	public Transform prefab;
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Right Trigger") > 0)
        {
            Instantiate(prefab, this.transform.position, this.transform.rotation);
			Debug.Log("yo yoy oyoyoyyyoyoyoooooo");
			Debug.Log(Input.GetJoystickNames());
			for (int i = 0; i < Input.GetJoystickNames().Length; i ++){
				string whatwhat = Input.GetJoystickNames()[i];
				Debug.Log(whatwhat);
			}
        }
        
	}
}
