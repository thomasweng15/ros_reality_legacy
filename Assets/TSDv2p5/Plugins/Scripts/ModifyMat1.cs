using UnityEngine;
using System.Collections;

public class ModifyMat1 : MonoBehaviour 
{
	Renderer rend;

	void Start() 
	{
		rend = GetComponent<Renderer>();

	}

	public void ModifyEmisIn( float emis)
	{
		rend.material.SetFloat("_EmisIn", emis);
	}

	public void ModifyMatcapIn( float matc)
	{
		rend.material.SetFloat("_MatcapIn", matc);
	}

	public void ModifySpecIn( float spec)
	{
		rend.material.SetFloat("_SpecIn", spec);
	}

}
