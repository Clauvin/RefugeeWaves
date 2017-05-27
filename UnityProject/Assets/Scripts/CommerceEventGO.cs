using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics_3;
using UnityEngine.UI;

public class CommerceEventGO : MonoBehaviour {

    public delegate void BuyOrSellFunction(int quant);
    public delegate bool IsBuyableOrSellable();

    public BuyOrSellFunction buy_function;
    public BuyOrSellFunction sell_function;

    public IsBuyableOrSellable is_buyable;
    public IsBuyableOrSellable is_sellable;

    public Commerce_Actions acao_de_comercio = Commerce_Actions.Open_Commerce;

    public void CheckBuyAction()
    {
        if (true)
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
        //Destroy this Random Event Popup
        Debug.Log(GetQuantity());
		Destroy(this.gameObject);

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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
