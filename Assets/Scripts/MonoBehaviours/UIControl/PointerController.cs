using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour {

	private Image pointerImage;
	//Used to disable the toggling of the pointer without disactivating the component
	//it is currently (28/04/17) used to prevent the pointer image from showing when the actual cursor is enabled
	//during interactions.
	public bool isEnabled = true; 

	void OnEnable()
	{
		CustomEventManager.StartListening ("ShowPointer",ShowImage);
		CustomEventManager.StartListening ("HidePointer",HideImage);
		CustomEventManager.StartListening ("Movement",EnableImage);
		CustomEventManager.StartListening ("Movement",HideImage);
		CustomEventManager.StartListening ("DisablePointer",DisableImage);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("ShowPointer", ShowImage);
		CustomEventManager.StopListening ("HidePointer",HideImage);
		CustomEventManager.StopListening ("Movement", EnableImage);
		CustomEventManager.StopListening ("Movement",HideImage);
		CustomEventManager.StopListening ("DisablePointer",DisableImage);
	}


	void Start () {
		pointerImage = GetComponent<Image> ();
		HideImage (); //disables the image after the GetComponent<Image>() call otherwise GetComponent can't find disable components
	}

	void DisableImage(){
		HideImage ();
		isEnabled = false;
	}

	void EnableImage(){
		isEnabled = true;
	}

	void ShowImage(){
		if (isEnabled) {
			pointerImage.enabled = true;
		}
	}

	void HideImage(){
		pointerImage.enabled = false;
	}
}
