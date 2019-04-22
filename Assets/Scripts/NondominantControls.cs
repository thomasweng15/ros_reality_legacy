using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NondominantControls : MonoBehaviour {

	private SteamVR_TrackedObject objTracked;
	private SteamVR_Controller.Device device;
	private SteamVR_TrackedController controller;

	public GameObject[] buttonArr;

	void Start () {
		objTracked = GetComponent<SteamVR_TrackedObject>();
		controller = GetComponent<SteamVR_TrackedController>();
	}
	void Update () {
		device = SteamVR_Controller.Input((int)objTracked.index);
		// Grabs input again each time update loop is called

		if (Input.GetAxis("Left Trigger") > 0.5f)
        {
			Debug.Log("Left Trigger Press");
        }

		/* Controller touchpad is a unit circle */
		if(controller.padPressed){
			// int optionSelected = quadSelector();
			// switch (optionSelected){
			// 	case 0:
			// 		break;
			// 	case 1:
			// 	//redo
			// 		break;
			// 	case 2:
			// 	//undo
			// 		break;
			// 	case 3:
			// 	//reset
			// 		break;

			// 	default:
			// 		break;
			// }

		}
		if(controller.padTouched){
			int optionSelected = quadSelector();
			print("optionSelected: " + optionSelected);
			//button highlighting by chan ging hte albedo
			
			print("selectedState: " + buttonArr[optionSelected].GetComponent<RadialButtonState>().selectedState);
			//bool selectedState = buttonArr[optionSelected].GetComponent<ButtonBehavior>().selectedState;
			for(int i= 0; i < buttonArr.Length; i ++){
				bool selectedState = buttonArr[i].GetComponent<RadialButtonState>().selectedState;
				print("the button's selectedState is "+ selectedState);
				if (i == optionSelected){
					if(!selectedState){
						buttonArr[optionSelected].GetComponent<Transform>().localScale  = new Vector3(1.5f, 1.5f, 1.5f);
					}
					buttonArr[optionSelected].GetComponent<RadialButtonState>().toggleSelectedState(true);
				}else{
					if(selectedState){
						buttonArr[optionSelected].GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
					}
					buttonArr[optionSelected].GetComponent<RadialButtonState>().toggleSelectedState(false);
				}
			}
			switch (optionSelected){
				case 0:
					break;
				case 1:
				//redo
					break;
				case 2:
				//undo
					break;
				case 3:
				//reset
					break;

				default:
					break;
			}
		}
	}

	private int quadSelector(){
		/* Touchpad is basically a unit circle from the device axises x and y */
		float x = device.GetAxis().x;
		print("x: " + x);
		float y = device.GetAxis().y;
		print("y: " + y);
		float angle = Mathf.Abs(Mathf.Atan(y / x) * 180 / Mathf.PI);

		/* Bottom half of touchpad mirrors the top half, so we only need to check x. */
		if(x < 0){
			angle = 180 - angle;
		}

		/* If the x is negative, that means, whatever the angle value, 
		*  it's actually 180-angle whereas if x is positive, it's just angle.
		*/

		print("ANGLE: " + angle);
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
