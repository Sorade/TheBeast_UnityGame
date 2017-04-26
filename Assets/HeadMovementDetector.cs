using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovementDetector : MonoBehaviour {

	private float previousAngle;
	private float currentAngle;

	// Use this for initialization
	void Start () {
		previousAngle = transform.rotation.eulerAngles.y;
		currentAngle = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		currentAngle = transform.rotation.eulerAngles.y;
		if (currentAngle != previousAngle) {
			Debug.Log ("mvt");
			CustomEventManager.TriggerEvent ("Movement");
		}
		previousAngle = transform.rotation.eulerAngles.y;
	}
}
