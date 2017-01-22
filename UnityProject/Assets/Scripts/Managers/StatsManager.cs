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
        //TODO: Se possível, que os imigrantes se tornando cidadãos
        // virem ANTES desses cálculos, quando ambos ocorrerem no mesmo mês.

        //Em ordem, a partir do um valor que não muda

        //Se + imigrantes ilegais, opinião sobre imigrantes cai
        //MAYBE: Reduzir a opinião pública pela porcentagem de imigrantes ilegais/população total?
        //BYTHEWAY: número mágico de imigrantes ilegais ferrando o país por enquanto: 10000.
        if (ImmigrantManager.instance.numberOfIllegalImmigrants > 0)
            publicOpinionOnImmigrants -= ImmigrantManager.instance.numberOfIllegalImmigrants * 0.01f;

        //Se moradia < 0, criminalidade >
        if (ResourceManager.instance.numberOfAvailableHouses < 0)
            criminalityRate += (ResourceManager.instance.numberOfAvailableHouses * -1 * 0.01f);

        //Se social expenses < 0, criminalidade >
        //Yes, -10000 social resources = DOOM
        if (ResourceManager.instance.socialResources < 0)
            criminalityRate += ResourceManager.instance.socialResources * -1 * 0.01f;

        //Se border expenses < 0, criminalidade 2x >
        //Yes, -10000 border resources = DOOM
        if (ResourceManager.instance.borderResources < 0)
            criminalityRate += ResourceManager.instance.borderResources * -1 * 0.01f;

        //Se border officials < onda de imigrantes, criminalidade 2x >
        //Peraí, não faz sentido. Se o cálculo sobre as ondas é feito no momento de contato, então esse
        // criminalidade 2x precisa ser é feito na hora da colisão da onda, seja isso onde for.
        //if (ResourceManager.instance.numberOfAvailableBorderOfficers)

        //Se dinheiro < 0, criminalidade >
        if (ResourceManager.instance.playerCurrentMoney < 0)
            criminalityRate += ResourceManager.instance.playerCurrentMoney * -1 * 0.01f;

        //Se variação do imposto +, desemprego +
        if (ResourceManager.instance.taxVariation > 1.1)
            unemployementRate += (ResourceManager.instance.taxVariation - 1.1) * 50f;

        //Se variação do imposto -, desemprego -
        if (ResourceManager.instance.taxVariation < 0.9)
            unemployementRate -= (0.9 - ResourceManager.instance.taxVariation) * 50f;

        //Se desemprego +, variação do imposto -
        //CORRIGIR NO DIAGRAMA
        if (unemployementRate > 0.1)
            ResourceManager.instance.taxVariation -= (unemployementRate - 0.1) * 0.5;

        //Se taxa de desemprego +, criminalidade >
        if (unemployementRate > 0.1)
            criminalityRate += (unemployementRate - 0.1f) * 0.1f;

        //Se taxa de desemprego -, criminalidade <
        if (unemployementRate < 0.1)
            criminalityRate -= (0.1 - unemployementRate) * 0.1f;

        //Se taxa de desemprego >, imposto p/ cidadão <
        if (unemployementRate > 0.12)
            ResourceManager.instance.taxVariation -= unemployementRate - 0.12;

        //Se + criminalidade, Opinião Sobre Imigrantes -
        //Yes. A 20% crimeRate means a 5% fall in publicOpinion, a 30% crimeRate means a 15% fall, and so on.
        if (criminalityRate > 0.1)
            publicOpinionOnImmigrants -= (criminalityRate - 0.1) * 0.5;

        //Se - criminalidade, Opinião Sobre Imigrantes +
        if (criminalityRate < 0.04)
            publicOpinionOnImmigrants += (0.04 - criminalityRate);

        //Se + criminalidade, Variação do Imposto Sobre População -
        if (criminalityRate > 0.1)
            ResourceManager.instance.taxVariation -= unemployementRate - 0.1;

        //Se variação do imposto +, imposto p/ cidadão +
        //Se variação do imposto -, imposto p/ cidadão -
        //CALMA AÊ. Isso é uma consequência da equação, não é algo a ser calculado no fim do mês

        //Se + VARIAÇÃO DO IMPOSTO, Opinião Sobre Imigrantes -
        if (ResourceManager.instance.taxVariation > 1.1)
            publicOpinionOnImmigrants -= ResourceManager.instance.taxVariation - 1.1;

        //Se + opinião sobre imigrantes, Opinião Internacional +
        if (publicOpinionOnImmigrants < 0.3)
            internationalOpinion -= (0.3 - publicOpinionOnImmigrants) * 0.5;

        //Se - opinião sobre imigrantes, Opinião Internacional -
        if (publicOpinionOnImmigrants > 0.7)
            internationalOpinion += (publicOpinionOnImmigrants - 0.7) * 0.5;

        //Se população legal +, orçamento +
        //Se + imposto, orçamento +
        //Se - imposto, orçamento -
        //Se valor base +, orçamento +
        //Se + orçamento, + dinheiro
        //Se - orçamento, - dinheiro
        //Tudo isso é consequência do cálculo em ResourceManager.

        StatsLimitChecker();

    }

    public void StatsLimitChecker()
    {
        if (publicOpinionOnImmigrants < 0) publicOpinionOnImmigrants = 0;
        if (publicOpinionOnImmigrants > 1) publicOpinionOnImmigrants = 1;

        if (internationalOpinion < 0) internationalOpinion = 0;
        if (internationalOpinion > 1) internationalOpinion = 1;

        if (unemployementRate < 0) unemployementRate = 0;
        if (unemployementRate > 1) unemployementRate = 1;

        if (criminalityRate < 0) criminalityRate = 0;
        if (criminalityRate > 1) criminalityRate = 1;
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
