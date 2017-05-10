using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Registers player movement and sends an event on movement
public class InputMonitor : MonoBehaviour {

	public SaveData playerSaveData;                 // Reference to the ScriptableObject which stores the name of the StartingPosition in the next scene.

	private string movementEvent = "Movement"; //the name of the event called on player movement

	private SceneController sceneController;    // Reference to the SceneController to actually do the loading and unloading of scenes.

	void Start(){
		sceneController = FindObjectOfType<SceneController> ();
	}

	void Update(){
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 ) {
			CustomEventManager.TriggerEvent (movementEvent); //triggers the movement event when movement inputs are not 0
		}

		if (Input.GetKey("escape")){
			/*
			//Application.Quit();
			SceneReaction loadSceneReaction = ScriptableObject.CreateInstance("SceneReaction") as SceneReaction;
			loadSceneReaction.sceneName = "Main_Menu";
			loadSceneReaction.startingPointInLoadedScene = "Main_Menu_Pos";
			loadSceneReaction.playerSaveData = playerSaveData;
			loadSceneReaction.Init ();
			loadSceneReaction.React ();
			*/
			// Save the StartingPosition's name to the data asset.
			playerSaveData.Save (PlayerPositionLoader.startingPositionKey, "Main_Menu_Pos");

			// Start the scene loading process.
			sceneController.FadeAndLoadScene ("Main_Menu");
		}
	}
}
