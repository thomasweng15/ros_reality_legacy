using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NondominantControls : MonoBehaviour {

	private SteamVR_TrackedObject objTracked;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;

	public GameObject[] buttonArr;

	//private int buttonHovered = -1; //the index value of the button currently 'hover' selected, if nothing then value is -1

	void Start () {
		objTracked = GetComponent<SteamVR_TrackedObject>();
		controller = GetComponent<SteamVR_TrackedController>();
	}
	void Update () {
		device = SteamVR_Controller.Input((int)objTracked.index);
		// Grabs input again each time update loop is called

		/* Controller touchpad is a unit circle */
		if(controller.padPressed){
			int optionSelected = quadSelector();
			buttonArr[optionSelected].GetComponent<Transform>().localScale  = new Vector3(1.3f, 1.3f, 1.3f);
			buttonArr[optionSelected].transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(100f / 255, 220f / 255, 140f / 255));
			switch (optionSelected){
				case 0:
				print("button pressed " + 0);

					break;
				case 1:
				print("button pressed " + 1);
				//redo
					break;
				case 2:
				print("button pressed " + 2);
				//undo
					break;
				case 3:
				print("button pressed " + 3);
				//reset
					break;
				default:
					break;
			}

		}else if(controller.padTouched){
			int optionSelected = quadSelector();
			//button highlighting by chan ging hte albedo
			

			//bool selectedState = buttonArr[optionSelected].GetComponent<ButtonBehavior>().selectedState;
			for(int i= 0; i < buttonArr.Length; i ++){
				bool selectedState = buttonArr[i].GetComponent<RadialButtonState>().selectedState;

				if (i == optionSelected){
					if(!selectedState){
						buttonArr[optionSelected].GetComponent<Transform>().localScale  = new Vector3(1.15f, 1.15f, 1.15f);
						buttonArr[i].transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 163f / 255, 193f / 255));
					}
					buttonArr[optionSelected].GetComponent<RadialButtonState>().toggleSelectedState(true);
				}else{
					if(selectedState){
						buttonArr[i].GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
						buttonArr[i].transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(140f / 255, 140f / 255, 140f / 255));
					}
					buttonArr[i].GetComponent<RadialButtonState>().toggleSelectedState(false);
				}
			}
		}else{
			for(int i= 0; i < buttonArr.Length; i ++){
				buttonArr[i].GetComponent<Transform>().localScale  = new Vector3(1f, 1f, 1f);
				buttonArr[i].transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(140f / 255, 140f / 255, 140f / 255));
			}
		}
	}

	private int quadSelector(){
		/* Touchpad is basically a unit circle from the device axises x and y */
		float x = device.GetAxis().x;
		float y = device.GetAxis().y;
		float angle = Mathf.Abs(Mathf.Atan(y / x) * 180 / Mathf.PI);

		/* Bottom half of touchpad mirrors the top half, so we only need to check x. */
		if(x < 0){
			angle = 180 - angle;
		}

		/* If the x is negative, that means, whatever the angle value, 
		*  it's actually 180-angle whereas if x is positive, it's just angle.
		*/
		if(angle <= 45 && angle > 0){
			return 0;
		}else if( angle > 45 && angle <=90){
			return 1;
		}else if (angle > 90 && angle <= 135){
			return 2;
		}else if (angle > 135 && angle <= 180){
			return 3;
		}else{
			return -1;
		}
	}
}
