﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {


	public static StatsManager instance;

    #region Classe Para Salvar
    [System.Serializable]
    public class StatsSavePackage
    {
        public int _legalPopulation;
        public double _publicOpinionOnImmigrants;
        public double _internationalOpinion;
        public double _unemploymentRate;
        public double _criminalityRate;
    }
    #endregion

    /// <summary>
    /// Set this to public for debugging in the editor
    /// </summary>
    private StatsSavePackage stats_save_package;

    public StatsSavePackage GetStatsSavePackage()
    {
        return stats_save_package;
    }

    public void SetStatsSavePackage(StatsSavePackage r)
    {
        stats_save_package = r;
    }

    #region Global Variables
    //Creates all global variables to be used by the Minister of Wavestan

    public int legalPopulation {
        get { return stats_save_package._legalPopulation; }
        set { stats_save_package._legalPopulation = value; }
    }

    public double publicOpinionOnImmigrants {
        get { return stats_save_package._publicOpinionOnImmigrants; }
        set { stats_save_package._publicOpinionOnImmigrants = value; }
    }

	public double internationalOpinion {
        get { return stats_save_package._internationalOpinion; }
        set { stats_save_package._internationalOpinion = value; }
    }

	public double unemploymentRate {
        get { return stats_save_package._unemploymentRate; }
        set { stats_save_package._unemploymentRate = value; }
    }

	public double criminalityRate {
        get { return stats_save_package._criminalityRate; }
        set { stats_save_package._criminalityRate = value; }
    }
    #endregion

    #region GO - The UI GameObjects
    public GameObject legalPopulationGO, publicOpinionOnImmigrantsGO, internationalOpinionGO;
    public GameObject unemploymentRateGO, criminalityRateGO;
    #endregion

    #region The UI Texts
    Text legalPopulationText;
    Slider publicOpinionOnImmigrantsSlider, internationalOpinionSlider;
    Text unemployementRateText, criminalityRateText;
    #endregion

    public void randomizeStartingStats()
	{
		//randomizes values of the starting stats
		//TODO
		legalPopulation = 40000 + (int)(20000 * Random.value);//from 40k to 60k
		unemploymentRate = 0.04 + 0.04 * Random.value;//from 4% to 8%
		criminalityRate = 0.02 + 0.02*Random.value; //from 2% to 4%
		publicOpinionOnImmigrants = 0.3 + 0.4*Random.value;//from 30% to 70%
		internationalOpinion = 0.5 + 0.2*Random.value;//from 50% to 70%
	}

	//Used when month ends, recalculates all values based on current values
	public void calculateStatsValues()
	{
        //TODO: Get EXACTLY how each variable affects the other
        //TODO: If possible, that the immigrants becoming citizens
        // come BEFORE this calculations, when both happen in the same month

        //In order, starting of a value that doesn't end.

        //If + illegal immigrants, opinion about immigrants fall.
        //MAYBE: Reducing the public opinion by the percentage of immigrants/total population?
        //BYTHEWAY: magic number of illegal immigrants screwing the country by now: 10000
        if (ImmigrantManager.instance.numberOfIllegalImmigrants > 0)
        {
            publicOpinionOnImmigrants -= ImmigrantManager.instance.numberOfIllegalImmigrants * 0.005f;
            criminalityRate += ImmigrantManager.instance.numberOfIllegalImmigrants * 0.000005f;
        }

        //If border expenses < 0, crime 2x >
        //Yes, -10000 border resources = DOOM
        if (ResourceManager.instance.borderResources < 0)
            criminalityRate += ResourceManager.instance.borderResources * 0.01f * -1;

        //If taxes variation +, unemployment +
        if (ResourceManager.instance.taxVariation > 1.1)
            //unemploymentRate += (ResourceManager.instance.taxVariation - 1.1) * 50f;
            unemploymentRate += (ResourceManager.instance.taxVariation - 1.1) * 25f;

        //If taxes variation -, unemployment -
        if (ResourceManager.instance.taxVariation < 0.9)
            unemploymentRate -= (0.9 - ResourceManager.instance.taxVariation) * 50f;

        //If unemployment +, taxes variation -
        if (unemploymentRate > 0.1)
            ResourceManager.instance.taxVariation -= (unemploymentRate - 0.1) * 0.5;

        //If unemployment tax +, crime >
        if (unemploymentRate > 0.1)
            criminalityRate += (unemploymentRate - 0.1f) * 0.1f;

        //If unemployment tax -, crime <
        if (unemploymentRate < 0.1)
            criminalityRate -= (0.1 - unemploymentRate) * 0.1f;

        //If unemployment tax >, tax p/ citizen <
        if (unemploymentRate > 0.12)
            ResourceManager.instance.taxVariation -= unemploymentRate - 0.12;

        //If + crime, opinion about immigrants  -
        //Yes. A 20% crimeRate means a 5% fall in publicOpinion, a 30% crimeRate means a 15% fall, and so on.
        if (criminalityRate > 0.1)
            publicOpinionOnImmigrants -= (criminalityRate - 0.1) * 0.5;

        //If - crime, opinion about immigrants +
        if (criminalityRate < 0.04)
            publicOpinionOnImmigrants += (0.04 - criminalityRate);

        //If + crime, taxes variation over population -
        if (criminalityRate > 0.2)
            ResourceManager.instance.taxVariation -= (criminalityRate - 0.2)/5;

        //If taxes variation +, citizen tax +
        //If taxes variation -, citizen tax -
        //CALMA AÊ. Isso é uma consequência da equação, não é algo a ser calculado no fim do mês

        //If + taxes variation, opinion about immigrants -
        if (ResourceManager.instance.taxVariation > 1.1)
            publicOpinionOnImmigrants -= ResourceManager.instance.taxVariation - 1.1;

        //If + opinion about immigrants, international opinion +
        if (publicOpinionOnImmigrants < 0.3)
            internationalOpinion -= (0.3 - publicOpinionOnImmigrants) * 0.5;

        //If - opinion about immigrants, international opinion -
        if (publicOpinionOnImmigrants > 0.7)
            internationalOpinion += (publicOpinionOnImmigrants - 0.7) * 0.5;

        //If legal population +, budget +
        //If + taxes, budget +
        //If - taxes, budget -
        //If valor base +, budget +
        //If + budget, + money
        //If - budget, - money
        //All this is consequence of the calculations in ResourceManager.

        StatsLimitChecker();

    }

    public void StatsLimitChecker()
    {
        if (publicOpinionOnImmigrants < 0) publicOpinionOnImmigrants = 0;
        if (publicOpinionOnImmigrants > 1) publicOpinionOnImmigrants = 1;

        if (internationalOpinion < 0) internationalOpinion = 0;
        if (internationalOpinion > 1) internationalOpinion = 1;

        if (unemploymentRate < 0) unemploymentRate = 0;
        if (unemploymentRate > 1) unemploymentRate = 1;

        if (criminalityRate < 0) criminalityRate = 0;
        if (criminalityRate > 1) criminalityRate = 1;
    }
    public double GetEmploymentRate()
    {
        return 1 - unemploymentRate;
    }

    #region Update UI Functions
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

        unemployementRateText.text = System.Math.Round(unemploymentRate*100, 1).ToString() + "%";

    }

    public void UpdateFrontCriminalityRateGO() {

        criminalityRateText.text = System.Math.Round(criminalityRate * 100, 1).ToString() + "%";

    }
    #endregion

    void Awake()
    {
        instance = this;

        stats_save_package = new StatsSavePackage();

        randomizeStartingStats();

        legalPopulationText = legalPopulationGO.GetComponent<Text>();
        publicOpinionOnImmigrantsSlider = publicOpinionOnImmigrantsGO.GetComponent<Slider>();
        internationalOpinionSlider = internationalOpinionGO.GetComponent<Slider>();
        unemployementRateText = unemploymentRateGO.GetComponent<Text>();
        criminalityRateText = criminalityRateGO.GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
		
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
