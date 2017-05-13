using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionLoader : MonoBehaviour {
	public SaveData playerSaveData;             // Reference to the save data asset containing the player's starting position.

	public const string startingPositionKey = "starting position";
	// The key used to retrieve the starting position from the playerSaveData.

	private void Start()
	{
		// Create the wait based on the delay.
		//inputHoldWait = new WaitForSeconds (inputHoldDelay);

		// Load the starting position from the save data and find the transform from the starting position's name.
		string startingPositionName = "";
		playerSaveData.Load(startingPositionKey, ref startingPositionName);

		//create an empty dummy transform to be filled by the final position
		Transform startingPosition = new GameObject ().transform;

		//if the a loaded currentPosition has been passed on by the MenuSceneReaction then revert to the saved position
		if (startingPositionName == "currentPosition") {
			Vector3 loadedPosition = Vector3.zero;
			playerSaveData.Load ("currentPosition", ref loadedPosition);
			startingPosition.position = loadedPosition;
		} else { // go to the scene's default starting position
			startingPosition = StartingPosition.FindStartingPosition(startingPositionName);
		}

		// Set the player's position and rotation based on the starting position.
		transform.position = startingPosition.position;
		transform.rotation = startingPosition.rotation;
	}
}
