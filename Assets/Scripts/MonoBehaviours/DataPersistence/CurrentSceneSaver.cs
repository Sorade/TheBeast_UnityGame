using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used specifically to save the position of the player in the game in order to load back from the menu at the place
public class CurrentSceneSaver : SceneSaver {

	protected override string SetKey()
	{
		return uniqueIdentifier;
	}
}
