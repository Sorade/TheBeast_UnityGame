using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitWheel : MonoBehaviour {

	private float speed = 1f;
	//[HideInInspector]
	public int currentValue = 0;

	public void PositiveIncrement () {
		StartCoroutine(Rotate (1f));
	}

	public void NegativeIncrement () {
		StartCoroutine(Rotate (-1f));
	}


	IEnumerator Rotate (float sign) {
		Debug.Log (currentValue);
		UpdateValue ((int)sign);
		Debug.Log (currentValue);
		float startTime = Time.time;

		while (startTime + speed - Time.time  > 0f) {
			transform.Rotate (Vector3.up * 36f * Time.deltaTime * sign, Space.Self);
			yield return null;
		}
	}

	void UpdateValue(int sign){
		if (currentValue == 0 && sign < 0) {
			currentValue = 10;
		} else {
			if (currentValue == 9 && sign > 0) {
				currentValue = -1;
			}
		}

		currentValue += sign;
	}
}
