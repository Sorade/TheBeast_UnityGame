using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour {

	private Image pointerImage;
	public bool isEnabled = true;

	void OnEnable()
	{
		CustomEventManager.StartListening ("ShowPointer",ShowImage);
		CustomEventManager.StartListening ("HidePointer",HideImage);
		CustomEventManager.StartListening ("Movement",EnableImage);
		CustomEventManager.StartListening ("DisablePointer",DisableImage);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("ShowPointer", ShowImage);
		CustomEventManager.StartListening ("HidePointer",HideImage);
		CustomEventManager.StopListening ("Movement", EnableImage);
		CustomEventManager.StartListening ("DisablePointer",DisableImage);
	}

	// Use this for initialization
	void Start () {
		pointerImage = GetComponent<Image> ();
		HideImage ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
