using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyItself : MonoBehaviour {

	 // string of which arm to control. Valid values are "left" and "right"
    public string arm;
    private string grip_label;
    private string trigger_label;
	 TFListener TFListener;
    //scale represents how resized the virtual robot is
    float scale;
	public Transform prefab;
    
	void Start()
    {
	// 	if (arm == "left") {
    //         grip_label = "Left Grip";
    //         trigger_label = "Left Trigger";
    //     }
    //     else if (arm == "right") {
    //         grip_label = "Right Grip";
    //         trigger_label = "Right Trigger";
    //         Debug.Log("right grip");
    //     }
    //     else
    //         Debug.LogError("arm variable is not set correctly");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
	internal void drawGhost(){
        if(Time.frameCount % 6 == 0){
            Instantiate(prefab, this.transform.position, this.transform.rotation);
        }

	}

}
