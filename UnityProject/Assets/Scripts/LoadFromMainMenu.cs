using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromMainMenu : MonoBehaviour {

    public bool only_once = false;

    public void Loading()
    {
        if ((only_once) && (ResourceManager.instance != null) && (TimeManager.instance != null)
            && (TimerManager.instance != null) && (StatsManager.instance != null) && (CommerceManager.instance != null)
            && (ImmigrantManager.instance != null) && (ImmigrantWaveLauncher.instance != null)
            && (RandomEventManager.instance != null) && (ImmigrantManager.instance != null)
            && (ImmigrantWaveLauncher.instance != null) && (ActionsManager.instance != null))
        {
            if (PersistenceManager.loadGame())
            {
                only_once = false;
                DestroyObject(this.gameObject);
            }
            else
            {
                Debug.Log("Loading bugged.");
                only_once = false;
                DestroyObject(this.gameObject);
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Loading();
	}
}
