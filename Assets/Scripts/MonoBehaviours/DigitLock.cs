﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitLock : MonoBehaviour {

	public int[] code;
	public DigitWheel[] wheels;

	void Start(){
		wheels = GetComponentsInChildren<DigitWheel> ();
	}

	//Check if the combination of the wheels matches the code
	public bool Check(){
		for (int i = 0; i < wheels.Length; i++) {
			if (wheels[i].currentValue != code[i]) {
				return false;
			}
		}
		return true;
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
