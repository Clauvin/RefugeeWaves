using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInstance  {

	//Class is used to create a serialized saved game; must have all relevant info about the game

	public static GameInstance current;


	//Stats variables
	public int legalPopulation;//how many legal, tax paying ppl are living in your country atm

	public double publicOpinionOnImmigrants; //goes from 0 to 1
	public double internationalOpinion; //goes from 0 to 1, affects your chances of getting international help

	public double unemployementRate; //from 0 to 1(if 1, boy, are you screwed)
	public double criminalityRate; //from 0 to 1(if 1, boy, are you dead)


	//Resource variables
	public long playerCurrentMoney; //because the world revolves around it
	public long playerMonthlyBudget; //how much the player will earn; depends on taxPerCitizen and BudgetBaseValue

	//invisible variables
	public double baseTaxPerCitizen; //how much each citizen pays(base)
	public double realTaxPerCitizen; //How much they pay(with possible extra variation)
	public double taxVariation; //i.e., inflation. Dumbass.
	public double BudgetBaseValue;


	//Resources

	public int numberOfAvailableHouses;//number of vacant houses for immigrants
	public int numberOfTotalHouses; //total number of houses player has built for helping refugees
	public int costOfHouse; 
	public int socialResources; //number of social expenses 'units' player has to give out to refugees
	public int costOfSocialResource;

	//closed borders
	public int numberOfAvailableBorderOfficers; //number of officers not busy at the moment
	public int numberOfTotalBorderOfficers; //total number of officers player currently has employed
	public int costOfBorderOffice;

	public int borderResources; //number of border expenses 'units' player has to maintain borders running
	public int costOfBorderResource;


	//Immigrant Waves Variables
	public List<ImmigrantWave> legalWaves;//holds the waves of legal immigrants
	public List<ImmigrantWave> illegalWaves;
	public int numberOfLegalImmigrants;
	public int numberOfIllegalImmigrants;

	public int numberOfNaturalizedImmigrants;//how many immigrants you have helped get citizenship


	public GameInstance (int lp, double pubOp, double intOp, double unempRat, double crimiRat, double money, double mBud,
		double baseTax, double realTax, double dTax, double budBase, int nAHouse, int nTotHouse, int costH, int sR,
		int costSR, int nABO, int nTotBO, int costBO, int bRes, int costBRes, List<ImmigrantWave> lW, List<ImmigrantWave> ilW,
		int nLIm, int nIlIm)
	{
		//Do this constructor. I DARE YOU. I DOUBLE DARE YOU, MOTHERFUCKER
		//TODO
	}



}
