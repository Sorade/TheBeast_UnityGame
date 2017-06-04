using UnityEditor;

[CustomEditor(typeof(BoolMessageReaction))]
public class BoolMessageReactionEditor : ReactionEditor {
	protected override string GetFoldoutLabel ()
	{
		return "BoolMessage Reaction";
	}
}
