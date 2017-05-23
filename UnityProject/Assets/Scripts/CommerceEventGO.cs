using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics_3;

public class CommerceEventGO : MonoBehaviour {

    /*
     * Delegate functions to store:
     * 
     * 1 - Check buy values;
     * 2 - Check sell values;
     * 3 - Buy;
     * 4 - Sell;
     * 5 - Close window;
     * 
     */

    public delegate void BuyOrSellFunction(int quant);
    public delegate bool IsBuyableOrSellable();

    public BuyOrSellFunction buy_function;
    public BuyOrSellFunction sell_function;

    public IsBuyableOrSellable is_buyable;
    public IsBuyableOrSellable is_sellable;

    public Commerce_Actions acao_de_comercio = Commerce_Actions.Open_Commerce;

    public void CheckBuyAction()
    {

    }

    public void CheckSellAction()
    {

    }

    public void PressedOKEventButton()
	{
		//Destroy this Random Event Popup
		Destroy(this.gameObject);

	}

    public void PressedCancelEventButton()
    {
        //Destroy this Random Event Popup
        Destroy(this.gameObject);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
