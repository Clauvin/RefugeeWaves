using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class TimerManager : MonoBehaviour {

    #region Public Variables
    public static ActionsManager instance;
    #endregion 

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
