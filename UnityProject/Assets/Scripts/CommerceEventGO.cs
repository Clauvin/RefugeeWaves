using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics_3;
using UnityEngine.UI;

public class CommerceEventGO : MonoBehaviour {

    public delegate double BuyOrSellValue();

    public BuyOrSellValue buy_value;
    public BuyOrSellValue sell_value;

    public Commerce_Actions commerce_action = Commerce_Actions.Open_Commerce;

    public MiscInfo.variableTypes what_is_being_bought_sold;

    public void CheckBuyAction()
    {
        if (IsBuyable())
        {
            //buy_function();
            Destroy(this.gameObject);
        }
        else
        {

        }
        //se puder comprar, ótimo, usar buy_function para comprar e fechar a janela.
        //se não puder comprar, avisar o porquê.
        
    }

    public void CheckSellAction()
    {
        //se puder vender, ótimo, usar sell_function para vender e fechar a janela.
        //se não puder vender, avisar o porquê.
    }

    public void PressedOKEventButton()
	{
       
		

	}

    public void PressedCancelEventButton()
    {
        //Destroy this Random Event Popup
        Destroy(this.gameObject);

    }

    private int GetQuantity()
    {
        string text = GetComponentInChildren<Image>().GetComponentInChildren<InputField>().text;
        if (text == "") return 0;
        else return int.Parse(text);
    }

    private bool IsBuyable()
    {
        int quantity = GetQuantity();

        if (quantity > 0)
        {
            if (ResourceManager.instance.playerCurrentMoney - quantity * buy_value() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;
    }

    private bool IsSellable()
    {
        return false;
        /*int quantity = GetQuantity();

        if (quantity > 0)
        {
            if (ResourceManager.instance.playerCurrentMoney - quantity * buy_value() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;*/
    }

    public void Commerce()
    {
        switch (commerce_action)
        {
            case (Commerce_Actions.Buying):
                BuyStuff();
                break;
            case (Commerce_Actions.Selling):
                SellStuff();
                break;
            default:
                break;
        }
    }

    public void BuyStuff()
    {
        double spent = buy_value() * GetQuantity();

        ResourceManager.instance.playerCurrentMoney -= (int)spent;

        switch (what_is_being_bought_sold)
        {
            case MiscInfo.variableTypes.availableBO:
                ResourceManager.instance.numberOfAvailableBorderOfficers += GetQuantity();
                ResourceManager.instance.numberOfTotalBorderOfficers += GetQuantity();
                break;
            case MiscInfo.variableTypes.availableHouses:
                ResourceManager.instance.numberOfAvailableHouses += GetQuantity();
                ResourceManager.instance.numberOfTotalHouses += GetQuantity();
                break;
            case MiscInfo.variableTypes.borderResources:
                ResourceManager.instance.borderResources += GetQuantity();
                break;
            case MiscInfo.variableTypes.socialResources:
                ResourceManager.instance.socialResources += GetQuantity(); ;
                break;
            default:
                break;
        }
    }

    public void SellStuff()
    {
        double gained = sell_value() * GetQuantity();

        ResourceManager.instance.playerCurrentMoney += (int)gained;

        switch (what_is_being_bought_sold)
        {
            case MiscInfo.variableTypes.availableBO:
                ResourceManager.instance.numberOfAvailableBorderOfficers -= GetQuantity();
                ResourceManager.instance.numberOfTotalBorderOfficers -= GetQuantity();
                break;
            case MiscInfo.variableTypes.availableHouses:
                ResourceManager.instance.numberOfAvailableHouses -= GetQuantity();
                ResourceManager.instance.numberOfTotalHouses -= GetQuantity();
                break;
            case MiscInfo.variableTypes.borderResources:
                ResourceManager.instance.borderResources -= GetQuantity();
                break;
            case MiscInfo.variableTypes.socialResources:
                ResourceManager.instance.socialResources -= GetQuantity(); ;
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
