using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	public static ResourceManager instance;

	public double playerCurrentMoney=0; //because the world revolves around it
	public double playerMonthlyBudget; //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue

	//invisible variables
	public double baseTaxPerCitizen=10; //how much each citizen pays(base)
	public double realTaxPerCitizen; //How much they pay(with possible extra variation)
	public double taxVariation=1; //i.e., inflation. Dumbass.
	public double BudgetBaseValue=1000;


	//Resources

	//open borders
	public int numberOfAvailableHouses=0;//number of vacant houses for immigrants
	public int numberOfTotalHouses=0; //total number of houses player has built for helping refugees
	public float costOfHouse=100; 
	public float socialResources=100; //number of social expenses 'units' player has to give out to refugees
	public float costOfSocialResource = 20;

	//closed borders
	public int numberOfAvailableBorderOfficers=0; //number of officers not busy at the moment
	public int numberOfTotalBorderOfficers=0; //total number of officers player currently has employed
	public float costOfBorderOfficer = 30;

	public float borderResources=100; //number of border expenses 'units' player has to maintain borders running
	public float costOfBorderResource = 25;

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




	//======================================TAX AND BUDGET METHODS ============================================
	public void recalculateTax()
	{
		realTaxPerCitizen = baseTaxPerCitizen * taxVariation;
	}

	public void recalculateBudget()//recalculate budget based on taxPerCitizen and BudgetBaseValue
	{
		recalculateTax ();
		playerMonthlyBudget = realTaxPerCitizen * StatsManager.instance.legalPopulation*(1-StatsManager.instance.unemployementRate) + BudgetBaseValue;
	}

	public void receiveNewBudget()
	{
		//recalculate it, so you get the updated value
		recalculateBudget();
		//receives new budget based on current budget value
		playerCurrentMoney +=playerMonthlyBudget;
	}



	// Use this for initialization
	void Start () {
		instance = this;

		taxVariation = 1;
		recalculateTax ();
		recalculateBudget ();

		//initialize resources( TODO: modify later in case you create a load function)


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
