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

    //CommerceActions List
    #region Buy/Sell Values
    public double house_buy_price = 300.0f;
    public double house_buy_multiplier = 1.0f;
    public double house_sell_price = 150.0f;
    public double house_sell_multiplier = 1.0f;

    public double social_resource_buy_price = 100.0f;
    public double social_resource_buy_multiplier = 1.0f;
    public double social_resource_sell_price = 50.0f;
    public double social_resource_sell_multiplier = 1.0f;

    public double border_officer_buy_price = 125.0f;
    public double border_officer_buy_multiplier = 1.0f;
    public double border_officer_sell_price = 62.5f;
    public double border_officer_sell_multiplier = 1.0f;

    public double border_resource_buy_price = 75.0f;
    public double border_resource_buy_multiplier = 1.0f;
    public double border_resource_sell_price = 37.5f;
    public double border_resource_sell_multiplier = 1.0f;
    #endregion

    public List<GameObject> buttons;//buttons to be assigned to each action

    //Function to create Commerce Actions
    //Function to exceute Commerce Actions

    void Awake()
    {
        instance = new CommerceManager();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
