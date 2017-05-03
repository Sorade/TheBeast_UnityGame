using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Registers player movement and sends an event on movement
public class InputMonitor : MonoBehaviour {

	private string movementEvent = "Movement"; //the name of the event called on player movement

	void Update(){
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 ) {
			CustomEventManager.TriggerEvent (movementEvent); //triggers the movement event when movement inputs are not 0
		}

		if (Input.GetKey("escape")){
			Application.Quit();
		}
	}
}
