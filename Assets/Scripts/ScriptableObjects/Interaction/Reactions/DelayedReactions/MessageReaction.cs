using UnityEngine;

public class MessageReaction : DelayedReaction
{
	public GameObject gameObject;       // The gameobject to be turned on or off.
	public string message;            // The message to send to the gameObject.


	protected override void ImmediateReaction()
	{
		gameObject.SendMessage (message);
	}
}