using UnityEngine;
using System.Collections;

public enum Col {Main, Spec, Rim}

public class ChangeColor : MonoBehaviour 
{

	Renderer r;

	void Awake()
	{
		r = GetComponent<Renderer> ();
	}

	public void SetColorMain ( Color col, Col c ) 
	{
		if (c == Col.Main) 
		{
			r.material.color = col;
		}

		if (c == Col.Rim) 
		{
			r.material.SetColor ("_RimColor", col);
		}

		if (c == Col.Spec) 
		{
			r.material.SetColor ("_SpecColor", col);
		}
	}

	public Color GetColorMain( Col c)
	{
		if (c == Col.Rim) 
		{
			return r.material.GetColor ("_RimColor");
		}
		else
		if (c == Col.Spec) 
		{
			return r.material.GetColor ("_SpecColor");
		}
		else

			return r.material.color;


	}


}
