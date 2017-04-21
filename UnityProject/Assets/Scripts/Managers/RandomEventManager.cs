using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Saves Random Events and checks to see if they happen
public class RandomEventManager : MonoBehaviour {

	public static RandomEventManager instance;

	List<RandomEvent> randomEvents = new List<RandomEvent>();//holds all events
	List<RandomEvent> eventsYetToHappen = new List<RandomEvent>();//starts as a copy of all events; gets smaller as events happen

	public GameObject randomEventPrefab;

	//creates them all
	public void CreateRandomEvents ()
	{
		randomEvents.Add(new RandomEvent("Your mom called!", "Your mom is worried sick about you for never calling her!"+
			"She nagged you on the phone so much, you missed an important call about some clandestine refugees" +
            " wreaking havok in the capital."+
			"\nConsequence: Criminality Rate +10%",MiscInfo.variableTypes.criminalityRate,0.1f));

        randomEvents.Add(new RandomEvent("Interstellar war", "The until now unknown planet of Ondesterra entered in a" +
            " World War, and their habitants are looking for a batter place to live." + 
            " Thanks to the strong cosmic rays, they are being forced to arrive... in the Guerrestão." +
            " Prepare yourself for more refugees. A lot of them." +
            "\nConsequence: Refugee Waves sizes x3", MiscInfo.variableTypes.criminalityRate, 0.1f));

        randomEvents.Add(new RandomEvent("Chemical Weapons", "The Guerrestão's government crossed a line and used" +
            " chemical weapons in civilian areas. The damages inflicted in the population plus such weapons being" +
            " banned by the United Nations since decades ago made two things: first, more Guerrestão citzens are" +
            " considering leaving their country. Second, the United Nations are mobilizing to help countries" +
            " dealing with the crisis." +
            "\nConsequence: Refugees coming +25%, more money from UN", MiscInfo.variableTypes.criminalityRate, 0.1f));

        randomEvents.Add(new RandomEvent("The world acts", "Impressed with the crisis size, the countries started" +
            " mobilizing themselves to receive refugees in their territories. This increases the travelling options" +
            " of the people, who don't need so much to pass by or stay in Ondestão to be safe." +
            "\nConsequence: Refugees coming -25%", MiscInfo.variableTypes.criminalityRate, 0.1f));

        randomEvents.Add(new RandomEvent("But almost nobody came", "Fear, untrust and prejudice, by now, surpassed" +
            " hope and kindness. In this refugee crisis, the other countries prefer not to help. It's up now to the" +
            " few countries that keep their borders open to who need them." +
            "\nConsequence: Refugees coming +25%", MiscInfo.variableTypes.criminalityRate, 0.1f));

        //in the end of the creation, make a copy at eventsYetToHappen
        eventsYetToHappen = randomEvents;
	}

	public void createVisualRandomEvent(string title, string description)
	{
		//intantiates the GO associated with this Random Event in the middle of the screen, pauses game
		//must pause game at this point
		TimeManager.instance.pauseGame();


		//instantiates a prefab with the info of the event
		GameObject newEvent = (GameObject)Instantiate(randomEventPrefab);

		//make it a child of the MainCanvas and adjust its scale
		newEvent.transform.SetParent(GameObject.Find("MainCanvas").transform,false);
		//newEvent.transform.localScale = new Vector3 (1, 1, 1);

		//change the values of the text boxes
		newEvent.transform.Find ("RandomEventPanel/EventTitle").GetComponent<Text>().text = title;
		newEvent.transform.Find ("RandomEventPanel/EventDescription").GetComponent<Text>().text = description;

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

			//For Debug purposes
			Debug.Log("Event Happened.");
			Debug.Log ("Title: " + eventsYetToHappen [eventToHappen].name);


			//since event happened, need to show its popup
			createVisualRandomEvent(eventsYetToHappen[eventToHappen].name, eventsYetToHappen[eventToHappen].description);


			//remove it from the list
			eventsYetToHappen.RemoveAt(eventToHappen);


		}

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
