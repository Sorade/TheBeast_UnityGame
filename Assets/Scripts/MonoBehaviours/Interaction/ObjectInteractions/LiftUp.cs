using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour {
	Transform transform;
	public float angle;
	public float rotateSpeed;
	public float liftUpSpeed;
	public Vector3 liftPosition;

	float cumulativeRotation;
	private Vector3 targetRotation;
	private Vector3 targetPosition;
	private float angleTarget;
	private Vector3 initialLocalRotation;
	private Rigidbody body;
	private Collider col;
	private bool isLifting;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();

		// Assuming a simple, flat hierarchy
		body = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
	}

	public void HitByRay () {
		if (!isLifting) {
			PickUp ();
		} else if (initialLocalRotation != Vector3.zero) {
			PutDown ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (isLifting) {
			float distance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

			if (distance > 3 && isLifting) {
				PutDown ();
			}
		}
	}

	private void PutDown(){
		targetPosition = transform.position - liftPosition ;
		angleTarget = initialLocalRotation.z;
		SetCollisionsActive(true);
		StartCoroutine(Animate ());
		isLifting = false;
	}

	private void PickUp(){
		if (Input.GetButtonDown ("Fire1")) {
			SetCollisionsActive(false);
			targetPosition = transform.position + liftPosition;
			initialLocalRotation = transform.localEulerAngles;
			angleTarget = angle;
			StartCoroutine(Animate ());
			isLifting = true;
		}
	}

	private void SetCollisionsActive(bool active)
	{
		body.isKinematic = !active;
		col.enabled = active;
	}

	IEnumerator Animate() {	
		//needed to wake sure while equals false on first pass of Purdown
		targetRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angleTarget);
		while (transform.position != targetPosition && transform.localEulerAngles != targetRotation) {
			//Rotate
			targetRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angleTarget);
			transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, targetRotation, rotateSpeed);
			//Lift
			transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * liftUpSpeed);
			yield return null;
		}
	}
}
