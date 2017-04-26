using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//Attached to FirstPersonController in order to disable it during interactions
public class ControllerActivator : MonoBehaviour {

	private FirstPersonController fpsController; // the first person controller of the player

	void Start(){
		fpsController = GetComponent<FirstPersonController> (); //assigning the first person controller
	}

	void OnEnable()
	{
		//Registering to event to detect when the mouse hovers over an interctable
		CustomEventManager.StartListening ("MouseHover",DisableActivation);
		//Registering to event to detect when the player is moving (i.e. away from the interactable)
		//Same "movement" event is called on Take and Use interaction actions
		CustomEventManager.StartListening ("Movement",EnableActivation);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("MouseHover", DisableActivation);
		CustomEventManager.StartListening ("Movement",EnableActivation);
	}

	//enables the fpscontroller to allow the player to move again
	void EnableActivation(){
		fpsController.enabled = true;
	}

	//prevents the player from moving during object interactions
	void DisableActivation(){
		fpsController.enabled = false;
	}

}
