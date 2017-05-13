using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneReaction : SceneReaction {

	protected override void ImmediateReaction()
	{
		Vector3 lastSavedPosition = Vector3.zero;
		string lastSavedScene = "";

		// if the a save game has been loaded or the player has already entered the game sends him back to the last position saved
		if (//sets the starting position in the new scene as the recorded player's position on the last save
			playerSaveData.Load ("currentPosition", ref lastSavedPosition) && 
			//sets the scene to be loaded as the last scene where the player was at the time of the last save
			playerSaveData.Load ("currentScene", ref lastSavedScene)){

			// Save the StartingPosition's name to the data asset.
			playerSaveData.Save (PlayerPositionLoader.startingPositionKey, "currentPosition");

			// Start the scene loading process.
			sceneController.FadeAndLoadScene (lastSavedScene);

		} else {

		//else loads the default settings

		// Save the StartingPosition's name to the data asset.
		playerSaveData.Save (PlayerPositionLoader.startingPositionKey, startingPointInLoadedScene);

		// Start the scene loading process.
			sceneController.FadeAndLoadScene (sceneName);
		}
	}
}
