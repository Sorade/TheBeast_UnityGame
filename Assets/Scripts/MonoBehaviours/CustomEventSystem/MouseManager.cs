using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//class used to control when to display and unlock the cursor
//mostly relevant during an object interaction
public class MouseManager : MonoBehaviour {

	private FirstPersonController fpsController; //the first person controller attached to the player

	void Start () {
		fpsController = GetComponent<FirstPersonController> (); //looks for controller and assigns it
	}

	void OnEnable()
	{
		//looks for the event sent by InteractionMenuController when an interaction has started
		// and for the event sent on a player movement by the InputMonitor.
		CustomEventManager.StartListening ("MouseHover",EnableCursorVisibility);
		CustomEventManager.StartListening ("Movement",DisableCursorVisibility);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("MouseHover", EnableCursorVisibility);
		CustomEventManager.StopListening ("Movement", DisableCursorVisibility);
	}

	void DisableCursorVisibility(){
		//Disables the cursor visibility and lock it to the screen center
		fpsController.DisableCursorVisibility ();
	}

	void EnableCursorVisibility(){
		//Enables the cursor visibility and unlocks it to allow free movement on the screen
		fpsController.EnableCursorVisibility();
	}
}
