using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FloatToText : MonoBehaviour 
{
	Text t;

	void Awake()
	{
		t = GetComponent<Text> ();
	}

	public void FloatToTextDo(float value)
	{
		t.text = value.ToString ("0.00");
	}
}
