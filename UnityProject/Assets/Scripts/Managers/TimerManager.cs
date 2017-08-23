using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerManager : MonoBehaviour {

    #region Public Variables
    public static TimerManager instance;

    private float t1 = 0.0f;
    private float t2 = 0.0f;

    public static float time{
        get { return actual_time; }
        private set { actual_time = value; }
    }
    #endregion

    [Serializable()]
    public class TimerSavePackage
    {
        public float _actual_time;
        public float _last_time;
    }

    /// <summary>
    /// Set this to public for debugging in the editor
    /// </summary>
    private static TimerSavePackage timer_save_package;

    public float the_time;
    public float the_last_time;

    public static float actual_time
    {
        get { return timer_save_package._actual_time; }
        set { timer_save_package._actual_time = value; }
    }

    public static float last_time
    {
        get { return timer_save_package._last_time; }
        set { timer_save_package._last_time = value; }
    }

    public static void LoadPackage(TimerSavePackage t_s_p)
    {
        instance.SetTimerSavePackage(t_s_p);
        last_time = TimerManager.time;
    }

    public TimerSavePackage GetTimerSavePackage()
    {
        return timer_save_package;
    }

    public void SetTimerSavePackage(TimerSavePackage t_s_p)
    {
        timer_save_package = t_s_p;
        the_time = timer_save_package._actual_time;
        the_last_time = timer_save_package._last_time;
    }

    private float TimeDifference()
    {
        float result = 0.0f; 
        if (!TimeManager.instance.gamePaused)
        {
            t1 = Time.time;
            result = t1 - t2;
        }
        else
        {
            t1 = t2 = Time.time;
        }
        
        t2 = t1;
        return result;
    }

    public void AdjustTimeDifference()
    {
        t1 = t2 = Time.time;
    }

    TimerManager()
    {

    }

    // Use this for initialization
    void Awake () {
        instance = this;
        timer_save_package = new TimerSavePackage();
        actual_time = -10; // Yes, this is a McGuyverism.
        last_time = TimerManager.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (!TimeManager.instance.gamePaused)
        {
            actual_time += TimeDifference();
        }
        the_time = actual_time;
        the_last_time = last_time;
	}
}
