using UnityEngine;

// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference.  
public class AllItems : ResettableScriptableObject
{
	public Item[] items;                      // All the Conditions that exist in the game.


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
}
