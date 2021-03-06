﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Actions the player can do, like researches, purchase of objects, etc
/// actions have names, descriptions(?), consequences and cooldown period
/// </summary>

public class PlayerAction {
	
	public string actionName;
	public string actionDescription;
	public double actionCost;

	public GameObject assignedButton;//button assigned to this Action
    public delegate double consequenceFunction();

    #region Consequence Variables
    public MiscInfo.variableTypes consequenceVar1;
	public double consequenceValue1;
    public consequenceFunction consequenceFunction1;

    public MiscInfo.variableTypes consequenceVar2;//if needed
	public double consequenceValue2;//if needed
    public consequenceFunction consequenceFunction2;
    #endregion

    #region Save Package
    [System.Serializable]
    public class PlayerActionCooldownSavePackage {
        public float _actionCooldownPeriod;

        public float _timeLastUsed; //saves time action was last used
        public bool _isActive; //tells if action can be used or if it's cooling down
    }
    #endregion

    public PlayerActionCooldownSavePackage player_action_cooldown_save_package;

    public PlayerActionCooldownSavePackage GetPlayerActionCooldownSavePackage()
    {
        return player_action_cooldown_save_package;
    }

    public void SetPlayerActionCooldownSavePackage(PlayerActionCooldownSavePackage save_package)
    {
        player_action_cooldown_save_package = save_package;
        if (!isActive) assignedButton.SetActive(false);
    }

    #region Cooldown Variables
    public float actionCooldownPeriod {
        get { return player_action_cooldown_save_package._actionCooldownPeriod; }
        set { player_action_cooldown_save_package._actionCooldownPeriod = value; }
    }

	public float timeLastUsed {
        get { return player_action_cooldown_save_package._timeLastUsed; }
        set { player_action_cooldown_save_package._timeLastUsed = value; }
    }
	public bool isActive {
        get { return player_action_cooldown_save_package._isActive; }
        set { player_action_cooldown_save_package._isActive = value; }
    }
    #endregion

    #region Public Constructors
    public PlayerAction(GameObject buttonGO, string name, string desc, double cost, float cooldown, MiscInfo.variableTypes varType1,
        consequenceFunction function1Consequence,  MiscInfo.variableTypes varType2 = MiscInfo.variableTypes.NULL,
                        consequenceFunction function2Consequence = null, bool active = true)
    {
        player_action_cooldown_save_package = new PlayerActionCooldownSavePackage();
        assignedButton = buttonGO;
        actionName = name;
        actionDescription = desc;
        actionCost = cost;

        actionCooldownPeriod = cooldown;

        consequenceVar1 = varType1;
        consequenceVar2 = varType2;

        consequenceValue1 = 0.0f;
        consequenceValue2 = 0.0f;

        consequenceFunction1 = function1Consequence;
        consequenceFunction2 = function2Consequence;

        timeLastUsed = 0.0f;
        isActive = active;
    }

    public PlayerAction(GameObject buttonGO, string name, string desc, double cost, float cooldown, MiscInfo.variableTypes varType1,
        double var1Consequence, MiscInfo.variableTypes varType2 = MiscInfo.variableTypes.NULL,
                        double var2Consequence = 0.0, bool active = true)
    {
        player_action_cooldown_save_package = new PlayerActionCooldownSavePackage();
        assignedButton = buttonGO;
        actionName = name;
        actionDescription = desc;
        actionCost = cost;

        actionCooldownPeriod = cooldown;

        consequenceVar1 = varType1;
        consequenceVar2 = varType2;

        consequenceValue1 = var1Consequence;
        consequenceValue2 = var2Consequence;

        consequenceFunction1 = null;
        consequenceFunction2 = null;

        timeLastUsed = 0.0f;
        isActive = active;
    }


    #endregion

    public void applyConsequences()
	{
        //always SUMS the consequence value with the consequence variable, so need to pass the right value
        //right value to be passed will be seen in ACTIONSMANAGER

        double consequenceFinalValue1 = 0.0f;
        if (consequenceFunction1 == null) consequenceFinalValue1 = consequenceValue1;
        else consequenceFinalValue1 = consequenceFunction1();

		switch (consequenceVar1)
		{
		case MiscInfo.variableTypes.availableBO:
			ResourceManager.instance.numberOfAvailableBorderOfficers += (int)consequenceFinalValue1;
            ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.availableHouses:
			ResourceManager.instance.numberOfAvailableHouses += (int)consequenceFinalValue1;
            ResourceManager.instance.numberOfTotalHouses += (int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.baseTaxPerCitizen:
			ResourceManager.instance.baseTaxPerCitizen += consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.borderResources:
			ResourceManager.instance.borderResources += (int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.budgetBaseValue:
			ResourceManager.instance.BudgetBaseValue += consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.costOfBO:
            CommerceManager.instance.border_officer_buy_price += consequenceFinalValue1;
            CommerceManager.instance.border_officer_sell_price += consequenceFinalValue1 / 2.0f;
			break;
		case MiscInfo.variableTypes.costOfBorderResources:
            CommerceManager.instance.border_resource_buy_price += consequenceFinalValue1;
            CommerceManager.instance.border_resource_sell_price += consequenceFinalValue1 / 2.0f;
			break;
		case MiscInfo.variableTypes.costOfHouse:
            CommerceManager.instance.house_buy_price += consequenceFinalValue1;
			CommerceManager.instance.house_sell_price += consequenceFinalValue1 / 2.0f;
            break;
		case MiscInfo.variableTypes.costOfSocialResources:
            CommerceManager.instance.social_resource_buy_price += consequenceFinalValue1;
            CommerceManager.instance.social_resource_sell_price += consequenceFinalValue1 / 2.0f;
			break;
		case MiscInfo.variableTypes.criminalityRate:
			StatsManager.instance.criminalityRate += consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.internationalOpinion:
			StatsManager.instance.internationalOpinion+=consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.legalPopulation:
			StatsManager.instance.legalPopulation+=(int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.playerCurrentMoney:
			ResourceManager.instance.playerCurrentMoney+=(int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.publicOpinion:
			StatsManager.instance.publicOpinionOnImmigrants+=consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.socialResources:
			ResourceManager.instance.socialResources+=(int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.taxVariation:
			ResourceManager.instance.taxVariation+=consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.totalBO:
			ResourceManager.instance.numberOfTotalBorderOfficers+=(int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.totalHouses:
			ResourceManager.instance.numberOfTotalHouses+=(int)consequenceFinalValue1;
			break;
		case MiscInfo.variableTypes.unemployementRate:
			StatsManager.instance.unemploymentRate+=consequenceFinalValue1;
			break;
		default:
			break;

		}

		if (consequenceVar2 != MiscInfo.variableTypes.NULL)
		{
            double consequenceFinalValue2 = 0.0f;
            if (consequenceFunction2 == null) consequenceFinalValue2 = consequenceValue2;
            else consequenceFinalValue2 = consequenceFunction2();

            switch (consequenceVar2)
			{
			case MiscInfo.variableTypes.availableBO:
                ResourceManager.instance.numberOfAvailableBorderOfficers += (int)consequenceFinalValue2;
                ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceFinalValue2;
                break;
			case MiscInfo.variableTypes.availableHouses:
				ResourceManager.instance.numberOfAvailableHouses += (int)consequenceFinalValue2;
                ResourceManager.instance.numberOfTotalHouses += (int)consequenceFinalValue2;
                break;
			case MiscInfo.variableTypes.baseTaxPerCitizen:
				ResourceManager.instance.baseTaxPerCitizen += consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.borderResources:
				ResourceManager.instance.borderResources += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.budgetBaseValue:
				ResourceManager.instance.BudgetBaseValue += consequenceFinalValue2;
				break;
		    case MiscInfo.variableTypes.costOfBO:
                CommerceManager.instance.border_officer_buy_price += consequenceFinalValue2;
                CommerceManager.instance.border_officer_sell_price += consequenceFinalValue2 / 2.0f;
			    break;
		    case MiscInfo.variableTypes.costOfBorderResources:
                CommerceManager.instance.border_resource_buy_price += consequenceFinalValue2;
                CommerceManager.instance.border_resource_sell_price += consequenceFinalValue2 / 2.0f;
			    break;
		    case MiscInfo.variableTypes.costOfHouse:
                CommerceManager.instance.house_buy_price += consequenceFinalValue2;
			    CommerceManager.instance.house_sell_price += consequenceFinalValue2 / 2.0f;
                break;
		    case MiscInfo.variableTypes.costOfSocialResources:
                CommerceManager.instance.social_resource_buy_price += consequenceFinalValue2;
                CommerceManager.instance.social_resource_sell_price += consequenceFinalValue2 / 2.0f;
			    break;
			case MiscInfo.variableTypes.criminalityRate:
				StatsManager.instance.criminalityRate += consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.internationalOpinion:
				StatsManager.instance.internationalOpinion += consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.legalPopulation:
				StatsManager.instance.legalPopulation += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.playerCurrentMoney:
				ResourceManager.instance.playerCurrentMoney += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.publicOpinion:
				StatsManager.instance.publicOpinionOnImmigrants += consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.socialResources:
				ResourceManager.instance.socialResources += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.taxVariation:
				ResourceManager.instance.taxVariation += consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.totalBO:
				ResourceManager.instance.numberOfTotalBorderOfficers += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.totalHouses:
				ResourceManager.instance.numberOfTotalHouses += (int)consequenceFinalValue2;
				break;
			case MiscInfo.variableTypes.unemployementRate:
				StatsManager.instance.unemploymentRate += consequenceFinalValue2;
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
		ResourceManager.instance.playerCurrentMoney-= (long)actionCost;

		//turn off button
		assignedButton.SetActive(false);

		//gets time used, make action inactive
		timeLastUsed= TimerManager.time;
		isActive = false;
		applyConsequences ();
	}

    public void actionUsed(double cost)
    {
        Debug.Log("Did " + actionName);
        //if it's still in cooldown, do nothing
        if (!isActive)
        {
            Debug.Log("e está inativo");
            return;
        }


        //deduct cost
        ResourceManager.instance.playerCurrentMoney -= (long)cost;

        //turn off button
        assignedButton.SetActive(false);

        //gets time used, make action inactive
        timeLastUsed = TimerManager.time;
        isActive = false;
        applyConsequences();
    }

    public bool checkIfCooledDown()
	{
		//compare current time with time last used, if bigger than cooldown period, can be used again
		if (TimerManager.time - timeLastUsed >= actionCooldownPeriod)
		{
			isActive = true;
            if (VisualManager.instance.action_panel_is_active)
            {
                assignedButton.SetActive(true);
            }

            return true;
		}
		return false;

	}

}
