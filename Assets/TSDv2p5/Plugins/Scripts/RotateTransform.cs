using UnityEngine;
using System.Collections;

public class RotateTransform : MonoBehaviour {


	Transform t ;

	void Start()
	{
		t = GetComponent<Transform> ();
	}

	void Update() 
	{
			t.Rotate(Vector3.up * Time.deltaTime * 16.0f);
			//transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
		}

}
