using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StatsManager : MonoBehaviour {


	public static StatsManager instance;


	//Creates all global variables to be used by the Minister of Wavestan

	public int legalPopulation;//how many legal, tax paying ppl are living in your country atm

	public double publicOpinionOnImmigrants; //goes from 0 to 1
	public double internationalOpinion; //goes from 0 to 1, affects your chances of getting international help

	public double unemployementRate; //from 0 to 1(if 1, boy, are you screwed)
	public double criminalityRate; //from 0 to 1(if 1, boy, are you dead)

    //GO's, Text, Sliders...

    public GameObject legalPopulationGO, publicOpinionOnImmigrantsGO, internationalOpinionGO;
    public GameObject unemployementRateGO, criminalityRateGO;

    Text legalPopulationText;
    Slider publicOpinionOnImmigrantsSlider, internationalOpinionSlider;
    Text unemployementRateText, criminalityRateText;

    public void randomizeStartingStats()
	{
		//randomizes values of the starting stats
		//TODO
		legalPopulation = 80000 + (int)(40000 * Random.value);//from 80k to 120k
		unemployementRate = 0.04 + 0.04 * Random.value;//from 4% to 8%
		criminalityRate = 0.02 + 0.02*Random.value; //from 2% to 4%
		publicOpinionOnImmigrants = 0.3 + 0.4*Random.value;//from 30% to 70%
		internationalOpinion = 0.5 + 0.2*Random.value;//from 50% to 70%
	}

	//Used when month ends, recalculates all values based on current values
	public void calculateStatsValues()
	{
		//TODO: Get EXACTLY how each variable affects the other


	}

    public void UpdateFrontLegalPopulation() {

        legalPopulationText.text = legalPopulation.ToString();

    }

    public void UpdateFrontPublicOpinionOnImmigrantsGO() {

        publicOpinionOnImmigrantsSlider.value = (float)publicOpinionOnImmigrants;

    }

    public void UpdateFrontInternationalOpinionGO() {

        internationalOpinionSlider.value = (float)internationalOpinion;

    }

    public void UpdateFrontUnemployementRateGO() {

        unemployementRateText.text = System.Math.Round(unemployementRate*100, 1).ToString() + "%";

    }

    public void UpdateFrontCriminalityRateGO() {

        criminalityRateText.text = System.Math.Round(criminalityRate * 100, 1).ToString() + "%";


    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		randomizeStartingStats ();

        legalPopulationText = legalPopulationGO.GetComponent<Text>();
        publicOpinionOnImmigrantsSlider = publicOpinionOnImmigrantsGO.GetComponent<Slider>();
        internationalOpinionSlider = internationalOpinionGO.GetComponent<Slider>();
        unemployementRateText = unemployementRateGO.GetComponent<Text>();
        criminalityRateText = criminalityRateGO.GetComponent<Text>();
}
	
	// Update is called once per frame
	void Update () {
        UpdateFrontLegalPopulation();
        UpdateFrontPublicOpinionOnImmigrantsGO();
        UpdateFrontInternationalOpinionGO();
        UpdateFrontUnemployementRateGO();
        UpdateFrontCriminalityRateGO();
    }
}
