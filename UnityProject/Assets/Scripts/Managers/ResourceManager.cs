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
	public float socialExpenses=100; //number of social expenses 'units' player has to give out to refugees

	//closed borders
	public int numberOfAvailableBorderOfficials=0; //number of officials not busy at the moment
	public int numberOfTotalBorderOfficials=0; //total number of officials player currently has employed

	public float borderExpenses=100; //number of border expenses 'units' player has to maintain borders running





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
