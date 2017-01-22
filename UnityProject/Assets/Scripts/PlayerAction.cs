using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Actions the player can do, like researches, purchase of objects, etc
public class PlayerAction {




	//actions have names, descriptions(?), consequences and cooldown period

	public string actionName;
	public string actionDescription;

	//how to do consequences?
	//TODO: Consequences of actions!!

	public MiscInfo.variableTypes consequenceVar1;
	public float consequenceValue1;

	public MiscInfo.variableTypes consequenceVar2;//if needed
	public float consequenceValue2;//if needed


	public float actionCooldownPeriod;

	public float timeLastUsed;//saves time action was last used
	public bool isActive;//tells if action can be used or if it's cooling down




	public void applyConsequences()
	{
		//always SUMS the consequence value with the consequence variable, so need to pass the right value
		//right value to be passed will be seen in ACTIONSMANAGER

		switch (consequenceVar1)
		{
		case MiscInfo.variableTypes.availableBO:
			
			break;
		case MiscInfo.variableTypes.availableHouses:
			ResourceManager.instance.numberOfAvailableHouses += (int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.baseTaxPerCitizen:
			ResourceManager.instance.baseTaxPerCitizen += (double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.borderResources:
			ResourceManager.instance.borderResources += (int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.budgetBaseValue:
			ResourceManager.instance.BudgetBaseValue += (double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.costOfBO:
			ResourceManager.instance.costOfBorderOfficer += (int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.costOfBorderResources:
			ResourceManager.instance.costOfBorderResource+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.costOfHouse:
			ResourceManager.instance.costOfHouse+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.costOfSocialResources:
			ResourceManager.instance.costOfSocialResource+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.criminalityRate:
			StatsManager.instance.criminalityRate += (double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.internationalOpinion:
			StatsManager.instance.internationalOpinion+=(double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.legalPopulation:
			StatsManager.instance.legalPopulation+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.playerCurrentMoney:
			ResourceManager.instance.playerCurrentMoney+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.publicOpinion:
			StatsManager.instance.publicOpinionOnImmigrants+=(double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.socialResources:
			ResourceManager.instance.socialResources+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.taxVariation:
			ResourceManager.instance.taxVariation+=(double)consequenceValue1;
			break;
		case MiscInfo.variableTypes.totalBO:
			ResourceManager.instance.numberOfTotalBorderOfficers+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.totalHouses:
			ResourceManager.instance.numberOfTotalHouses+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.unemployementRate:
			StatsManager.instance.unemployementRate+=(double)consequenceValue1;
			break;
		default:
			break;

			

		}

		if (consequenceVar2 != MiscInfo.variableTypes.NULL)
		{
			//check for second consequence as well

		}


	}
















	public void actionUsed()
	{
		//gets time used, make action inactive
		timeLastUsed= Time.time;
		isActive = false;
		applyConsequences ();
	}



	public bool checkIfCooledDown()
	{
		//compare current time with time last used, if bigger than cooldown period, can be used again
		if (Time.time - timeLastUsed >= actionCooldownPeriod)
		{
			isActive = true;
			return true;
		}
		return false;

	}

	public PlayerAction(string name, string desc, float cooldown, MiscInfo.variableTypes varType1, 
						float var1Consequence, MiscInfo.variableTypes varType2 = MiscInfo.variableTypes.NULL, 
	{
		actionName = name;
		actionDescription = desc;
		actionCooldownPeriod = cooldown;

		consequenceVar1 = varType1;
		consequenceVar2 = varType2;

		consequenceValue1 = var1Consequence;
		consequenceValue2 = var2Consequence;


	}



}
