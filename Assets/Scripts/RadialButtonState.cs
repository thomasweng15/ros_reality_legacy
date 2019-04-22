using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialButtonState : MonoBehaviour {

	// Use this for initialization
	internal bool selectedState = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void toggleSelectedState(bool newSetting)
    {
        selectedState = newSetting;
    }
}
