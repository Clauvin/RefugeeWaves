using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

    public ResourceManager.ResourceSavePackage resource_save_package;
    public TimeManager.TimeSavePackage time_save_package;
    public StatsManager.StatsSavePackage stats_save_package;

    public GameInstance()
    {
        resource_save_package = ResourceManager.instance.GetResourceSavePackage();
        time_save_package = TimeManager.instance.GetTimeSavePackage();
        stats_save_package = StatsManager.instance.GetStatsSavePackage();
    }

    public void PlacingSavedFilesBack()
    {
        ResourceManager.instance.SetResourceSavePackage(resource_save_package);
        TimeManager.instance.SetTimeSavePackage(time_save_package);
        StatsManager.instance.SetStatsSavePackage(stats_save_package);
    }



}
