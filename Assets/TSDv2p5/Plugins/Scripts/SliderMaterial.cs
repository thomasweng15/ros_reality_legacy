using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderMaterial : MonoBehaviour {

	public Slider _slider;
	public Renderer _renderer;
	public string materialPropertyName;
	public Text valueText;

	void Start()
	{
		if (_renderer == null) 
		{
			Debug.Log ("Please assign a gameobject with a Material in the rend slot");
			return;
		}
		if( ! _renderer.sharedMaterial.HasProperty(materialPropertyName) )
		{
			//Debug.Log ("The shader doesn't have " + materialPropertyName + " property" );
			return;
		}

		if ( _slider != null  ) 
		{
			_slider.onValueChanged.AddListener (SetMaterialValue);
			_slider.value = _renderer.sharedMaterial.GetFloat (materialPropertyName);
			_slider.Select ();
		}
	}
	
	void SetMaterialValue(float value)
	{
		_renderer.sharedMaterial.SetFloat(materialPropertyName, value);
		if(valueText!=null)
		{
			valueText.text = value.ToString ("0.00");
		}
	}
}
