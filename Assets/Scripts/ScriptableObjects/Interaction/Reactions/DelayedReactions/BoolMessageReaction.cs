using UnityEngine;
using System.Reflection;
using System;

public class BoolMessageReaction : DelayedReaction
{
	public DigitLock gameObject;       // The gameobject to be sent the message
	public string message;            // The message to send to the gameObject.

	public Condition condition;     // The Condition to be changed.
	private bool satisfied;          // The satisfied state the Condition will be changed to.

	protected override void ImmediateReaction ()
	{		
		//Get the method corresponding to the message string on the gameObject
		Type thisType = gameObject.GetType();
		MethodInfo theMethod = thisType.GetMethod(message);
		//stores the return bool value into the satisfied var
		satisfied = (bool)theMethod.Invoke(gameObject, null);
		//Debug.Log (satisfied);
		// assigns the bool  value return by the method call to the condition
		condition.satisfied = satisfied;
	}
}
