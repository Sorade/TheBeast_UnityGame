using UnityEngine;
using System.Collections.Generic;

// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference. 
[CreateAssetMenu]
public class AllItems : ScriptableObject
{
	public List<Item> items;                      // All the items that exist in the game.
	public List<string> itemID;                   // The corresponding item IDs

	private static AllItems instance;              // The singleton instance.


	private const string loadPath = "AllItems";    // The path within the Resources folder that 

	public static AllItems Instance                // The public accessor for the singleton instance.
	{
		get
		{
			// If the instance is currently null, try to find an AllConditions instance already in memory.
			if (!instance)
				instance = FindObjectOfType<AllItems> ();
			// If the instance is still null, try to load it from the Resources folder.
			if (!instance)
				instance = Resources.Load<AllItems> (loadPath);
			// If the instance is still null, report that it has not been created yet.
			if (!instance)
				Debug.LogError ("AllItems has not been created yet.  Go to Assets > Create > AllConditions.");
			return instance;
		}
		set { instance = value; }
	}

	public void Clear ()
	{
		itemID.Clear ();
		items.Clear ();
	}


	public void TrySetValue (string key, Item value)
	{
		// Find the index of the keys and values based on the given key.
		int index = itemID.FindIndex(x => x == key);

		// If the index is positive...
		if (index > -1)
		{
			// ... set the value at that index to the given value.
			items[index] = value;
		}
		else
		{
			// Otherwise add a new key and a new value to the collection.
			itemID.Add (key);
			items.Add (value);
		}
	}


	public bool TryGetValue (string key, ref Item value)
	{
		// Find the index of the keys and values based on the given key.
		int index = itemID.FindIndex(x => x == key);

		// If the index is positive...
		if (index > -1)
		{
			// ... set the reference value to the value at that index and return that the value was found.
			value = items[index];
			return true;
		}

		// Otherwise, return that the value was not found.
		return false;
	}
}
