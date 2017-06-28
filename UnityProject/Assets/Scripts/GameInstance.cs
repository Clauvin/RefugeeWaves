using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

    [System.Serializable]
    public class ToTheObjectiveSavePackage
    {
        public Vector3 _initial_position;
        public Vector3 _final_objective;
        public float _time_to_reach_objective;
        public float _passed_time;

        public float _time_counted;
    }

    [System.Serializable]
    public class WaveObjectSavePackage {

        public Vector3 _position;
        public Quaternion _rotation;
        public Vector3 _scale;

        public ImmigrantWave.ImmigrantWaveSavePackage immigrant_wave_save_package;
        public ToTheObjectiveSavePackage to_the_objective_save_package;

    }

    public ResourceManager.ResourceSavePackage resource_save_package;

    public TimeManager.TimeSavePackage time_save_package;

    public StatsManager.StatsSavePackage stats_save_package;

    public CommerceManager.CommerceSavePackage commerce_save_package;

    public ImmigrantManager.ImmigrantSavePackage immigrant_save_package;
    public ImmigrantWaveLauncher.ImmigrantWaveLauncherSavePackage immigrant_wave_launcher_save_package;
    public List<ImmigrantWave.ImmigrantWaveSavePackage> list_immigrant_wave_save_package_legal;
    public List<ImmigrantWave.ImmigrantWaveSavePackage> list_immigrant_wave_save_package_illegal;

    public List<WaveObjectSavePackage> list_wave_object_save_package;

    public RandomEventManager.RandomEventSavePackage random_event_save_package;

    /*public WaveObjectSavePackage ExtractWaveObjectSavePackage(GameObject game_object)
    {
        WaveObjectSavePackage package = new WaveObjectSavePackage();
        package._position = game_object.transform.position;
        package._rotation = game_object.transform.rotation;
        package._scale = game_object.transform.localScale;
        package.immigrant_wave_save_package = game_object.GetComponent<ImmigrantWave>().GetImmigrantWaveSavePackage();

        MovingToTheObjective objective = game_object.GetComponent<MovingToTheObjective>();
        package.to_the_objective_save_package._initial_position = objective.initial_position;
        package.to_the_objective_save_package._final_objective = objective.final_objective;
        package.to_the_objective_save_package._time_to_reach_objective = objective.time_to_reach_objective;
        package.to_the_objective_save_package._passed_time = objective.passed_time;
        package.to_the_objective_save_package._time_counted


    }*/


    

    public GameInstance()
    {
        resource_save_package = ResourceManager.instance.GetResourceSavePackage();
        time_save_package = TimeManager.instance.GetTimeSavePackage();
        stats_save_package = StatsManager.instance.GetStatsSavePackage();
        commerce_save_package = CommerceManager.instance.GetCommerceSavePackage();
        immigrant_save_package = ImmigrantManager.instance.GetImmigrantSavePackage();
        immigrant_wave_launcher_save_package = ImmigrantWaveLauncher.instance.GetImmigrantWaveLauncherSavePackage();
        random_event_save_package = RandomEventManager.instance.GetRandomEventSavePackage();
        list_immigrant_wave_save_package_legal = new List<ImmigrantWave.ImmigrantWaveSavePackage>();
        list_immigrant_wave_save_package_illegal = new List<ImmigrantWave.ImmigrantWaveSavePackage>();
        list_wave_object_save_package = new List<WaveObjectSavePackage>();

        List<ImmigrantWave> list_immigrant_wave = ImmigrantManager.instance.legalWaves;
        foreach (ImmigrantWave i in list_immigrant_wave)
        {
            list_immigrant_wave_save_package_legal.Add(i.immigrant_wave_save_package);
        }
        list_immigrant_wave = ImmigrantManager.instance.illegalWaves;
        foreach (ImmigrantWave i in list_immigrant_wave)
        {
            list_immigrant_wave_save_package_illegal.Add(i.immigrant_wave_save_package);
        }

        GameObject[] list_of_game_object_waves = GameObject.FindGameObjectsWithTag("Wave");
        foreach(GameObject go in list_of_game_object_waves)
        {
            

        }

    }

    public void PlacingSavedFilesBack()
    {
        ResourceManager.instance.SetResourceSavePackage(resource_save_package);
        TimeManager.instance.SetTimeSavePackage(time_save_package);
        StatsManager.instance.SetStatsSavePackage(stats_save_package);
        CommerceManager.instance.SetCommerceSavePackage(commerce_save_package);
        ImmigrantManager.instance.SetImmigrantSavePackage(immigrant_save_package);
        ImmigrantWaveLauncher.instance.SetImmigrantWaveLauncherSavePackage(immigrant_wave_launcher_save_package);
        RandomEventManager.instance.SetRandomEventSavePackage(random_event_save_package);

        ImmigrantManager.instance.legalWaves = new List<ImmigrantWave>();
        foreach (ImmigrantWave.ImmigrantWaveSavePackage iwsp in list_immigrant_wave_save_package_legal)
        {
            ImmigrantWave iw = new ImmigrantWave(iwsp);
            ImmigrantManager.instance.legalWaves.Add(iw);
        }

        ImmigrantManager.instance.illegalWaves = new List<ImmigrantWave>();
        foreach (ImmigrantWave.ImmigrantWaveSavePackage iwsp in list_immigrant_wave_save_package_illegal)
        {
            ImmigrantWave iw = new ImmigrantWave(iwsp);
            ImmigrantManager.instance.illegalWaves.Add(iw);
        }
    }



}
