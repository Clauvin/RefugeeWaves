using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {


	public static StatsManager instance;


	//Creates all global variables to be used by the Minister of Wavestan

	//Visible variables(to the player)

	public int legalPopulation;//how many legal, tax paying ppl are living in your country atm

	public float publicOpinionOnImmigrants; //goes from 0 to 1
	public float internationalOpinion; //goes from 0 to 1, affects your chances of getting international help

	public float unemployementRate; //from 0 to 1(if 1, boy, are you screwed)
	public float criminalityRate; //from 0 to 1(if 1, boy, are you dead)




	//Used when month ends, recalculates all values based on current values
	public void recalculateValues()
	{
		//TODO: Get EXACTLY how each variable affects the other

	}

	// Use this for initialization
	void Start () {
		instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
