using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyItself : MonoBehaviour {

	// Use this for initialization
	public Transform prefab;

	public List<Transform> ghostArray = new List<Transform>();
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {

	//this is the old code that left ghost imprints on the trigger
		// if (Input.GetAxis("Right Trigger") > 0)
        // {
        //     Instantiate(prefab, this.transform.position, this.transform.rotation);
		// 	Debug.Log("yo yoy oyoyoyyyoyoyoooooo");
		// 	Debug.Log(Input.GetJoystickNames());
		// 	for (int i = 0; i < Input.GetJoystickNames().Length; i ++){
		// 		string whatwhat = Input.GetJoystickNames()[i];
		// 		Debug.Log(whatwhat);
		// 	}
        // }
        
	}
	internal void drawGhost(){
        Instantiate(prefab, this.transform.position, this.transform.rotation);
		Transform currentTransform = GetComponent<Transform>();
		ghostArray.Add(currentTransform);
	}
}
