using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];    // The Image components that display the Items.
	public string[] itemsID = new string[numItemSlots];           // The Items that are carried by the player.
	public AllItems itemDictionary;

    public const int numItemSlots = 4;                      // The number of items that can be carried.  This is a constant so that the number of Images and Items are always the same.
	private static bool inventoryCleared = false;

	void OnEnable(){
		//Allows the inventory to be cleared again
		CustomEventManager.StartListening("BeforeSceneUnload", AllowClearing);
	}

	void OnDisable(){
		CustomEventManager.StopListening("BeforeSceneUnload", AllowClearing);
	}

    // This function is called by the PickedUpItemReaction in order to add an item to the inventory.
    public void AddItem(string itemToAddID)
    {
		
        // Go through all the item slots...
        for (int i = 0; i < itemsID.Length; i++)
        {
            // ... if the item slot is empty...
            if (itemsID[i].Length == 0)
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

	//This function is called by the InventoryItemSavers before loading the items
	public void RemoveAll (){
		//ensures the inventory is cleared only once per scene change
		if (!inventoryCleared) {
			// Go through all the item slots...
			for (int i = 0; i < itemsID.Length; i++)
			{
				// ... set the item slot to null and set the image component to display nothing.
				itemsID[i] = "";
				itemImages[i].sprite = null;
				itemImages[i].enabled = false;
			}

			//flips switch to ensure the inventory is cleared only once per scene change
			inventoryCleared = true;
			Debug.Log ("clear inv");
		}
	}

	//before the subsequent loading event the inventory switch is fliped back
	void AllowClearing(){
		inventoryCleared = false;
	}
}
