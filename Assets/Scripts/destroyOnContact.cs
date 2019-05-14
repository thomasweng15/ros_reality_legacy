using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This is to be attached to  */
public class destroyOnContact : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
	void OnTriggerEnter()
    {
		//Debug.Log("yo destroy ghost");
        Destroy(gameObject);
    }
}
