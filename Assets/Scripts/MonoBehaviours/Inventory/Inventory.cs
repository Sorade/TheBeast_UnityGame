using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];    // The Image components that display the Items.
	public string[] itemsID = new string[numItemSlots];           // The Items that are carried by the player.
	public AllItems itemDictionary;

    public const int numItemSlots = 4;                      // The number of items that can be carried.  This is a constant so that the number of Images and Items are always the same.

	void OnEnable(){
		//clears the inventory on each scene load before the items are loaded by the saver
		//CustomEventManager.StartListening("BeforeLoadSave", RemoveAll);
		//CustomEventManager.StartListening("AfterLoadSave", Refresh);
	}

	void OnDisable(){
		//CustomEventManager.StopListening("BeforeLoadSave", RemoveAll);
		//CustomEventManager.StopListening("AfterLoadSave", Refresh);
	}

    // This function is called by the PickedUpItemReaction in order to add an item to the inventory.
    public void AddItem(string itemToAddID)
    {
		
        // Go through all the item slots...
        for (int i = 0; i < itemsID.Length; i++)
        {
            // ... if the item slot is empty...
            if (itemsID[i] == "")
            {
                // ... set it to the picked up item and set the image component to display the item's sprite.
				itemsID[i] = itemToAddID; //itemDictionary.TryGetValue(itemToAddID);
				Item itemToAdd = null;
				if (itemDictionary.TryGetValue (itemToAddID,	ref itemToAdd)) {
					itemImages [i].sprite = itemToAdd.sprite;
					itemImages [i].enabled = true;
					return;
				} else {
					Debug.Log ("Could not add item to inventory");
					return;
				}
            }
        }
    }


    // This function is called by the LostItemReaction in order to remove an item from the inventory.
	public void RemoveItem (string itemToRemoveID)
    {
        // Go through all the item slots...
        for (int i = 0; i < itemsID.Length; i++)
        {
            // ... if the item slot has the item to be removed...
			if (itemsID[i] == itemToRemoveID)
            {
                // ... set the item slot to null and set the image component to display nothing.
                itemsID[i] = "";
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

	public void RemoveAll (){
		// Go through all the item slots...
		for (int i = 0; i < itemsID.Length; i++)
		{
			// ... set the item slot to null and set the image component to display nothing.
			itemsID[i] = null;
			itemImages[i].sprite = null;
			itemImages[i].enabled = false;
		}
		Debug.Log ("RemoveAll");
	}

	/*private void Refresh(){
		//save the current items
		//Item[] itemsTemp = Item[items.Length]; 
		//Array.Copy(items, itemsTemp, items.Length);

		//clear the items list
		//RemoveAll ();

		//add new loaded items to items[]
		foreach (var key in savedItems.itemKeyValuePairLists.keys) {
			Item loadedItem = null;

			if (savedItems.Load (key, ref loadedItem)) {
				this.AddItem (loadedItem);
				Debug.Log("note loaded");
			}
		}
		Debug.Log ("refreshed");
	}*/
}
