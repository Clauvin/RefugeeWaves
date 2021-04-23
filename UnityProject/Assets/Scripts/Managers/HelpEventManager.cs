using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpEventManager : MonoBehaviour {

	public List<GameObject> helpEvents;

	public GameObject helpEventPrefab;

	public static HelpEventManager instance;
	static public void CreateHelpEvents()
	{

	}
	public void AHelpEventHappens(int which_one)
	{
		TimeManager.instance.pauseGame();
		helpEvents[which_one].SetActive(true);
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
	}

	// Update is called once per frame
	void Update () {

	}
}
