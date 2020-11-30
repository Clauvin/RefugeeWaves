using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLobbyMusicOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicManager.instance.PlayLobbyMusic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
