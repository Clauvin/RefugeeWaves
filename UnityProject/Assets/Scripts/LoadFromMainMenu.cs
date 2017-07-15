using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromMainMenu : MonoBehaviour {

    public bool only_once = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (only_once)
        {
            if (PersistenceManager.loadGame())
            {
                only_once = false;
                Destroy(this);
            }
            else
            {
                Debug.Log("Loading bugged.");
                only_once = false;
                Destroy(this);
            }
        }

	}
}
