using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;


// The game event manager to which the events are registered and triggered from.
//Tutorial visible @ https://unity3d.com/learn/tutorials/topics/scripting/events-creating-simple-messaging-system
public class CustomEventManager : MonoBehaviour {
	//Dictionary to which the events will be registered, the key is a string
	private Dictionary<string,UnityEvent> eventDictionary;
	//The EventManager available in the game.
	private static CustomEventManager eventManager;

	//looks for a CustomEventManager in the scene and returns the eventManager to the required function call.
	//That means, calling CustonEventManager.StartListening("anevent") will register an event to the eventManager
	//variable of this class.
	public static CustomEventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (CustomEventManager)) as CustomEventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}
	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	//Makes the class calling this method via CustonEventManager.StartListening("anevent") register to "anevent"
	public static void StartListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		// if the event exist the registration is done
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		//If "anevent" doesn't currently exist it is added to the event dictionary of the event manager
		//the the registration is done
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	//stops the class from listening to anevent via a CustonEventManager.StopListening("anevent") call
	public static void StopListening (string eventName, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	//Triggers the anevent on a CustonEventManager.TriggerEvent("anevent") in the given class
	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}
}
