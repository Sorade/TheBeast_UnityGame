using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : Saver {

	public string sceneName;   // Reference to the scene that will be saved from and loaded to as a string.

	protected override string SetKey()
	{
		// Here the key will be based on the name of the scene, the string's type and a unique identifier.
		return sceneName + sceneName.GetType().FullName + uniqueIdentifier;
	}


	protected override void Save()
	{
		saveData.Save(key, sceneName);
	}


	protected override void Load()
	{
		// A blank function since the other script fetch the sceneName from the SaveData
	}
}
