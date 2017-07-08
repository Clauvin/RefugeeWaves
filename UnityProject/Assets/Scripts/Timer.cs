using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Possible script to make company to the Basics library.
/// Is responsible for being a timer for other functions.
/// </summary>
public class Timer : MonoBehaviour {

    public int time = 100;

    private float time_passed = 0.0f;
    private float start_time = 0.0f;

	// Use this for initialization
	void Start () {
        start_time = TimerManager.time;
	}
	
	// Update is called once per frame
	void Update () {

        time_passed += TimerManager.time - start_time;
        start_time = TimerManager.time;
        while (time_passed >= 1.0f)
        {
            time -= 1;
            time_passed -= 1.0f;
        }

	}
}
