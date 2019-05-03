using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyItself : MonoBehaviour {

	public Transform prefabOpen;

    public Transform prefabClosed;
    
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
            if (Input.GetAxis("Right Trigger") > 0.5f) {
                Instantiate(prefabClosed, this.transform.position, this.transform.rotation);
            }else{
                Instantiate(prefabOpen, this.transform.position, this.transform.rotation);
            }

        }

	}

}
