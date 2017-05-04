using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ResourceManager : MonoBehaviour {

	public static ResourceManager instance;

    /// <remarks>
    /// This variable originally was a double, this can generate possible bugs in the future
    /// </remarks>
	public long playerCurrentMoney = 0; //because the world revolves around it

    /// <remarks>
    /// This variable originally was a double, this can generate possible bugs in the future
    /// </remarks>
	public long playerMonthlyBudget; //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue

    #region Invisible Variables
    //invisible variables: the player doesn't see them, but they are used and manipulated by the game
    public double baseTaxPerCitizen = 10; //how much each citizen pays(base)
	public double realTaxPerCitizen; //How much they pay(with possible extra variation)
	public double taxVariation = 1; //i.e., inflation. Dumbass.
	public double BudgetBaseValue = 1000;
    public double UNHelpBaseValue = 4000; // how much the United Nations give when help is asked?
    public double UNHelpVariation = 1.0f; // how much the United Nations give more, or less using the base value?
    #endregion

    //Resources

    #region Open Borders
    //variables used for open borders, in other words, when the refugees start living in the country
    public int numberOfAvailableHouses=0;//number of vacant houses for immigrants
	public int numberOfTotalHouses=0; //total number of houses player has built for helping refugees
	public int costOfHouse=100; 
	public int socialResources=100; //number of social expenses 'units' player has to give out to refugees
	public int costOfSocialResource = 20;
    #endregion

    #region Closed Borders
    //variables used for closed bordersin other words, when the refugees are pushed away
    public int numberOfAvailableBorderOfficers=0; //number of officers not busy at the moment
	public int numberOfTotalBorderOfficers=0; //total number of officers player currently has employed
	public int costOfBorderOfficer = 30;
	public int borderResources=100; //number of border expenses 'units' player has to maintain borders running
	public int costOfBorderResource = 25;
    #endregion

    //Game Objects
    public GameObject playerCurrentMoneyGO;
	public GameObject playerMonthlyBudgetGO;
	public GameObject realTaxPerCitizenGO;
	public GameObject numberOfAvailableHousesGO;
	public GameObject numberOfTotalHousesGO;
	public GameObject socialResourcesGO;
	public GameObject numberOfAvailableBorderOfficersGO;
	public GameObject numberOfTotalBorderOfficersGO;
	public GameObject borderResourcesGO;

    //User Interface Fields
    Text textPlayerCurrentMoney;
    Text textPlayerMonthlyBudget;
    Text textRealTaxPerCitizen;
    Text textNumberOfAvailableHouses;
    Text textNumberOfTotalHouses;
    Text textSocialResources;
    Text textNumberOfAvailableBorderOfficers;
    Text textNumberOfTotalBorderOfficers;
    Text textBorderResources;

    //======================================= MAIN RESOURCES METHODS =============================================

    //OPEN BORDERS
    
    public bool buyHouses(int numberOfHouses)
	{
		if (numberOfHouses * costOfHouse <= playerCurrentMoney)
		{
			//can buy, bought
			playerCurrentMoney -= numberOfHouses*costOfHouse;
			//add them to list
			numberOfAvailableHouses+=numberOfHouses;
			numberOfTotalHouses += numberOfHouses;
			return true;
		}
		//can't buy 
		return false;
	}

	public bool sellHouses(int numberOfHouses)
	{

		if (numberOfHouses <= 0)
			return false;//just because

		//if number> houses you own, just sell all
		if (numberOfHouses > numberOfTotalHouses)
		{
			numberOfHouses = numberOfTotalHouses;
		}
		//sells for half-price
		playerCurrentMoney+=numberOfHouses*costOfHouse/2;
		return true;
	}

	public bool buySocialResources(int numberOfSocialResources)
	{
		if (numberOfSocialResources * costOfSocialResource <= playerCurrentMoney)
		{
			//can buy, bought
			playerCurrentMoney -= numberOfSocialResources*costOfSocialResource;
			socialResources += numberOfSocialResources;
			return true;
		}
		//can't buy 
		return false;
	}

	public bool sellSocialResources(int numberOfSocialResources)
	{
		if (numberOfSocialResources <= 0)
			return false;//just because

		//if number> houses you own, just sell all
		if (numberOfSocialResources > socialResources)
		{
			numberOfSocialResources = socialResources;
		}
		//sells for half-price
		playerCurrentMoney+=numberOfSocialResources*costOfSocialResource/2;
		return true;
	}

	//CLOSED BORDERS
	public bool hireBorderOfficers(int numberOfOfficers)
	{
		if (numberOfOfficers * costOfBorderOfficer <= playerCurrentMoney)
		{
			//can buy, bought
			playerCurrentMoney -= numberOfOfficers*costOfHouse;

			numberOfAvailableBorderOfficers += numberOfOfficers;
			numberOfTotalBorderOfficers += numberOfOfficers;
			return true;
		}
		//can't buy 
		return false;
	}

	public bool fireBorderOfficers(int numberOfOfficers)
	{
		if (numberOfOfficers <= 0)
			return false;//just because

		//if number> houses you own, just sell all
		if (numberOfOfficers > numberOfTotalBorderOfficers)
		{
			numberOfOfficers = numberOfTotalBorderOfficers;
		}
		//sells for half-price
		playerCurrentMoney+=numberOfOfficers*costOfBorderOfficer/2;
		return true;
	}

	public bool buyBorderResources(int numberOfBorderResources)
	{
		if (numberOfBorderResources * costOfBorderResource <= playerCurrentMoney)
		{
			//can buy, bought
			playerCurrentMoney -= numberOfBorderResources*costOfBorderResource;
			return true;
		}
		//can't buy 
		return false;
	}
	public bool sellBorderResources(int numberOfBorderResources)
	{
		if (numberOfBorderResources <= 0)
			return false;//just because

		//if number> houses you own, just sell all
		if (numberOfBorderResources > borderResources)
		{
			numberOfBorderResources = borderResources;
		}
		//sells for half-price
		playerCurrentMoney+=numberOfBorderResources*costOfBorderResource/2;
		return true;
	}

    public void UpdateResourcesSpentInBorderOfficers()
    {
        borderResources -= numberOfAvailableBorderOfficers;
    }

    public void UpdateResourcesSpentInSocialResources()
    {
        socialResources -= numberOfAvailableHouses;
    }

    //======================================TAX AND BUDGET METHODS ============================================
    public void recalculateTax()
	{
		realTaxPerCitizen = baseTaxPerCitizen * taxVariation;
	}

	public void recalculateBudget()//recalculate budget based on taxPerCitizen and BudgetBaseValue
	{
		recalculateTax ();
        playerMonthlyBudget =   (long)
                                ((0.005f * StatsManager.instance.legalPopulation * StatsManager.instance.GetEmploymentRate())
                                    * realTaxPerCitizen + BudgetBaseValue);
	}

	public void receiveNewBudget()
	{
		//recalculate it, so you get the updated value
		recalculateBudget();
		//receives new budget based on current budget value
		playerCurrentMoney +=playerMonthlyBudget;
	}

    //======================================= USER INTERFACE UPDATE METHODS =============================================

    void UpdatePlayerCurrentMoneyGO()
    {
        textPlayerCurrentMoney.text = playerCurrentMoney.ToString();
    }

    void UpdatePlayerMonthlyBudgetGO()
    {
        textPlayerMonthlyBudget.text = playerMonthlyBudget.ToString();
    }

    void UpdateRealTaxPerCitizenGO()
    {
        textRealTaxPerCitizen.text = realTaxPerCitizen.ToString();
    }

    void UpdateNumberOfAvailableHouses()
    {
        textNumberOfAvailableHouses.text = numberOfAvailableHouses.ToString();
    }

    void UpdateNumberOfTotalHouses()
    {
        textNumberOfTotalHouses.text = numberOfTotalHouses.ToString();
    }

    void UpdateSocialResources()
    {
        textSocialResources.text = socialResources.ToString();
    }

    void UpdateNumberOfAvailableBorderOfficers()
    {
        textNumberOfAvailableBorderOfficers.text = numberOfAvailableBorderOfficers.ToString();
    }

    void UpdateNumberOfTotalBorderOfficers()
    {
        textNumberOfTotalBorderOfficers.text = numberOfTotalBorderOfficers.ToString();
    }

    void UpdateNumberOfBorderResources()
    {
        textBorderResources.text = borderResources.ToString();
    }

    void Awake ()
    {
        instance = this;

        textPlayerCurrentMoney = playerCurrentMoneyGO.GetComponent<Text>();
        textPlayerMonthlyBudget = playerMonthlyBudgetGO.GetComponent<Text>();
        textRealTaxPerCitizen = realTaxPerCitizenGO.GetComponent<Text>();
        textNumberOfAvailableHouses = numberOfAvailableHousesGO.GetComponent<Text>();
        textNumberOfTotalHouses = numberOfTotalHousesGO.GetComponent<Text>();
        textSocialResources = socialResourcesGO.GetComponent<Text>();
        textNumberOfAvailableBorderOfficers = numberOfAvailableBorderOfficersGO.GetComponent<Text>();
        textNumberOfTotalBorderOfficers = numberOfTotalBorderOfficersGO.GetComponent<Text>();
        textBorderResources = borderResourcesGO.GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
		
		taxVariation = 1;
		recalculateTax ();
		recalculateBudget ();

		//initialize resources( TODO: modify later in case you create a load function)


	}
	
	// Update is called once per frame
	void Update () {

        UpdatePlayerCurrentMoneyGO();
        UpdatePlayerMonthlyBudgetGO();
        UpdateRealTaxPerCitizenGO();
        UpdateNumberOfAvailableHouses();
        UpdateNumberOfTotalHouses();
        UpdateSocialResources();
        UpdateNumberOfAvailableBorderOfficers();
        UpdateNumberOfTotalBorderOfficers();
        UpdateNumberOfBorderResources();
    }
}
