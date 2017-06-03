using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitWheel : MonoBehaviour {

	private float speed = 1f;
	[HideInInspector]
	public int currentValue = 1;

	public void PositiveIncrement () {
		StartCoroutine(Rotate (1f));
	}

	public void NegativeIncrement () {
		StartCoroutine(Rotate (-1f));
	}


	IEnumerator Rotate (float sign) {		

		float startTime = Time.time;

		while (startTime + speed - Time.time  > 0f) {
			transform.Rotate (Vector3.up * 36f * Time.deltaTime * sign, Space.Self);
			yield return null;
		}

		currentValue += (int)sign;
	}
}
