using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

    public static SaveLoadManager instance;

    public void Save()
    {
        PersistenceManager.saveGame();
    }

    // Use this for initialization
    void Start () {

        instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
