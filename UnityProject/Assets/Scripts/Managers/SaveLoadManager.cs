using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

    public static SaveLoadManager instance;

    public bool Save()
    {
        return PersistenceManager.saveGame();
    }

    public bool Load()
    {
        return PersistenceManager.loadGame();
    }

    // Use this for initialization
    void Start () {

        instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
