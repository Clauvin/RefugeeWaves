using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Saves Random Events and checks to see if they happen
public class RandomEventManager : MonoBehaviour {

	public static RandomEventManager instance;

	List<RandomEvent> randomEvents = new List<RandomEvent>();//holds all events
	List<RandomEvent> eventsYetToHappen = new List<RandomEvent>();//starts as a copy of all events; gets smaller as events happen


	//creates them all
	public void CreateRandomEvents ()
	{
		//TODO: Create Random Events


		//in the end of the creation, make a copy at eventsYetToHappen
		eventsYetToHappen = randomEvents;
	}

	//every week, this needs to be checked
	public void CheckForRandomEvents()
	{
		//for now, simple mechanism: every end of month this method has 10% chance of getting a random event;
		//if it gets one, choose one (that hasn't been chosen yet)
		int randomNum = Random.Range(1,100);//I know this isn't reaaaally random, TODO: Better ideas?

		if (randomNum <= 10 && eventsYetToHappen.Count>0)//within 10% && there are still events that haven't happened
		{
			//get one random event of the group and makes it happen
			int eventToHappen = Random.Range(0,eventsYetToHappen.Count-1);
			eventsYetToHappen [eventToHappen].applyConsequences ();

			//since event happened, need to show its popup
			eventsYetToHappen [eventToHappen].showEventPopup ();

			//remove it from the list
			eventsYetToHappen.RemoveAt(eventToHappen);


		}

	}

	public void PressedOKEventButton()
	{
		//method runs when player hits 'OK' button on the Random Event Popup
		//since Popup pauses the game, it needs to be unpaused
		TimeManager.instance.unpauseGame();

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
