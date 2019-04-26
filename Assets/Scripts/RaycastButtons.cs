using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastButtons : MonoBehaviour
{

    // Use this for initialization
    bool isSelected = false;
    bool isInside = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        print("ENTERING");
        if (!isSelected)
        {
            isSelected = true;

            transform.localScale *= 1.05f;
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
    void OnTriggerStay()
    {
        print("INSIDE");
        isInside = true;
    }
    void OnTriggerExit()
    {
		print("EXITING");
        if (!isInside)
        {
        
            if (isSelected)
            {
                isSelected = false;
                transform.localScale /= 1.05f;
                GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
			isInside = false;
        }


    }
}
