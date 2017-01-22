using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Saves Random Events and checks to see if they happen
public class RandomEventManager : MonoBehaviour {

	public static RandomEventManager instance;

	List<RandomEvent> randomEvents = new List<RandomEvent>();


	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
