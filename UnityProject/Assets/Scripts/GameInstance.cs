using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

	//Class is used to create a serialized saved game; must have all relevant info about the game
	public static GameInstance current;

    public ActionsManager actions_manager;

    public GameInstance()
    {
        actions_manager = ActionsManager.instance;
        current = this;
    }



}
