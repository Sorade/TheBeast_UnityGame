using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;   // The interactable that is currently being headed towards.

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
