using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent {
	//Random event; Has a name, a description and a consequence

	public string name;
	public string description;
	//bool hasHappened { get; set; }//to say whether the event has already happened

	MiscInfo.variableTypes consequenceVariable1;//Variable that suffers from this event
	float consequenceValue1;
	MiscInfo.variableTypes consequenceVariable2;//Possible second variable that suffers from this event
	float consequenceValue2;






	public void applyConsequences()
	{
		//always SUMS the consequence value with the consequence variable, so need to pass the right value
		//Remember to update the displays after this happens


		switch (consequenceVariable1)
		{
		case MiscInfo.variableTypes.availableBO:
			ResourceManager.instance.numberOfAvailableBorderOfficers += (int)consequenceValue1;
			ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceValue1;
			break;
		case MiscInfo.variableTypes.availableHouses:
			ResourceManager.instance.numberOfAvailableHouses += (int)consequenceValue1;
			ResourceManager.instance.numberOfTotalHouses += (int)consequenceValue1;
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
			StatsManager.instance.unemploymentRate+=consequenceValue1;
			break;
        case MiscInfo.variableTypes.waveVariation:
            break;
		default:
			break;

		}

		if (consequenceVariable2 != MiscInfo.variableTypes.NULL)
		{
			switch (consequenceVariable2)
			{
			case MiscInfo.variableTypes.availableBO:
				ResourceManager.instance.numberOfAvailableBorderOfficers += (int)consequenceValue2;
				ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceValue2;
				break;
			case MiscInfo.variableTypes.availableHouses:
				ResourceManager.instance.numberOfAvailableHouses += (int)consequenceValue2;
				ResourceManager.instance.numberOfTotalHouses += (int)consequenceValue2;
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
				StatsManager.instance.unemploymentRate += consequenceValue2;
				break;
            case MiscInfo.variableTypes.waveVariation:
                break;
			default:
				break;
			}
		}
	}



	public RandomEvent(string n, string desc, MiscInfo.variableTypes var1, float consequence1, MiscInfo.variableTypes var2=MiscInfo.variableTypes.NULL, float consequence2=0.0f)
	{
		name = n;
		description = desc;
		consequenceVariable1 = var1;
		consequenceValue1 = consequence1;
		consequenceVariable2 = var2;
		consequenceValue2 = consequence2;
	}



}
