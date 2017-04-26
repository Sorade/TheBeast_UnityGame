using UnityEditor;

[CustomEditor(typeof(EventReaction))]
public class EventReactionEditor : ReactionEditor 
	{
		protected override string GetFoldoutLabel ()
		{
			return "Event Reaction";
		}
	}
