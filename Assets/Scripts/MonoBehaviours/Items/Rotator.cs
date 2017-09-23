using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float speed;
	public Vector3 axis;
	public bool isRotating = false;
	private Vector3 initialPos;
	private Quaternion initialRot;

	void Start(){
		initialPos = transform.position;
		initialRot = transform.rotation;
	}

	void Update()
	{
		if (isRotating) {
			// Rotate the object around the specified local axis
			transform.Rotate(axis * Time.deltaTime * speed);
		}
	}

	public void SwitchRotation(){
		isRotating = !isRotating;
		transform.position = initialPos;
		transform.rotation = initialRot;
	}
}
