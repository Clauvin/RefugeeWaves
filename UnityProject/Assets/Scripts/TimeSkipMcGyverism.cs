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
        }



    }
	
}
