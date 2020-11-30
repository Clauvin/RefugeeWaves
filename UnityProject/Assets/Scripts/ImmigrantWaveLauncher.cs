using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Creates an instance of a Immigrant Wave Object, with:
///     a) Number of immigrants; (semi randomized based in values)
///     b) Instance creation point
///     c) Finish point
///     d) Speed to reach
/// </summary>
public class ImmigrantWaveLauncher : MonoBehaviour {

    public static ImmigrantWaveLauncher instance;
    public bool first_part_of_avoiding_spontaneous_wave_launching_at_start;
    public bool second_part_of_avoiding_spontaneous_wave_launching_at_start;

    #region Spawn Points and Spawn Objectives
    public GameObject refugees_exit_1, refugees_exit_2;
    public GameObject refugees_entrance_1, refugees_entrance_2;
    #endregion

    public float size_of_wave_difficult_multiplier = 1.0f;
    public float time_difficult_multiplier = 1.0f;

    [Serializable]
    public class ImmigrantWaveLauncherSavePackage
    {
        public int _nextWaveId = 0;
        public int _waves_sent = 0;

        #region Public Variables
        public float _present_time = 0.0f;
        public float _last_time;
        public float _time_for_next = 0.0f;
        public int _def_quant_of_refugees = 5;
        public float _def_time_in_seconds = 30.0f;
        public float _refugees_multiplier = 2.5f; // this number multiplies the number of refugees in each new wave
        #endregion

        public bool _wave_instantiation_timer = true;
    }

    /// <summary>
    /// Set this to public for debugging in the editor
    /// </summary>
    public ImmigrantWaveLauncherSavePackage immigrant_wave_launcher_save_package;

    public ImmigrantWaveLauncherSavePackage GetImmigrantWaveLauncherSavePackage()
    {
        return immigrant_wave_launcher_save_package;
    }

    public void SetImmigrantWaveLauncherSavePackage(ImmigrantWaveLauncherSavePackage save_package)
    {
        immigrant_wave_launcher_save_package = save_package;
    }

    public int nextWaveId {
        get { return immigrant_wave_launcher_save_package._nextWaveId; }
        set { immigrant_wave_launcher_save_package._nextWaveId = value; }
    }

    public int waves_sent {
        get { return immigrant_wave_launcher_save_package._waves_sent; }
        set { immigrant_wave_launcher_save_package._waves_sent = value; }
    }

    #region Public Variables
    public float present_time {
        get { return immigrant_wave_launcher_save_package._present_time; }
        set { immigrant_wave_launcher_save_package._present_time = value; }
    }

    public float last_time {
        get { return immigrant_wave_launcher_save_package._last_time; }
        set { immigrant_wave_launcher_save_package._last_time = value; }
    }

    public float time_for_next {
        get { return immigrant_wave_launcher_save_package._time_for_next; }
        set { immigrant_wave_launcher_save_package._time_for_next = value; }
    }

    public int def_quant_of_refugees {
        get { return immigrant_wave_launcher_save_package._def_quant_of_refugees; }
        set { immigrant_wave_launcher_save_package._def_quant_of_refugees = value; }
    }

    public float def_time_in_seconds {
        get { return immigrant_wave_launcher_save_package._def_time_in_seconds; }
        set { immigrant_wave_launcher_save_package._def_time_in_seconds = value; }
    }

    public float refugees_multiplier {
        get { return immigrant_wave_launcher_save_package._refugees_multiplier; }
        set { immigrant_wave_launcher_save_package._refugees_multiplier = value; }
    }
    #endregion

    private bool wave_instantiation_timer {
        get { return immigrant_wave_launcher_save_package._wave_instantiation_timer; }
        set { immigrant_wave_launcher_save_package._wave_instantiation_timer = value; }
    }

    #region Instantiation Timer Functions
    public bool GetWaveInstantiationTimer() { return wave_instantiation_timer; }

    public void SetWaveInstantiationTimer(bool wit) { wave_instantiation_timer = wit; }

    public void ToggleWaveInstantiationTimer() { wave_instantiation_timer = !wave_instantiation_timer; }
    #endregion

    public void InstantiateNewRefugeWave(GameInstance.WaveObjectSavePackage package)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Immigrant Wave Object"));
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
        icone.GetComponent<ImmigrantWave>().SetImmigrantWaveSavePackage(package.immigrant_wave_save_package);
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

    void InstantiateNewRefugeeWave(int refugee_quantity, GameObject exit, GameObject entrance, float time_in_seconds,
            float scale = 1.0f)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Immigrant Wave Object"));

        icone.transform.SetParent(GameObject.Find("WavesCanvas").transform);
        icone.transform.position = new Vector3(exit.transform.position.x,
                                               exit.transform.position.y,
                                               exit.transform.position.z);
        icone.GetComponent<ImmigrantWave>().numberOfImmigrants = refugee_quantity;
        Vector3 final_obj = entrance.transform.position;
        final_obj.z = 0;
        icone.GetComponent<MovingToTheObjective>().final_objective = final_obj;
        icone.GetComponent<MovingToTheObjective>().time_to_reach_objective = time_in_seconds;
        icone.name = "Refugee";
        if (scale > 1.0f)
        {
            icone.transform.localScale = new Vector3(icone.transform.localScale.x * scale,
                                                     icone.transform.localScale.y * scale,
                                                     1);
            icone.name += " Super";
        }
        icone.name += " Wave - ID " + nextWaveId;
        icone.tag = "Wave";
        nextWaveId++;
        waves_sent++;
    }

    public void RandomInstantaneousWaveInstance(bool super_wave = false)
    {
        int refugee_quantity;
        //Year 1: 50 to 150 refugees per wave.
        //Year 2: 150 to 200 refugees per wave.
        GameObject exit, entrance;
        float time_in_seconds;
        //Year 1: between 30 to 60 seconds.
        //Year 2: between 15 to 30 seconds.
        float scale = 1.0f;

        //Superwave: 750 to 1000 refugees, between 150 to 300 seconds. Sprite 3x bigger.

        if ((TimeManager.instance.year == 1) && (!super_wave))
        {
            refugee_quantity = (int)(UnityEngine.Random.Range(1.0f, 2.0f) * def_quant_of_refugees *
                size_of_wave_difficult_multiplier) + waves_sent;
            time_in_seconds = UnityEngine.Random.Range(1.0f, 2.0f) * def_time_in_seconds *
                time_difficult_multiplier - waves_sent;
        }
        else if ((UnityEngine.Random.Range(0.0f, 1.0f) < 0.05f) || (super_wave))
        {
            refugee_quantity = (int)(UnityEngine.Random.Range(15.0f, 20.0f) * def_quant_of_refugees *
                size_of_wave_difficult_multiplier);
            time_in_seconds = UnityEngine.Random.Range(5.0f, 10.0f) * def_time_in_seconds *
                time_difficult_multiplier;
            scale *= 3;
        }
        else
        {
            refugee_quantity = (int)(UnityEngine.Random.Range(3.0f, 4.0f) * def_quant_of_refugees *
                size_of_wave_difficult_multiplier) + waves_sent;
            time_in_seconds = UnityEngine.Random.Range(0.5f, 1.0f) * def_time_in_seconds *
                time_difficult_multiplier - waves_sent;
        }

        if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f)
        {
            exit = refugees_exit_1; entrance = refugees_entrance_1;
        } else
        {
            exit = refugees_exit_2; entrance = refugees_entrance_2;
        }

        refugee_quantity = (int)(refugee_quantity * refugees_multiplier);

        if (refugee_quantity >= 15.0f * def_quant_of_refugees)
        {
            scale *= 2;
        }

        InstantiateNewRefugeeWave(refugee_quantity, exit, entrance, time_in_seconds, scale);
    }

    public bool DeleteAllTravellingWaves()
    {
        GameObject[] list_of_waves;
        list_of_waves = GameObject.FindGameObjectsWithTag("Wave");

        int quantity = list_of_waves.Length;

        for (int i = quantity - 1; i >= 0; i--)
        {
            Destroy(list_of_waves[i]);
        }

        list_of_waves = GameObject.FindGameObjectsWithTag("Wave");
        if (list_of_waves.Length == 0) return true;
        else return false;
    }

    void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    // Use this for initialization
    void Start () {
        immigrant_wave_launcher_save_package = new ImmigrantWaveLauncherSavePackage();
        time_for_next = UnityEngine.Random.Range(30.0f, 60.0f);
        last_time = TimerManager.time;
        if (first_part_of_avoiding_spontaneous_wave_launching_at_start)
        {
            second_part_of_avoiding_spontaneous_wave_launching_at_start = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
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
                RandomInstantaneousWaveInstance();
                present_time = 0.0f;
                if (TimeManager.instance.year == 1)
                {
                    time_for_next = UnityEngine.Random.Range(30.0f, 60.0f) - waves_sent;
                }
                else
                {
                    time_for_next = UnityEngine.Random.Range(15.0f, 30.0f);
                }
            }
        }
	}

    void onSceneLoaded(Scene scene, LoadSceneMode load_scene_mode)
    {
        Debug.Log("Hum");
        if (SceneManager.GetActiveScene().name.Equals("Main Scene"))
        {
            Debug.Log("Hum 2");
            first_part_of_avoiding_spontaneous_wave_launching_at_start = true;
            Debug.Log(first_part_of_avoiding_spontaneous_wave_launching_at_start);
        }
    }
}
