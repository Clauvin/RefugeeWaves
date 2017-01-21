using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {


	public static StatsManager instance;


	//Creates all global variables to be used by the Minister of Wavestan

	//Visible variables(to the player)

	double playerCurrentMoney; //because the world revolves around it
	double playerMonthlyBudget; //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue
	double legalPopulation;//how many legal, tax paying ppl are living in your country atm

	//invisible variables
	int numberOfIllegalImmigrants;
	double taxPerCitizen; //how much each citizen pays
	double BudgetBaseValue;


	public void recalculateBudget()//recalculate budget based on taxPerCitizen and BudgetBaseValue
	{
		playerMonthlyBudget = taxPerCitizen * legalPopulation + BudgetBaseValue;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
