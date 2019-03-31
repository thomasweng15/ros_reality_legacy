using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SetToggle : MonoBehaviour 
{

	void Start()	
	{

		GetComponent<Toggle> ().Select ();
	}

}