using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEventManager : MonoBehaviour {

	public List<HelpEvent> helpEvents;

	public GameObject helpEventPrefab;

	public static HelpEventManager instance;
	public void CreateHelpEvents()
	{
		helpEvents.Add(new HelpEvent("Creation of Public Works", "Public works need people to work on them, and that reduces " +
			"unemployment."));
		helpEvents.Add(new HelpEvent("Creation of Edicts for Start-Ups", "Start-ups need people to work on them," +
			" and that reduces unenployment and raises the economy."));
		helpEvents.Add(new HelpEvent("Investments in Public Security", "Public security measures reduce criminality."));
		helpEvents.Add(new HelpEvent("Get International Help", "Given the refugee crisis, international help" +
			" can be a boon. How much of a boon it will be depends of the public opinion about Ondestão."));
		helpEvents.Add(new HelpEvent("", ""));
		helpEvents.Add(new HelpEvent("", ""));
		helpEvents.Add(new HelpEvent("", ""));


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
