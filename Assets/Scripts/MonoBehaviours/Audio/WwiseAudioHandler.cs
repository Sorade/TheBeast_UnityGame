using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseAudioHandler : MonoBehaviour, AudioHandler {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Play(string sampleName)
	{
		// appel a wise pour play le sound sampleName.
		Debug.Log("gently playing " + sampleName + " like a boss");
	}
}
