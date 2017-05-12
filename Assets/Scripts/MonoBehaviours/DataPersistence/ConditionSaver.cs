using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSaver : Saver {
	public Condition condition ; // Reference to the Item that will be saved.

	protected override string SetKey()
	{
		//Here the key will be based on the name of the gameobject, the gameobject's type and a unique identifier.
		return condition.hash + condition.GetType().FullName + uniqueIdentifier;
	}


	protected override void Save()
	{
		saveData.Save(key, condition.satisfied); // saves the itemID if it is and ends the function
		Debug.Log ("Saved " + condition.description + " as " +condition.satisfied);
	}


	protected override void Load()
	{
		// Create a variable to be passed by reference to the Load function.
		bool satisfiedState = false;
		// If the load function returns true then the itemID can be added.
		if (saveData.Load (key, ref satisfiedState)) {
			condition.satisfied = satisfiedState;
			Debug.Log ("Loaded " + condition.description + " as " +condition.satisfied);
		}
	}
}

