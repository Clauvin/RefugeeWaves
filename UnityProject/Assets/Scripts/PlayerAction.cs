using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Actions the player can do, like researches, purchase of objects, etc
public class PlayerAction {
	//actions have names, descriptions(?), consequences and cooldown period

	public string actionName;
	public string actionDescription;
	public double actionCost;

	public GameObject assignedButton;//button assigned to this Action

	public MiscInfo.variableTypes consequenceVar1;
	public double consequenceValue1;

	public MiscInfo.variableTypes consequenceVar2;//if needed
	public double consequenceValue2;//if needed


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
			ResourceManager.instance.baseTaxPerCitizen += consequenceValue1;
			break;
		case MiscInfo.variableTypes.borderResources:
			ResourceManager.instance.borderResources += (int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.budgetBaseValue:
			ResourceManager.instance.BudgetBaseValue += consequenceValue1;
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
			StatsManager.instance.criminalityRate += consequenceValue1;
			break;
		case MiscInfo.variableTypes.internationalOpinion:
			StatsManager.instance.internationalOpinion+=consequenceValue1;
			break;
		case MiscInfo.variableTypes.legalPopulation:
			StatsManager.instance.legalPopulation+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.playerCurrentMoney:
			ResourceManager.instance.playerCurrentMoney+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.publicOpinion:
			StatsManager.instance.publicOpinionOnImmigrants+=consequenceValue1;
			break;
		case MiscInfo.variableTypes.socialResources:
			ResourceManager.instance.socialResources+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.taxVariation:
			ResourceManager.instance.taxVariation+=consequenceValue1;
			break;
		case MiscInfo.variableTypes.totalBO:
			ResourceManager.instance.numberOfTotalBorderOfficers+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.totalHouses:
			ResourceManager.instance.numberOfTotalHouses+=(int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.unemployementRate:
			StatsManager.instance.unemployementRate+=consequenceValue1;
			break;
		default:
			break;

			

		}

		if (consequenceVar2 != MiscInfo.variableTypes.NULL)
		{
			switch (consequenceVar2)
			{
			case MiscInfo.variableTypes.availableBO:

				break;
			case MiscInfo.variableTypes.availableHouses:
				ResourceManager.instance.numberOfAvailableHouses += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.baseTaxPerCitizen:
				ResourceManager.instance.baseTaxPerCitizen += consequenceValue2;
				break;
			case MiscInfo.variableTypes.borderResources:
				ResourceManager.instance.borderResources += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.budgetBaseValue:
				ResourceManager.instance.BudgetBaseValue += consequenceValue2;
				break;
			case MiscInfo.variableTypes.costOfBO:
				ResourceManager.instance.costOfBorderOfficer += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.costOfBorderResources:
				ResourceManager.instance.costOfBorderResource += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.costOfHouse:
				ResourceManager.instance.costOfHouse += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.costOfSocialResources:
				ResourceManager.instance.costOfSocialResource += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.criminalityRate:
				StatsManager.instance.criminalityRate += consequenceValue2;
				break;
			case MiscInfo.variableTypes.internationalOpinion:
				StatsManager.instance.internationalOpinion += consequenceValue2;
				break;
			case MiscInfo.variableTypes.legalPopulation:
				StatsManager.instance.legalPopulation += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.playerCurrentMoney:
				ResourceManager.instance.playerCurrentMoney += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.publicOpinion:
				StatsManager.instance.publicOpinionOnImmigrants += consequenceValue2;
				break;
			case MiscInfo.variableTypes.socialResources:
				ResourceManager.instance.socialResources += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.taxVariation:
				ResourceManager.instance.taxVariation += consequenceValue2;
				break;
			case MiscInfo.variableTypes.totalBO:
				ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.totalHouses:
				ResourceManager.instance.numberOfTotalHouses += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.unemployementRate:
				StatsManager.instance.unemployementRate += consequenceValue2;
				break;
			default:
				break;
			}
		}
	}


	public void actionUsed()
	{
		Debug.Log ("Did " + actionName);
		//if it's still in cooldown, do nothing
		if (!isActive)
        {
            Debug.Log("e está inativo");
            return;
        }
			

		//deduct cost
		ResourceManager.instance.playerCurrentMoney-=actionCost;

		//turn off button
		assignedButton.SetActive(false);

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
			//assignedButton.SetActive(true);
			return true;
		}
		return false;

	}

	public PlayerAction(GameObject buttonGO, string name, string desc, double cost, float cooldown, MiscInfo.variableTypes varType1, 
		double var1Consequence, MiscInfo.variableTypes varType2 = MiscInfo.variableTypes.NULL, 
						double var2Consequence = 0.0, bool active = true)
	{
        assignedButton = buttonGO;
		actionName = name;
		actionDescription = desc;
		actionCost = cost;

		actionCooldownPeriod = cooldown;

		consequenceVar1 = varType1;
		consequenceVar2 = varType2;

		consequenceValue1 = var1Consequence;
		consequenceValue2 = var2Consequence;

		timeLastUsed = 0.0f;
		isActive = active;
	}



}
