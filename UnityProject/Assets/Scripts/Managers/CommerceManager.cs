using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store data regarding prices for buying/selling things
/// Also stores the last amount bought of something, so the player don't have to input the same preferred value
/// all the time.
/// </summary>
public class CommerceManager : MonoBehaviour {

    public static CommerceManager instance;

    #region Classe Para Salvar
    [System.Serializable]
    public class CommerceSavePackage
    {
        public double _house_buy_price = 300.0f;
        public double _house_buy_multiplier = 1.0f;
        public double _house_sell_price = 150.0f;
        public double _house_sell_multiplier = 1.0f;

        public double _social_resource_buy_price = 10.0f;
        public double _social_resource_buy_multiplier = 1.0f;
        public double _social_resource_sell_price = 5.0f;
        public double _social_resource_sell_multiplier = 1.0f;

        public double _border_officer_buy_price = 125.0f;
        public double _border_officer_buy_multiplier = 1.0f;
        public double _border_officer_sell_price = 62.5f;
        public double _border_officer_sell_multiplier = 1.0f;

        public double _border_resource_buy_price = 7.50f;
        public double _border_resource_buy_multiplier = 1.0f;
        public double _border_resource_sell_price = 3.75f;
        public double _border_resource_sell_multiplier = 1.0f;
    }
    #endregion

    public CommerceSavePackage commerce_save_package;

    //CommerceActions List
    #region Buy/Sell Values
    public double house_buy_price {
        get { return commerce_save_package._house_buy_price; }
        set { commerce_save_package._house_buy_price = value; }
    }

    public double house_buy_multiplier {
        get { return commerce_save_package._house_buy_multiplier; }
        set { commerce_save_package._house_buy_multiplier = value; }
    }

    public double house_sell_price {
        get { return commerce_save_package._house_sell_price; }
        set { commerce_save_package._house_sell_price = value; }
    }

    public double house_sell_multiplier {
        get { return commerce_save_package._house_sell_multiplier; }
        set { commerce_save_package._house_sell_multiplier = value; }
    }

    public double social_resource_buy_price {
        get { return commerce_save_package._social_resource_buy_price; }
        set { commerce_save_package._social_resource_buy_price = value; }
    }

    public double social_resource_buy_multiplier {
        get { return commerce_save_package._social_resource_buy_multiplier; }
        set { commerce_save_package._social_resource_buy_multiplier = value; }
    }

    public double social_resource_sell_price {
        get { return commerce_save_package._social_resource_sell_price; }
        set { commerce_save_package._social_resource_sell_price = value; }
    }

    public double social_resource_sell_multiplier {
        get { return commerce_save_package._social_resource_sell_multiplier; }
        set { commerce_save_package._social_resource_sell_multiplier = value; }
    }

    public double border_officer_buy_price {
        get { return commerce_save_package._border_officer_buy_price; }
        set { commerce_save_package._border_officer_buy_price = value; }
    }

    public double border_officer_buy_multiplier {
        get { return commerce_save_package._border_officer_buy_multiplier; }
        set { commerce_save_package._border_officer_buy_multiplier = value; }
    }

    public double border_officer_sell_price {
        get { return commerce_save_package._border_officer_sell_price; }
        set { commerce_save_package._border_officer_sell_price = value; }
    }
    public double border_officer_sell_multiplier {
        get { return commerce_save_package._border_officer_sell_multiplier; }
        set { commerce_save_package._border_officer_sell_multiplier = value; }
    }

    public double border_resource_buy_price {
        get { return commerce_save_package._border_resource_buy_price; }
        set { commerce_save_package._border_resource_buy_price = value; }
    }

    public double border_resource_buy_multiplier {
        get { return commerce_save_package._border_resource_buy_multiplier; }
        set { commerce_save_package._border_resource_buy_multiplier = value; }
    }

    public double border_resource_sell_price {
        get { return commerce_save_package._border_resource_sell_price; }
        set { commerce_save_package._border_resource_sell_price = value; }
    }
    public double border_resource_sell_multiplier {
        get { return commerce_save_package._border_resource_sell_multiplier; }
        set { commerce_save_package._border_resource_sell_multiplier = value; }
    }
    #endregion

    public CommerceSavePackage GetCommerceSavePackage()
    {
        return commerce_save_package;
    }

    public void SetCommerceSavePackage(CommerceSavePackage r)
    {
        commerce_save_package = r;
    }

    public List<GameObject> buttons;//buttons to be assigned to each action

    //Function to create Commerce Actions
    //Function to exceute Commerce Actions

    void Awake()
    {
        instance = this;
        commerce_save_package = new CommerceSavePackage();
    }

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
