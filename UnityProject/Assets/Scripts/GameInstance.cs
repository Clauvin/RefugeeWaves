using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

	//Class is used to create a serialized saved game; must have all relevant info about the game
	public static GameInstance current;

    public ResourceManager.ResourceSavePackage resource_save_package;
    public TimeManager.TimeSavePackage time_save_package;

    public GameInstance()
    {
        resource_save_package = ResourceManager.instance.GetResourceSavePackage();
        time_save_package = TimeManager.instance.GetTimeSavePackage();
        current = this;
    }

    public void PlacingSavedFilesBack()
    {
        ResourceManager.instance.SetResourceSavePackage(current.resource_save_package);
        TimeManager.instance.SetTimeSavePackage(current.time_save_package);
    }



}
