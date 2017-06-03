using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitLock : MonoBehaviour {

	public DigitWheel[] wheels;

	void Start(){
		wheels = GetComponentsInChildren<DigitWheel> ();
	}

	// Use this for initialization
	void WheelOnePositive () {
		wheels [0].PositiveIncrement ();
	}
	void WheelOneNegative () {
		wheels [0].NegativeIncrement ();
	}



	void WheelTwoPositive () {
		wheels [1].PositiveIncrement ();
	}
	void WheelTwoNegative () {
		wheels [1].NegativeIncrement ();
	}



	void WheelThreePositive () {
		wheels [2].PositiveIncrement ();
	}
	void WheelThreeNegative () {
		wheels [2].NegativeIncrement ();
	}


	void WheelFourPositive () {
		wheels [3].PositiveIncrement ();
	}
	void WheelFourNegative () {
		wheels [3].NegativeIncrement ();
	}
		
}
