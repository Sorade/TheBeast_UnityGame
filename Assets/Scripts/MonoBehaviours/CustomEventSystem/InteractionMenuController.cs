using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class used to Control when the interaction pop-up menu is enabled.
//To attach, to interactable object with a child interaction menu as a GameObject
//  /!\ a collider needs to be attached to the object.
public class InteractionMenuController : MonoBehaviour {

	public GameObject interactionMenu; //the GameObject of the interaction menu
	public int hoverDectectionDistance; //The maximum distance between the player and the object to display the menu

	private float delay = 0f; //The delay before displaying the menu, once the mouse hover is detected
	private Transform objTransform; //the transform of the parent class used to calculated the player-object distance
	private bool isProtected;


	void OnEnable()
	{
		CustomEventManager.StartListening ("Movement",DisactivateMenu);
	}
	void OnDisable()
	{
		CustomEventManager.StopListening ("Movement", DisactivateMenu);
	}

	void Start(){
		objTransform = GetComponent<Transform> ();
	}

	void DisactivateMenu(){
		StopCoroutine ("ActivateMenu"); // terminated the menu displaying routine in case it was initiated
		interactionMenu.SetActive (false); // then disables the menu in case it is displayed
	}

	void OnMouseOver() //shows a cursor clone to the player when the mouse hovers an interactable if the player is close enough
	{
		float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, objTransform.position);
		if (dist <= hoverDectectionDistance) {
			CustomEventManager.TriggerEvent ("ShowPointer");
		}
	}

	void OnMouseExit(){
		CustomEventManager.TriggerEvent ("HidePointer");
	}

	void OnMouseDown(){
		// Calcuates the player-object distance
		float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, objTransform.position);
		if (dist <= hoverDectectionDistance) {
			// Call movement event to shut any open interaction menus
			//CustomEventManager.TriggerEvent ("Movement");
			// if the player is close enough starts the coroutine which will display the event
			// after the delay has elapsed
			StartCoroutine (ActivateMenu (delay));
		}
	}
		
	// a coroutine triggering the display of the menu which will be called each frame until completed
	IEnumerator ActivateMenu (float delay){
		yield return new WaitForSeconds (delay); //waits a while before the menu is displayed
		interactionMenu.SetActive (true);
		// sends an event to alert other classes an interaction has started
		CustomEventManager.TriggerEvent ("MouseHover");
		CustomEventManager.TriggerEvent ("HidePointer");
		CustomEventManager.TriggerEvent ("DisablePointer");
	}
}

