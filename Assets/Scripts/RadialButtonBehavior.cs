using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialButtonBehavior : MonoBehaviour {

	// Use this for initialization
	public bool selectedState = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleSelectedState(){
		selectedState = !selectedState;
	}
}
