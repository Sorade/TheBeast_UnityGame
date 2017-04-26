using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReaction : Reaction {

	public string eventName;       // The gameobject to be turned on or off.

	protected override void ImmediateReaction()
	{
		CustomEventManager.TriggerEvent (eventName);
	}
}
