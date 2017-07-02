using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

    [System.Serializable]
    public class ToTheObjectiveSavePackage
    {
        public float _initial_position_x;
        public float _initial_position_y;
        public float _initial_position_z;

        public float _final_objective_x;
        public float _final_objective_y;
        public float _final_objective_z;

        public float _time_to_reach_objective;
        public float _passed_time;

        public float _time_counted;
    }

    [System.Serializable]
    public class WaveObjectSavePackage {

        public string name;
        public float _position_x, _position_y, _position_z;
        public float _rotation_x, _rotation_y, _rotation_z, _rotation_w;
        public float _scale_x, _scale_y, _scale_z;

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

    public List<PlayerAction.PlayerActionCooldownSavePackage> list_player_action_cooldown_save_package;

    public List<CommerceAction.CommerceActionCooldownSavePackage> list_commerce_action_cooldown_save_package;

    public WaveObjectSavePackage ExtractWaveObjectSavePackage(GameObject game_object)
    {
        WaveObjectSavePackage package = new WaveObjectSavePackage();
        package._position_x = game_object.transform.position.x;
        package._position_y = game_object.transform.position.y;
        package._position_z = game_object.transform.position.z;
        package._rotation_x = game_object.transform.rotation.x;
        package._rotation_y = game_object.transform.rotation.y;
        package._rotation_z = game_object.transform.rotation.z;
        package._rotation_w = game_object.transform.rotation.w;
        package._scale_x = game_object.transform.localScale.x;
        package._scale_y = game_object.transform.localScale.y;
        package._scale_z = game_object.transform.localScale.z;
        package.immigrant_wave_save_package = game_object.GetComponent<ImmigrantWave>().GetImmigrantWaveSavePackage();

        MovingToTheObjective objective = game_object.GetComponent<MovingToTheObjective>();

        ToTheObjectiveSavePackage obj_save_package = new ToTheObjectiveSavePackage();

        obj_save_package._initial_position_x = objective.initial_position.x;
        obj_save_package._initial_position_y = objective.initial_position.y;
        obj_save_package._initial_position_z = objective.initial_position.z;
        obj_save_package._final_objective_x = objective.final_objective.x;
        obj_save_package._final_objective_y = objective.final_objective.y;
        obj_save_package._final_objective_z = objective.final_objective.z;
        obj_save_package._time_to_reach_objective = objective.time_to_reach_objective;
        obj_save_package._passed_time = objective.passed_time;
        obj_save_package._time_counted = objective.GetTimeCounted();

        package.to_the_objective_save_package = obj_save_package;

        package.name = game_object.name;

        return package;
    }


    

    public GameInstance()
    {


    }

    public void PreparingSaveFile()
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
        list_player_action_cooldown_save_package = new List<PlayerAction.PlayerActionCooldownSavePackage>();
        list_commerce_action_cooldown_save_package = new List<CommerceAction.CommerceActionCooldownSavePackage>();

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
        foreach (GameObject go in list_of_game_object_waves)
        {
            list_wave_object_save_package.Add(ExtractWaveObjectSavePackage(go));
        }

        foreach(PlayerAction pa in ActionsManager.instance.possibleActions)
        {
            list_player_action_cooldown_save_package.Add(pa.GetPlayerActionCooldownSavePackage());
        }

        foreach (CommerceAction pa in ActionsManager.instance.possibleCommerceActions)
        {
            list_commerce_action_cooldown_save_package.Add(pa.GetCommerceActionCooldownSavePackage());
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

        ImmigrantWaveLauncher.instance.DeleteAllTravellingWaves();

        foreach (WaveObjectSavePackage pack in list_wave_object_save_package)
        {
            ImmigrantWaveLauncher.instance.InstantiateNewRefugeWave(pack);
        }
    }



}
