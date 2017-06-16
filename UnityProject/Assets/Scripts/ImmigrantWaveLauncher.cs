using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmigrantWaveLauncher : MonoBehaviour {

    /// <summary>
    /// Creates an instance of a Immigrant Wave Object, with:
    ///     a) Number of immigrants; (semi randomized based in values)
    ///     b) Instance creation point
    ///     c) Finish point
    ///     d) Speed to reach
    /// </summary>

    public static ImmigrantWaveLauncher instance;

    public int nextWaveId = 0;

    #region Spawn Points and Spawn Objectives
    public GameObject refugees_exit_1, refugees_exit_2;
    public GameObject refugees_entrance_1, refugees_entrance_2;
    #endregion

    #region Public Variables
    public float present_time = 0.0f;
    public float last_time;
    public float time_for_next = 0.0f;
    public int def_quant_of_refugees = 50;
    public float def_time_in_seconds = 30.0f;
    public float refugees_multiplier = 1.0f; // this number multiplies the number of refugees in each new wave
    #endregion

    private bool wave_instantiation_timer = true;

    #region Instantiation Timer Functions
    public bool GetWaveInstantiationTimer() { return wave_instantiation_timer; }

    public void SetWaveInstantiationTimer(bool wit) { wave_instantiation_timer = wit; }

    public void ToggleWaveInstantiationTimer() { wave_instantiation_timer = !wave_instantiation_timer; }
    #endregion

    void InstantiateNewRefugeeWave(int refugee_quantity, GameObject exit, GameObject entrance, float time_in_seconds,
            float scale = 1.0f)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Immigrant Wave Object"));

        icone.transform.SetParent(GameObject.Find("WavesCanvas").transform);
        icone.transform.position = new Vector3(exit.transform.position.x,
                                               exit.transform.position.y,
                                               exit.transform.position.z);
        icone.GetComponent<ImmigrantWave>().numberOfImmigrants = refugee_quantity;
        icone.GetComponent<MovingToTheObjective>().final_objective = entrance.transform.position;
        icone.GetComponent<MovingToTheObjective>().final_objective.z = 0;
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
        nextWaveId++;
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
            refugee_quantity = (int)(Random.Range(1.0f, 2.0f) * def_quant_of_refugees);
            time_in_seconds = Random.Range(1.0f, 2.0f) * def_time_in_seconds;
        }
        else if ((Random.Range(0.0f, 1.0f) < 0.05f) || (super_wave))
        {
            refugee_quantity = (int)(Random.Range(15.0f, 20.0f) * def_quant_of_refugees);
            time_in_seconds =  Random.Range(5.0f, 10.0f) * def_time_in_seconds;
            scale *= 3;
        }
        else
        {
            refugee_quantity = (int)(Random.Range(3.0f, 4.0f) * def_quant_of_refugees);
            time_in_seconds = Random.Range(0.5f, 1.0f) * def_time_in_seconds;
        }

        if (Random.Range(0.0f, 1.0f) < 0.5f)
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

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        time_for_next = Random.Range(30.0f, 60.0f);
        last_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if ((!TimeManager.instance.gamePaused) && (wave_instantiation_timer))
        {
            present_time += Time.time - last_time;
            last_time = Time.time;

            if (present_time >= time_for_next)
            {
                RandomInstantaneousWaveInstance();
                present_time = 0.0f;
                if (TimeManager.instance.year == 1)
                {
                    time_for_next = Random.Range(30.0f, 60.0f);
                }
                else
                {
                    time_for_next = Random.Range(15.0f, 30.0f);
                }
            }
        }
	}
}
