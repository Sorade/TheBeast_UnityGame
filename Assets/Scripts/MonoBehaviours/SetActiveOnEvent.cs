using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SetActiveOnEvent : MonoBehaviour {

	public string occuringEvent; //InWorldMode
	public GameObject aGameObject;
	public Camera cam;
	public bool mode;

	void OnEnable ()
	{
		CustomEventManager.StartListening (occuringEvent, Activate);
	}

	void OnDisable ()
	{
		CustomEventManager.StopListening (occuringEvent, Activate);
	}

	void OnDestroy ()
	{
		CustomEventManager.StopListening (occuringEvent, Activate);
	}

	void Activate(){
		if (cam != null) {
			cam.enabled = mode;
		}
		else if (aGameObject != null) {
			aGameObject.SetActive (mode);
		} else {
			gameObject.SetActive (mode);
		}
	}
}
