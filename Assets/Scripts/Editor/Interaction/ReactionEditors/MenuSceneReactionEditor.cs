using UnityEditor;

[CustomEditor (typeof (MenuSceneReaction))]
public class MenuSceneReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel ()
	{
		return "Menu Scene Reaction";
	}
}
