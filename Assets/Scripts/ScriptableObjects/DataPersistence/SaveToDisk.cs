using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu]
public class SaveToDisk : ScriptableObject {
	public SaveData[] dataFiles;
	public string[] saveFileNames;

	public void Save(){
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].SaveToDisk ();
		}
	}


	public void Load(){
		for (int i = 0; i < dataFiles.Length; i++) {
			dataFiles [i].LoadFromDisk ();
		}
	}
}
