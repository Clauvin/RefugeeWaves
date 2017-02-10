using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGO : MonoBehaviour {

	public void PressedOKEventButton()
	{
		//method runs when player hits 'OK' button on the Random Event Popup
		//since Popup pauses the game, it needs to be unpaused
		TimeManager.instance.unpauseGame();

		//Destroy this Random Event Popup
		Destroy(this.gameObject);

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
