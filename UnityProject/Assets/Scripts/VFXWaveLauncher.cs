using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Creates an instance of a VFX Wave Object, with:
///     b) Instance creation point
///     c) Finish point
///     d) Speed to reach
/// </summary>
public class VFXWaveLauncher : MonoBehaviour
{

    public static VFXWaveLauncher instance;
    public bool first_part_of_avoiding_spontaneous_wave_launching_at_start;
    public bool second_part_of_avoiding_spontaneous_wave_launching_at_start;

    #region Spawn Points and Spawn Objectives
    public GameObject refugees_exit_1, refugees_exit_2;
    public GameObject refugees_entrance_1, refugees_entrance_2;
    #endregion

    [Serializable]
    public class SFXWaveLauncherSavePackage
    {
        public int _nextWaveId = 0;
        public int _waves_sent = 0;

        #region Public Variables
        public float _present_time = 0.0f;
        public float _last_time;
        public float _time_for_next = 0.0f;
        public float _def_time_in_seconds = 30.0f;

        public bool _wave_instantiation_timer = true;
        #endregion
    }

    /// <summary>
    /// Set this to public for debugging in the editor
    /// </summary>
    public SFXWaveLauncherSavePackage vfx_wave_launcher_save_package;

    public SFXWaveLauncherSavePackage GetImmigrantWaveLauncherSavePackage()
    {
        return vfx_wave_launcher_save_package;
    }

    public void SetImmigrantWaveLauncherSavePackage(SFXWaveLauncherSavePackage save_package)
    {
        vfx_wave_launcher_save_package = save_package;
    }

    public int nextWaveId
    {
        get { return vfx_wave_launcher_save_package._nextWaveId; }
        set { vfx_wave_launcher_save_package._nextWaveId = value; }
    }

    public int waves_sent
    {
        get { return vfx_wave_launcher_save_package._waves_sent; }
        set { vfx_wave_launcher_save_package._waves_sent = value; }
    }

    #region Public Variables
    public float present_time
    {
        get { return vfx_wave_launcher_save_package._present_time; }
        set { vfx_wave_launcher_save_package._present_time = value; }
    }

    public float last_time
    {
        get { return vfx_wave_launcher_save_package._last_time; }
        set { vfx_wave_launcher_save_package._last_time = value; }
    }

    public float time_for_next
    {
        get { return vfx_wave_launcher_save_package._time_for_next; }
        set { vfx_wave_launcher_save_package._time_for_next = value; }
    }

    public float def_time_in_seconds
    {
        get { return vfx_wave_launcher_save_package._def_time_in_seconds; }
        set { vfx_wave_launcher_save_package._def_time_in_seconds = value; }
    }
    #endregion

    private bool wave_instantiation_timer
    {
        get { return vfx_wave_launcher_save_package._wave_instantiation_timer; }
        set { vfx_wave_launcher_save_package._wave_instantiation_timer = value; }
    }

    #region Instantiation Timer Functions
    public bool GetWaveInstantiationTimer() { return wave_instantiation_timer; }

    public void SetWaveInstantiationTimer(bool wit) { wave_instantiation_timer = wit; }

    public void ToggleWaveInstantiationTimer() { wave_instantiation_timer = !wave_instantiation_timer; }
    #endregion

    public void InstantiateNewVFXWave(GameInstance.WaveObjectSavePackage package)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("VFX Wave Object"));
        icone.transform.SetParent(GameObject.Find("WavesCanvas").transform);

        icone.transform.position = new Vector3(package._position_x,
                                               package._position_y,
                                               package._position_z);
        icone.transform.localScale = new Vector3(package._scale_x,
                                                package._scale_y,
                                                package._scale_z);
        icone.transform.rotation = new Quaternion(package._rotation_x,
                                                  package._rotation_y,
                                                  package._rotation_z,
                                                  package._rotation_w);
        icone.GetComponent<MovingToTheObjective>().initial_position = new Vector3(
                                                package.to_the_objective_save_package._initial_position_x,
                                                package.to_the_objective_save_package._initial_position_y,
                                                package.to_the_objective_save_package._initial_position_z);
        icone.GetComponent<MovingToTheObjective>().final_objective = new Vector3(
                                                package.to_the_objective_save_package._final_objective_x,
                                                package.to_the_objective_save_package._final_objective_y,
                                                package.to_the_objective_save_package._final_objective_z);
        icone.GetComponent<MovingToTheObjective>().time_to_reach_objective = package.to_the_objective_save_package.
            _time_to_reach_objective;
        icone.GetComponent<MovingToTheObjective>().passed_time = package.to_the_objective_save_package._passed_time;
        icone.GetComponent<MovingToTheObjective>().time_counted = package.to_the_objective_save_package.
            _time_counted;


        icone.name = package.name;

    }

    void InstantiateNewVFXWave(GameObject exit, GameObject entrance, float time_in_seconds,
            float scale = 1.0f)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("VFX Wave Object"));

        icone.transform.SetParent(GameObject.Find("WavesCanvas").transform);
        icone.transform.position = new Vector3(exit.transform.position.x,
                                               exit.transform.position.y,
                                               exit.transform.position.z);
        Vector3 final_obj = entrance.transform.position;
        final_obj.z = 0;
        icone.GetComponent<MovingToTheObjective>().final_objective = final_obj;
        icone.GetComponent<MovingToTheObjective>().time_to_reach_objective = time_in_seconds;
        icone.name = "VFX Wave";
        icone.name += " Wave - ID " + nextWaveId;
        icone.tag = "VFX";
        nextWaveId++;
        waves_sent++;
    }

    public void RandomInstantaneousVFXWaveInstance(float time_in_seconds, bool super_wave = false)
    {
        GameObject exit, entrance;
        //Year 1: between 30 to 60 seconds.
        //Year 2: between 15 to 30 seconds.
        float scale = 1.0f;

        //Superwave: 750 to 1000 refugees, between 150 to 300 seconds. Sprite 3x bigger.

        if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f)
        {
            exit = refugees_exit_1; entrance = refugees_entrance_1;
        }
        else
        {
            exit = refugees_exit_2; entrance = refugees_entrance_2;
        }

        InstantiateNewVFXWave(exit, entrance, time_in_seconds, scale);
    }

    public bool DeleteAllVFX()
    {
        GameObject[] list_of_waves;
        list_of_waves = GameObject.FindGameObjectsWithTag("VFX");

        int quantity = list_of_waves.Length;

        for (int i = quantity - 1; i >= 0; i--)
        {
            Destroy(list_of_waves[i]);
        }

        list_of_waves = GameObject.FindGameObjectsWithTag("VFX");
        if (list_of_waves.Length == 0) return true;
        else return false;
    }

    void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    // Use this for initialization
    void Start()
    {
        vfx_wave_launcher_save_package = new SFXWaveLauncherSavePackage();
        time_for_next = UnityEngine.Random.Range(30.0f, 60.0f);
        last_time = TimerManager.time;
        if (first_part_of_avoiding_spontaneous_wave_launching_at_start)
        {
            second_part_of_avoiding_spontaneous_wave_launching_at_start = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((!TimeManager.instance.gamePaused) && (wave_instantiation_timer))
        {
            if (TimerManager.instance.timer_manager_started)
            {
                if ((first_part_of_avoiding_spontaneous_wave_launching_at_start) &&
                    (second_part_of_avoiding_spontaneous_wave_launching_at_start))
                {
                    last_time = TimerManager.time;
                    present_time = 0.0f;
                    first_part_of_avoiding_spontaneous_wave_launching_at_start = false;
                    second_part_of_avoiding_spontaneous_wave_launching_at_start = false;
                }
                else
                {
                    present_time += TimerManager.time - last_time;
                    last_time = TimerManager.time;
                }
            }

            if (present_time >= time_for_next)
            {
                float random_value = UnityEngine.Random.Range(3.0f, 4.0f);
                RandomInstantaneousVFXWaveInstance(random_value, false);
                present_time = 0.0f;
                if (TimeManager.instance.year == 1)
                {
                    time_for_next = UnityEngine.Random.Range(5.0f, 10.0f);
                }
                else
                {
                    time_for_next = UnityEngine.Random.Range(5.0f, 7.0f);
                }
            }
        }
    }

    void onSceneLoaded(Scene scene, LoadSceneMode load_scene_mode)
    {
        if (SceneManager.GetActiveScene().name.Equals("Main Scene"))
        {
            first_part_of_avoiding_spontaneous_wave_launching_at_start = true;
            Debug.Log(first_part_of_avoiding_spontaneous_wave_launching_at_start);
        }
    }
}