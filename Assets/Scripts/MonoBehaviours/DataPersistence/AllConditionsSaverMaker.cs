using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllConditionsSaverMaker : MonoBehaviour {
	//
	public SaveData conditionSaveData; //the SaveData instance in which all the conditions are saved
	private GameObject conditionSaver; //the condition saver object in the persistent scene

	void Awake(){
		conditionSaver = GameObject.FindGameObjectWithTag ("Condition Saver");
		Generate ();
		Debug.Log ("Condition Savers Generated");
	}

	void Generate(){ 
		//avoids duplicating the savers
		if (conditionSaver.GetComponents<ConditionSaver> ().Length != AllConditions.Instance.conditions.Length) {
			RemoveAll (); //clears all the existing savers
			//generates all the savers needed
			for (int i = 0; i < AllConditions.Instance.conditions.Length; i++) {

				ConditionSaver saver = conditionSaver.AddComponent<ConditionSaver> ();

				saver.uniqueIdentifier = AllConditions.Instance.conditions [i].description;
				saver.condition = AllConditions.Instance.conditions [i];
				saver.saveData = conditionSaveData;
				saver.enabled = true;
				saver.DifferedSetKey ();
			}
		}
	}

	//removes all the existing savers
	void RemoveAll(){
		ConditionSaver[] savers = conditionSaver.GetComponents<ConditionSaver> ();
		for (int i = 0; i < savers.Length; i++) {
			DestroyImmediate (savers [i]);
		}
	}
}
