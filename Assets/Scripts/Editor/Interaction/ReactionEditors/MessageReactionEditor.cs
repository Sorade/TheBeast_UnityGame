using UnityEditor;

[CustomEditor(typeof(MessageReaction))]
public class MessageReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel ()
	{
		return "Message Reaction";
	}
}
