using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaveJingleOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicManager.instance.PlayWaveJingle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
