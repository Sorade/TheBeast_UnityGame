using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu]
public class SaveToDisk : ScriptableObject {
	public SaveData[] dataFiles;

	public void Save(){
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].SaveToDisk ();
		}
		Debug.Log ("SavedToDisk");
	}


	public void Load(){
		//CustomEventManager.TriggerEvent ("BeforeLoadSave");
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].LoadFromDisk ();
		}
		//CustomEventManager.TriggerEvent ("AfterLoadSave");
		Debug.Log ("LoadedFromDisk");
	}
}
