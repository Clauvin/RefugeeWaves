using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Saves Random Events and checks to see if they happen
public class RandomEventManager : MonoBehaviour {

    [System.Serializable]
    public class RandomEventSavePackage {

        public List<RandomEvent> _randomEvents = new List<RandomEvent>();
        public List<RandomEvent> _eventsYetToHappen = new List<RandomEvent>();
    }

    public RandomEventSavePackage random_event_save_package;

    //holds all events
    public List<RandomEvent> randomEvents {
        get { return random_event_save_package._randomEvents; }
        set { random_event_save_package._randomEvents = value; }
    }

    //starts as a copy of all events; gets smaller as events happen
    public List<RandomEvent> eventsYetToHappen
    {
        get { return random_event_save_package._eventsYetToHappen; }
        set { random_event_save_package._eventsYetToHappen = value; }
    }

    public GameObject randomEventPrefab;

    public static RandomEventManager instance;

    public RandomEventSavePackage GetRandomEventSavePackage()
    {
        return random_event_save_package;
    }

    public void SetRandomEventSavePackage(RandomEventSavePackage save_package)
    {
        random_event_save_package = save_package;
    }

    #region Creating Events
    //creates them all
    public void CreateRandomEvents ()
	{
		randomEvents.Add(new RandomEvent("Your mom called!", "Your mom is worried sick about you for never calling her!"+
			"She nagged you on the phone so much, you missed an important call about some clandestine refugees" +
            " wreaking havok in the capital."+
			"\nConsequence: Criminality Rate +10%",MiscInfo.variableTypes.criminalityRate,0.1f));

        randomEvents.Add(new RandomEvent("Interstellar war", "The until now unknown planet of Ondesterra entered in a" +
            " World War, and their habitants are looking for a batter place to live." + 
            " They are landing in the Guerrestão. ...prepare yourself for more refugees. A lot of them." +
            "\nConsequence: + 200% refugees", MiscInfo.variableTypes.waveVariation, 2.0f));

        //Need to be improved so Events change TWO or more fields.
        randomEvents.Add(new RandomEvent("Chemical Weapons", "The Guerrestão used" +
            " chemical weapons in civilian areas. The use of deadly banned weapons by the United Nations since decades" +
            "ago made more Guerrestão citzens consider leaving their country and the United Nations move." +
            "\nConsequence: + 25% refugees, more money from UN", MiscInfo.variableTypes.waveVariation, 0.25f,
            MiscInfo.variableTypes.unitedNationsHelpVariation, 1.0f));

        randomEvents.Add(new RandomEvent("The world acts", "Impressed with the crisis size, the countries started" +
            " mobilizing themselves to receive refugees in their territories. This increases the travelling options" +
            " of the people, who don't need so much to pass by or stay in Ondestão to be safe." +
            "\nConsequence: -25% refugees", MiscInfo.variableTypes.waveVariation, -0.25f));

        randomEvents.Add(new RandomEvent("But almost nobody came", "Fear, untrust and prejudice, by now, surpassed" +
            " hope and kindness. In this refugee crisis, the other countries prefer not to help. It's up now to the" +
            " few countries that keep their borders open to who need them." +
            "\nConsequence: Refugees coming +50%", MiscInfo.variableTypes.waveVariation, 0.50f));

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
		newEvent.transform.SetParent(GameObject.Find("WindowsCanvas").transform,false);
        newEvent.name = "Random Event Window";

		//change the values of the text boxes
		newEvent.transform.Find ("RandomEventPanel/EventTitle").GetComponent<Text>().text = title;
		newEvent.transform.Find ("RandomEventPanel/EventDescription").GetComponent<Text>().text = description;

	}
    #endregion

    //every week, this needs to be checked
    public void CheckForRandomEvents()
	{
		//for now, simple mechanism: every end of month this method has 10% chance of getting a random event;
		//if it gets one, choose one (that hasn't been chosen yet)
		int randomNum = Random.Range(1,100);//I know this isn't reaaaally random, TODO: Better ideas?

		if (randomNum <= 10 && eventsYetToHappen.Count>0)//within 10% && there are still events that haven't happened
		{
            AnEventHappens();
		}

	}

    //function to make an event show up
    public void AnEventHappens()
    {
        //get one random event of the group and makes it happen
        if (eventsYetToHappen.Count <= 0) return;
        int eventToHappen = Random.Range(0, eventsYetToHappen.Count - 1);
        eventsYetToHappen[eventToHappen].applyConsequences();

        //For Debug purposes
        Debug.Log("Event Happened.");
        Debug.Log("Title: " + eventsYetToHappen[eventToHappen].name);

        //since event happened, need to show its popup
        createVisualRandomEvent(eventsYetToHappen[eventToHappen].name, eventsYetToHappen[eventToHappen].description);

        //remove it from the list
        eventsYetToHappen.RemoveAt(eventToHappen);
    }

	// Use this for initialization
	void Start () {
		instance = this;
        random_event_save_package = new RandomEventSavePackage();
		CreateRandomEvents ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
