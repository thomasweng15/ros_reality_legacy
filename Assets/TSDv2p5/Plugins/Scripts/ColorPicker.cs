using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour 
{
	Col c;

	float H=0f;
	float S=0f;
	float V=0f;

	public Slider Hue;
	public Slider Saturation;
	public Slider Value;
	public Slider Alpha;
	public Toggle main;
	public Toggle spec;
	public Toggle rim;
	public Image img;

	//TODO make private in release
	public Color col;

	public ChangeColor cc;

	void Start()
	{
		c = Col.Main;
		img.color = cc.GetColorMain ( c );
		col = img.color	;
		RGBToHSV ( img.color, out H, out S, out V);
		Hue.value = H;
		Saturation.value = S;
		Value.value = V;
		Alpha.value = img.color.a;

		spec.onValueChanged.AddListener (SpecT);
		main.onValueChanged.AddListener (MainT);
		rim.onValueChanged.AddListener (RimT);

	}

	public void SpecT(bool v)
	{
		c = Col.Spec;
		img.color = cc.GetColorMain ( c );
		RGBToHSV ( img.color, out H, out S, out V);
		Hue.value = H;
		Saturation.value = S;
		Value.value = V;
	}

	public void  MainT(bool v)
	{
		c = Col.Main;
		img.color = cc.GetColorMain ( c );
		RGBToHSV ( img.color, out H, out S, out V);
		Hue.value = H;
		Saturation.value = S;
		Value.value = V;
	}

	public void  RimT(bool v)
	{
		c = Col.Rim;
		img.color = cc.GetColorMain ( c );
		RGBToHSV ( img.color, out H, out S, out V);
		Hue.value = H;
		Saturation.value = S;
		Value.value = V;
	}

	public void GetH( float h)
	{
		H = h;
		col = HSVToRGB( h, S, V);
		img.color = col;
		cc.SetColorMain (col, c);
	}

	public void GetS( float s)
	{
		S = s;
		col = HSVToRGB( H, s, V);
		img.color = col;
		cc.SetColorMain (col, c);
	}

	public void GetV( float v)
	{
		V = v;
		col = HSVToRGB( H, S, v);
		img.color = col;
		cc.SetColorMain (col, c);
	}

	public void GetA( float a)
	{
		col.a = a;
		img.color = col;
		cc.SetColorMain (col, c);
	}

	private void RGBToHSV(Color rgbColor, out float H, out float S, out float V)
	{
		if (rgbColor.b > rgbColor.g && rgbColor.b > rgbColor.r)
		{
			RGBToHSVHelper(4f, rgbColor.b, rgbColor.r, rgbColor.g, out H, out S, out V);
		}
		else
		{
			if (rgbColor.g > rgbColor.r)
			{
				RGBToHSVHelper(2f, rgbColor.g, rgbColor.b, rgbColor.r, out H, out S, out V);
			}
			else
			{
				 RGBToHSVHelper(0f, rgbColor.r, rgbColor.g, rgbColor.b, out H, out S, out V);
			}
		}
	}
	
	private  void RGBToHSVHelper(float offset, float dominantcolor, float colorone, float colortwo, out float H, out float S, out float V)
	{
		V = dominantcolor;
		if (V != 0f)
		{
			float num = 0f;
			if (colorone > colortwo)
			{
				num = colortwo;
			}
			else
			{
				num = colorone;
			}
			float num2 = V - num;
			if (num2 != 0f)
			{
				S = num2 / V;
				H = offset + (colorone - colortwo) / num2;
			}
			else
			{
				S = 0f;
				H = offset + (colorone - colortwo);
			}
			H /= 6f;
			if (H < 0f)
			{
				H += 1f;
			}
		}
		else
		{
			S = 0f;
			H = 0f;
		}
	}

	Color HSVToRGB(float H, float S, float V)
	{

		if (S == 0f)
			return new Color (V, V, V);
		else if (V == 0f)
			return new Color (0f, 0f, 0f);

		else
		{
			Color col = Color.black;
			float Hval = H * 6f;
			int sel = Mathf.FloorToInt(Hval);
			float mod = Hval - sel;
			float v1 = V * (1f - S);
			float v2 = V * (1f - S * mod);
			float v3 = V * (1f - S * (1f - mod));
			switch (sel + 1)
			{
			case 0:
				col.r = V;
				col.g = v1;
				col.b = v2;
				break;
			case 1:
				col.r = V;
				col.g = v3;
				col.b = v1;
				break;
			case 2:
				col.r = v2;
				col.g = V;
				col.b = v1;
				break;
			case 3:
				col.r = v1;
				col.g = V;
				col.b = v3;
				break;
			case 4:
				col.r = v1;
				col.g = v2;
				col.b = V;
				break;
			case 5:
				col.r = v3;
				col.g = v1;
				col.b = V;
				break;
			case 6:
				col.r = V;
				col.g = v1;
				col.b = v2;
				break;
			case 7:
				col.r = V;
				col.g = v3;
				col.b = v1;
				break;
			}
			col.r = Mathf.Clamp(col.r, 0f, 1f);
			col.g = Mathf.Clamp(col.g, 0f, 1f);
			col.b = Mathf.Clamp(col.b, 0f, 1f);
			return col;
		}
	}
}
