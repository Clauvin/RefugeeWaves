using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkipMcGyverism : MonoBehaviour {

	// Use this for initialization
	void Start () {

        TimeManager.PauseOrUnpause();
        IfPausedShowsElseDont.TogglePause();
        PauseButtonsManager.EraseSaveLoad();

    }
	
}
