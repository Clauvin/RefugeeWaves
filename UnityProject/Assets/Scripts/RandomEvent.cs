using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomEvent {

	public string name;
	public string description;

    public readonly float minimum_multiplier_of_refugees = 0.1f;

    #region Consequence Variables
    MiscInfo.variableTypes consequenceVariable1;//Variable that suffers from this event
	float consequenceValue1;
	MiscInfo.variableTypes consequenceVariable2;//Possible second variable that suffers from this event
	float consequenceValue2;
    #endregion

    /// <summary>
    /// always SUMS the consequence value with the consequence variable, so need to pass the right value
    /// Remember to update the displays after this happens
    /// </summary>
    public void applyConsequences()
	{

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
            CommerceManager.instance.border_officer_buy_price += consequenceValue1;
            CommerceManager.instance.border_officer_sell_price += consequenceValue1 / 2.0f;
			break;
		case MiscInfo.variableTypes.costOfBorderResources:
            CommerceManager.instance.border_resource_buy_price += consequenceValue1;
            CommerceManager.instance.border_resource_sell_price += consequenceValue1 / 2.0f;
			break;
		case MiscInfo.variableTypes.costOfHouse:
            CommerceManager.instance.house_buy_price += consequenceValue1;
			CommerceManager.instance.house_sell_price += consequenceValue1 / 2.0f;
            break;
		case MiscInfo.variableTypes.costOfSocialResources:
            CommerceManager.instance.social_resource_buy_price += consequenceValue1;
            CommerceManager.instance.social_resource_sell_price += consequenceValue1 / 2.0f;
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
            ImmigrantWaveLauncher.instance.refugees_multiplier += consequenceValue1;
            if (ImmigrantWaveLauncher.instance.refugees_multiplier < minimum_multiplier_of_refugees)
                {
                    ImmigrantWaveLauncher.instance.refugees_multiplier = minimum_multiplier_of_refugees;
                }
            break;
        case MiscInfo.variableTypes.unitedNationsHelpVariation:
            ResourceManager.instance.UNHelpVariation += consequenceValue1;
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
                CommerceManager.instance.border_officer_buy_price += consequenceValue2;
                CommerceManager.instance.border_officer_sell_price += consequenceValue2 / 2.0f;
			    break;
		    case MiscInfo.variableTypes.costOfBorderResources:
                CommerceManager.instance.border_resource_buy_price += consequenceValue2;
                CommerceManager.instance.border_resource_sell_price += consequenceValue2 / 2.0f;
			    break;
		    case MiscInfo.variableTypes.costOfHouse:
                CommerceManager.instance.house_buy_price += consequenceValue2;
			    CommerceManager.instance.house_sell_price += consequenceValue2 / 2.0f;
                break;
		    case MiscInfo.variableTypes.costOfSocialResources:
                CommerceManager.instance.social_resource_buy_price += consequenceValue2;
                CommerceManager.instance.social_resource_sell_price += consequenceValue2 / 2.0f;
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
                ImmigrantWaveLauncher.instance.refugees_multiplier += consequenceValue2;
                break;
            case MiscInfo.variableTypes.unitedNationsHelpVariation:
                ResourceManager.instance.UNHelpVariation += consequenceValue2;
                break;
			default:
				break;
			}
		}
	}

	public RandomEvent(string n, string desc, MiscInfo.variableTypes var1, float consequence1,
        MiscInfo.variableTypes var2 = MiscInfo.variableTypes.NULL, float consequence2 = 0.0f)
	{
		name = n;
		description = desc;
		consequenceVariable1 = var1;
		consequenceValue1 = consequence1;
		consequenceVariable2 = var2;
		consequenceValue2 = consequence2;
	}



}
