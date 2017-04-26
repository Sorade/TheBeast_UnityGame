using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOnClick : MonoBehaviour {

	//private Rigidbody body;
	//private Collider col;
	private Transform trans;
	//public GameObject playerCam;
	public GameObject secondaryCam;
	public float lookAtSpeed;
	public float rotateSpeed;
	public float offsetFromCam;
	public float zoomFOV;
	public Vector3 upDirection = new Vector3 (0, 0, -1);

	private Quaternion targetRotation;

	void OnEnable()
	{
		CustomEventManager.StartListening ("Movement",RetunToPlayerCam);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("Movement", RetunToPlayerCam);
	}

	public void Start (){
		trans = GetComponent<Transform>();
	}

	void RetunToPlayerCam(){
		Camera.main.depth = secondaryCam.GetComponent<Camera> ().depth + 1;
		StopCoroutine ("MoveCameraToward");
	}

	private void LookAtItem(){
			Debug.Log(Camera.main.transform.position + "_" + secondaryCam.GetComponent<Transform> ().position);
			secondaryCam.GetComponent<Transform> ().position = Camera.main.transform.position;
			secondaryCam.GetComponent<Transform> ().rotation = Camera.main.transform.rotation;
			secondaryCam.GetComponent<Camera> ().fieldOfView = Camera.main.fieldOfView;
			StartCoroutine (MoveCameraToward (secondaryCam.GetComponent<Transform> ().position, secondaryCam.GetComponent<Camera> ().fieldOfView, secondaryCam.GetComponent<Transform> ().rotation));
			Camera.main.depth = secondaryCam.GetComponent<Camera> ().depth - 1;
	}

	void RotateTowardCam (){
		Vector3 relativePosition =  trans.position - secondaryCam.GetComponent<Transform> ().position;
		targetRotation = Quaternion.LookRotation (relativePosition, upDirection);
		secondaryCam.GetComponent<Transform> ().rotation = Quaternion.Slerp (secondaryCam.GetComponent<Transform> ().rotation, targetRotation, Time.deltaTime * rotateSpeed);
		//Debug.Log (trans.rotation + " " + targetRotation + " " + secondaryCam.GetComponent<Transform> ().rotation);
	}

	IEnumerator MoveCameraToward (Vector3 startPos, float startFOV, Quaternion startRotation)
	{
		//Debug.Log(secondaryCam.GetComponent<Transform> ().position + "_" + startPos + "_" + (trans.position + trans.forward * offsetFromCam));
		float timeElapsed = 0f;
		float distCovered = 0f;
		float zoomCovered = 0f;
		float rotCovered = 0f;

		while (((secondaryCam.GetComponent<Transform> ().position != (trans.position + trans.forward * offsetFromCam)) || (secondaryCam.GetComponent<Transform> ().rotation != targetRotation) || (secondaryCam.GetComponent<Camera>().fieldOfView != zoomFOV)) && timeElapsed < 2.5f) {
			distCovered += Time.deltaTime * lookAtSpeed;
			secondaryCam.GetComponent<Transform> ().position = Vector3.Lerp (startPos, trans.position + trans.forward * offsetFromCam, distCovered);

			//Debug.Log("pos" + (secondaryCam.GetComponent<Transform> ().position != (trans.position + trans.forward * offsetFromCam)));

			rotCovered += Time.deltaTime * rotateSpeed;
			Vector3 relativePosition =  trans.position - secondaryCam.GetComponent<Transform> ().position;
			targetRotation = Quaternion.LookRotation (relativePosition, upDirection);
			secondaryCam.GetComponent<Transform> ().rotation = Quaternion.Slerp (startRotation, targetRotation, rotCovered);
			//Debug.Log("rot" + (secondaryCam.GetComponent<Transform> ().rotation != targetRotation));


			zoomCovered += Time.deltaTime * lookAtSpeed;
			secondaryCam.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (startFOV, zoomFOV, zoomCovered);
			//Debug.Log("fov" + (secondaryCam.GetComponent<Camera>().fieldOfView != zoomFOV));

			timeElapsed += Time.deltaTime;
			yield return null;
		}
	}
}