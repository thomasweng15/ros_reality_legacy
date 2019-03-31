using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Changes a sharedMaterial parameters using some uGui sliders in-game

public class ChangeMatBrains : MonoBehaviour 
{
	//Drag your Sliders in this section 
	public Slider matcapIntensity ;
	public Slider emissionIntensity ;
	public Slider rimIntensity ;
	public Slider specularIntensity ;
	public Slider specularPower;
	public Slider rimPower;
	//Drag the gameObject that contains the sharedMaterial you wanna change here
	public Renderer rend;

	void Start()
	{
		if (rend == null) 
		{
			Debug.Log ("Please assign a gameobject with a Material in the rend slot");
			return;
		}

		if (matcapIntensity != null && rend.sharedMaterial.HasProperty("_MatcapIn")) 
		{
			matcapIntensity.onValueChanged.AddListener (MatcapIn);
			matcapIntensity.value = rend.sharedMaterial.GetFloat ("_MatcapIn");
			matcapIntensity.Select ();
		}

		if(emissionIntensity!=null && rend.sharedMaterial.HasProperty("_EmissIn"))
		{
			emissionIntensity.onValueChanged.AddListener (EmissIn);
			emissionIntensity.value = rend.sharedMaterial.GetFloat("_EmissIn");
			emissionIntensity.Select ();
		}

		if(rimIntensity!=null && rend.sharedMaterial.HasProperty("_RimIn"))
		{
			rimIntensity.onValueChanged.AddListener (RimIn);
			rimIntensity.value = rend.sharedMaterial.GetFloat("_RimIn");
			rimIntensity.Select ();
		}

		if(specularIntensity!=null && rend.sharedMaterial.HasProperty("_SIn"))
		{
			specularIntensity.onValueChanged.AddListener (SpecIn);

			specularIntensity.value = rend.sharedMaterial.GetFloat("_SIn");

			specularIntensity.Select ();

		}

		if(rimPower!=null && rend.sharedMaterial.HasProperty("_RimPow"))
		{
			rimPower.onValueChanged.AddListener (RimPow);
			rimPower.value = rend.sharedMaterial.GetFloat("_RimPow");
			rimPower.Select ();
		}

		if(specularPower!=null && rend.sharedMaterial.HasProperty("_SpecPow"))
		{
			specularPower.onValueChanged.AddListener (SpecPow);
			specularPower.value = rend.sharedMaterial.GetFloat("_SpecPow");
			specularPower.Select ();
		}
	}

	public void MatcapIn(float value)
	{
		rend.sharedMaterial.SetFloat("_MatcapIn", value);
	}

	public void EmissIn(float value)
	{
		rend.sharedMaterial.SetFloat("_EmissIn", value);
	}

	public void RimIn(float value)
	{
		rend.sharedMaterial.SetFloat("_RimIn", value);
	}

	public void SpecIn(float value)
	{
		rend.sharedMaterial.SetFloat("_SIn", value);
	}

	public void RimPow(float value)
	{
		rend.sharedMaterial.SetFloat("_RimPow", value);
	}

	public void SpecPow(float value)
	{
		rend.sharedMaterial.SetFloat("_SpecPow", value);
	}
}
