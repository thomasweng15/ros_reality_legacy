using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTrigger : MonoBehaviour {

	// Use this for initialization
	Renderer rend;
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
		rend.material.SetColor("_Color", Color.green);
		rend.material.SetColor("_EmissionColor", Color.green);
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stayCount > 0.25f)
        {
            Debug.Log("staying");
            stayCount = stayCount - 0.25f;
        }
        else
        {
            stayCount = stayCount + Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
		rend.material.SetColor("_Color", Color.blue);
		rend.material.SetColor("_EmissionColor", Color.blue);
    }
}

