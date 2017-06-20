using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;

    #region Classe Para Salvar
    [System.Serializable]
    public class ResourceSavePackage
    {
        public long _playerCurrentMoney = 10000;
        public long _playerMonthlyBudget;
        public double _baseTaxPerCitizen = 10;
        public double _realTaxPerCitizen;
        public double _taxVariation = 1;
        public double _BudgetBaseValue = 1000;
        public double _UNHelpBaseValue = 4000;
        public double _UNHelpVariation = 1.0f;

        public int _numberOfAvailableHouses = 0;
        public int _numberOfTotalHouses = 0;
        public int _costOfHouse = 100;
        public int _socialResources = 100;
        public int _costOfSocialResource = 20;

        public int _numberOfAvailableBorderOfficers = 0;
        public int _numberOfTotalBorderOfficers = 0;
        public int _costOfBorderOfficer = 30;
        public int _borderResources = 100;
        public int _costOfBorderResource = 25;
    }

    public ResourceSavePackage rs;

    #endregion

    /// <remarks>
    /// This variable originally was a double, this can generate possible bugs in the future
    /// </remarks>
    //because the world revolves around it

    public long playerCurrentMoney{
        get { return rs._playerCurrentMoney; }
        set { rs._playerCurrentMoney = value; }
    }

    /// <remarks>
    /// This variable originally was a double, this can generate possible bugs in the future
    /// </remarks>
    //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue
    public long playerMonthlyBudget{
        get { return rs._playerMonthlyBudget; }
        set { rs._playerMonthlyBudget = value; }
    }

    #region Invisible Variables
    //invisible variables: the player doesn't see them, but they are used and manipulated by the game

    //how much each citizen pays(base)
    public double baseTaxPerCitizen{
        get { return rs._baseTaxPerCitizen; }
        set { rs._baseTaxPerCitizen = value; }
    }

    //How much they pay(with possible extra variation)
    public double realTaxPerCitizen{
        get { return rs._realTaxPerCitizen; }
        set { rs._realTaxPerCitizen = value; }
    }

    //i.e., inflation. Dumbass.
    public double taxVariation{
        get { return rs._taxVariation; }
        set { rs._taxVariation = value; }
    }

	public double BudgetBaseValue{
        get { return rs._BudgetBaseValue; }
        set { rs._BudgetBaseValue = value; }
    }

    // how much the United Nations give when help is asked?
    public double UNHelpBaseValue {
        get { return rs._UNHelpBaseValue; }
        set { rs._UNHelpBaseValue = value; }
    }

    // how much the United Nations give more, or less using the base value?
    public double UNHelpVariation {
        get { return rs._UNHelpVariation; }
        set { rs._UNHelpVariation = value; }
    }
    #endregion

    //Resources

    #region Open Borders
    //variables used for open borders, in other words, when the refugees start living in the country
    //number of vacant houses for immigrants
    public int numberOfAvailableHouses {
        get { return rs._numberOfAvailableHouses; }
        set { rs._numberOfAvailableHouses = value; }
    }

    //total number of houses player has built for helping refugees
    public int numberOfTotalHouses {
        get { return rs._numberOfTotalHouses; }
        set { rs._numberOfTotalHouses = value; }
    }

    public int costOfHouse {
        get { return rs._costOfHouse; }
        set { rs._costOfHouse = value; }
    }

    //number of social expenses 'units' player has to give out to refugees
    public int socialResources {
        get { return rs._socialResources; }
        set { rs._socialResources = value; }
    }

    public int costOfSocialResource {
        get { return rs._costOfSocialResource; }
        set { rs._costOfSocialResource = value; }
    }
    #endregion

    #region Closed Borders
    //variables used for closed bordersin other words, when the refugees are pushed away

    //number of officers not busy at the moment
    public int numberOfAvailableBorderOfficers {
        get { return rs._numberOfAvailableBorderOfficers; }
        set { rs._numberOfAvailableBorderOfficers = value; }
    }

    //total number of officers player currently has employed
    public int numberOfTotalBorderOfficers {
        get { return rs._numberOfTotalBorderOfficers; }
        set { rs._numberOfTotalBorderOfficers = value; }
    }

    public int costOfBorderOfficer {
        get { return rs._costOfBorderOfficer; }
        set { rs._costOfBorderOfficer = value; }
    }

    //number of border expenses 'units' player has to maintain borders running
    public int borderResources {
        get { return rs._borderResources; }
        set { rs._borderResources = value; }
    } 

	public int costOfBorderResource {
        get { return rs._costOfBorderResource; }
        set { rs._costOfBorderResource = value; }
    } 
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

    //CLOSED BORDERS
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

        rs = new ResourceSavePackage();
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
