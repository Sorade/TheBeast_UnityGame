using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {


	public void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	public void Start(){
		//SceneManager.LoadScene ("terrain_trials");
		SceneManager.LoadScene(3);
	}
}
