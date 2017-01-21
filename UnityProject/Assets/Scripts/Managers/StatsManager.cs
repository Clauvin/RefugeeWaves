using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {


	public static StatsManager instance;


	//Creates all global variables to be used by the Minister of Wavestan

	//Visible variables(to the player)

	public double playerCurrentMoney; //because the world revolves around it
	public double playerMonthlyBudget; //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue
	public int legalPopulation;//how many legal, tax paying ppl are living in your country atm

	//invisible variables
	public int numberOfIllegalImmigrants;
	public double baseTaxPerCitizen; //how much each citizen pays(base)
	public double realTaxPerCitizen; //How much they pay(with possible extra variation)
	public double taxVariation; //i.e., inflation. Dumbass.
	public double BudgetBaseValue;


	public void recalculateTax()
	{
		realTaxPerCitizen = baseTaxPerCitizen * taxVariation;
	}

	public void recalculateBudget()//recalculate budget based on taxPerCitizen and BudgetBaseValue
	{
		recalculateTax ();
		playerMonthlyBudget = realTaxPerCitizen * legalPopulation + BudgetBaseValue;
	}

	public void receiveNewBudget()
	{
		//recalculate it, so you get the updated value
		recalculateBudget();
		//receives new budget based on current budget value
		playerCurrentMoney +=playerMonthlyBudget;
	}

	//Used when month ends, recalculates all values based on current values
	public void recalculateValues()
	{
		//TODO: Get EXACTLY how each variable affects the other

	}

	// Use this for initialization
	void Start () {
		instance = this;
		taxVariation = 1;
		recalculateTax ();
		recalculateBudget ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
