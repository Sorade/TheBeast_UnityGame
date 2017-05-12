using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSaver : Saver
{
	private Inventory inventory;     // Reference to the GameObject that will have its activity saved from and loaded to.
	public string itemID; // Reference to the Item that will be saved.

	void Init(){
		//Fetches the Inventory script from the Persistent scene
		inventory = FindObjectOfType<Inventory> ();
	}

	protected override string SetKey()
	{
		//workaround to add get the inventory during Awake() call
		Init ();

		//Here the key will be based on the name of the gameobject, the gameobject's type and a unique identifier.
		return itemID + itemID.GetType().FullName + uniqueIdentifier;
	}


	protected override void Save()
	{
		for (int i = 0; i < inventory.itemsID.Length; i++) {
			if (inventory.itemsID[i] == itemID) { //checks the itemID is in the iventory
				saveData.Save(key, itemID); // saves the itemID if it is and ends the function
				return;
			}
		}
	}


	protected override void Load()
	{
		//clear all the inventory before loading it, to avoid duplicating items
		inventory.RemoveAll ();

		// Create a variable to be passed by reference to the Load function.
		string loadedItemID = null;
		// If the load function returns true then the itemID can be added.
		if (saveData.Load (key, ref loadedItemID)) {
			inventory.AddItem (loadedItemID);
		}
	}
}
