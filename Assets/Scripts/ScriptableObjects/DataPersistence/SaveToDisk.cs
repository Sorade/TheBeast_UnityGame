using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu]
public class SaveToDisk : ScriptableObject {
	public SaveData[] dataFiles;

	public void Save(){
		//iterates through all the SaveData instances added to the dataFiles and SavesToDisk
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].SaveToDisk ();
		}
		Debug.Log ("SavedToDisk");
	}

	public void Load(){
		//iterates through all the SaveData instances added to the dataFiles and LoadFromDisk
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].LoadFromDisk ();
		}
		Debug.Log ("LoadedFromDisk");
	}
}
