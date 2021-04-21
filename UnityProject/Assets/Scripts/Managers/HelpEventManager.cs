using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpEventManager : MonoBehaviour {

	public List<HelpEvent> helpEvents;

	public GameObject helpEventPrefab;

	public static HelpEventManager instance;
	static public void CreateHelpEvents()
	{
		instance.helpEvents.Add(new HelpEvent("Creation of Public Works", "Public works need people to work on them, and that reduces " +
			"unemployment."));
		instance.helpEvents.Add(new HelpEvent("Creation of Edicts for Start-Ups", "Start-ups need people to work on them," +
			" and that reduces unenployment and raises the economy."));
		instance.helpEvents.Add(new HelpEvent("Investments in Public Security", "Public security measures reduce criminality."));
		instance.helpEvents.Add(new HelpEvent("Get International Help", "Given the refugee crisis, international help" +
			" can be a boon. How much of a boon it will be depends of the public opinion about Ondestão."));
		instance.helpEvents.Add(new HelpEvent("Create Campaing In Favour Of Ondestão", "In this case, in favour of Ondestão " +
			"and against refugees."));
	}
	public void AHelpEventHappens(int which_one)
	{
		//For Debug purposes
		Debug.Log("Event Happened.");
		Debug.Log("Title: " + instance.helpEvents[which_one].name);

		//since event happened, need to show its popup
		createVisualHelpEvent(instance.helpEvents[which_one].name, instance.helpEvents[which_one].description);

	}

	void createVisualHelpEvent(string name, string description)
    {
		TimeManager.instance.pauseGame();

		GameObject newEvent = (GameObject)Instantiate(instance.helpEventPrefab);

		//make it a child of the MainCanvas and adjust its scale
		newEvent.transform.SetParent(GameObject.Find("WindowsCanvas").transform, false);
		newEvent.name = "Help Event Window";

		//change the values of the text boxes
		newEvent.transform.Find("HelpEventPanel/EventTitle").GetComponent<Text>().text = name;
		newEvent.transform.Find("HelpEventPanel/EventDescription").GetComponent<Text>().text = description;
	}

	// Use this for initialization
	void Start()
	{
		instance = this;
		instance.helpEvents = new List<HelpEvent>();
		CreateHelpEvents();

	}

	// Update is called once per frame
	void Update () {

	}
}
