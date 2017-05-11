using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSaver : Saver
{
	public Inventory inventory;     // Reference to the GameObject that will have its activity saved from and loaded to.
	public Item item; // Reference to the Item that will be saved.

	void OnEnable(){
		//clears the inventory on each scene load before the items are loaded by the saver
		//CustomEventManager.StartListening("BeforeLoadSave", RemoveAll);
		CustomEventManager.StartListening("AfterLoadSave", Load);
	}

	void OnDisable(){
		//CustomEventManager.StopListening("BeforeLoadSave", RemoveAll);
		CustomEventManager.StopListening("AfterLoadSave", Load);
	}

	protected override string SetKey()
	{
		// Here the key will be based on the name of the gameobject, the gameobject's type and a unique identifier.
		Debug.Log(item.name + item.GetType().FullName + uniqueIdentifier);
		return item.name + item.GetType().FullName + uniqueIdentifier;
	}


	protected override void Save()
	{
		Debug.Log ("save attempt");
		for (int i = 0; i < inventory.items.Length; i++) {
			if (inventory.items[i] == item) { //checks the item is in the iventory
				saveData.Save(key, item); // saves the item if it is and ends the function
				Debug.Log("note saved");
				return;
			}
		}
		inventory.RemoveAll ();
	}


	protected override void Load()
	{
		// Create a variable to be passed by reference to the Load function.
		Item loadedItem = null;
		Debug.Log(saveData.itemKeyValuePairLists.keys.ToArray());
		// If the load function returns true then the item can be added.
		if (saveData.Load (key, ref loadedItem)) {
			inventory.AddItem (loadedItem);
			Debug.Log("note loaded");
		}
		Debug.Log("note NOT loaded");
	}
}
