using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineConnection : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public GameObject anchor;
	void Start () {
		target = GameObject.FindGameObjectWithTag("EndEffector");
		// anchor = GameObject.FindGameObjectWithTag("DominantController");
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<LineRenderer>().SetPosition(0,target.transform.position);
		this.GetComponent<LineRenderer>().SetPosition(1,anchor.transform.position);
	}
}
