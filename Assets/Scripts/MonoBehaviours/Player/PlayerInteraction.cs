using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{
    public SaveData playerSaveData;             // Reference to the save data asset containing the player's starting position.
    //public float inputHoldDelay = 0.5f;         // How long after reaching an interactable before input is allowed again.
    
	public const string startingPositionKey = "starting position";
	// The key used to retrieve the starting position from the playerSaveData.

    private Interactable currentInteractable;   // The interactable that is currently being headed towards.
    //private bool handleInput = true;            // Whether input is currently being handled.
    //private WaitForSeconds inputHoldWait;       // The WaitForSeconds used to make the user wait before input is handled again.

    private void Start()
    {
        // Create the wait based on the delay.
        //inputHoldWait = new WaitForSeconds (inputHoldDelay);

        // Load the starting position from the save data and find the transform from the starting position's name.
        string startingPositionName = "";
        playerSaveData.Load(startingPositionKey, ref startingPositionName);
        Transform startingPosition = StartingPosition.FindStartingPosition(startingPositionName);

        // Set the player's position and rotation based on the starting position.
        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;
    }

    // This function is called by the EventTrigger on an Interactable, the Interactable component is passed into it.
    public void OnInteractableClick(Interactable interactable)
    {
        // Store the interactble that was clicked on.
        currentInteractable = interactable;

		// If the player is stopping at an interactable...
		if (currentInteractable)
		{
			// ... set the player's rotation to match the interactionLocation's.
			//transform.rotation = currentInteractable.interactionLocation.rotation;

			// Interact with the interactable and then null it out so this interaction only happens once.
			currentInteractable.Interact();
			currentInteractable = null;
		}
    }
		
}
