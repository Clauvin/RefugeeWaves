using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkipMcGyverism : MonoBehaviour {

    public GameObject pause_button_manager;

    private bool mcgyverism_1 = true;

	// Use this for initialization
	void Update () {

        if ((TimeManager.instance != null) && (mcgyverism_1)) {
            TimeManager.instance.PauseOrUnpause();
            GetComponent<IfPausedShowsElseDont>().TogglePause();
            pause_button_manager.GetComponent<PauseButtonsManager>().EraseSaveLoadText();
            mcgyverism_1 = false;

            if (TimeManager.instance.year == 1 && TimeManager.instance.month == 1 && TimeManager.instance.week == 1)
            {
                TimeManager.instance.timeElapsed = 0.0f;
                TimeManager.instance.timeLastPaused = 0.0f;
                TimeManager.instance.timeLastUnpaused = 0.0f;
            }
        }

    }
	
}
