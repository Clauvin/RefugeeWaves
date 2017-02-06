using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Saves Random Events and checks to see if they happen
public class RandomEventManager : MonoBehaviour {

	public static RandomEventManager instance;

	List<RandomEvent> randomEvents = new List<RandomEvent>();
	List<bool> randomEventsHappened = new List<bool>();//stores a bool that'll say whether the associated event already happened



	//creates them all
	public void CreateRandomEvents ()
	{

	}

	//every week, this needs to be checked
	public void CheckForRandomEvents()
	{



	}

	// Use this for initialization
	void Start () {
		instance = this;
		CreateRandomEvents ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
