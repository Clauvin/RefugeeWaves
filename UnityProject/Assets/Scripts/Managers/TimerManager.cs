using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class TimerManager : MonoBehaviour {

    #region Public Variables
    public static TimerManager instance;

    public static float time{
        get { return actual_time; }
        private set { actual_time = value; }
    }
    #endregion

    public class TimerSavePackage
    {
        public float _actual_time;
        public float _last_time;
    }

    public static TimerSavePackage timer_save_package;

    public static float actual_time
    {
        get { return timer_save_package._actual_time;  }
        set { timer_save_package._actual_time = value; }
    }

    public static float last_time
    {
        get { return timer_save_package._last_time; }
        set { timer_save_package._last_time = value; }
    }

    public static void LoadPackage(TimerSavePackage t_s_p)
    {
        timer_save_package = t_s_p;
        last_time = Time.time;
    }


    // Use this for initialization
    void Start () {
        instance = this;
        actual_time = 0;
        last_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (!TimeManager.instance.gamePaused)
        {
            actual_time += Time.time - last_time;
            last_time = Time.time;
        } else
        {
            last_time = Time.time;
        }
	}
}
