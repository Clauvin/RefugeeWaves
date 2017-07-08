using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Basics_3;

public class CommerceAction : MonoBehaviour {

    public string actionName;
    public string actionDescription;

    public GameObject assignedButton;

    public delegate double consequenceFunction(int i);

    #region Consequence Variables
    public consequenceFunction buyValueFunction;
    public consequenceFunction sellValueFunction;

    public CommerceEventGO.BuyOrSellValue buy_value;
    public CommerceEventGO.BuyOrSellValue sell_value;

    // of course, since this is a Commerce Window of one kind of product each time,
    // we know that the first variable to deal with is money.

    public MiscInfo.variableTypes consequenceVar;

    #endregion

    public string commerce_title;
    public string commerce_buying_title;
    public string commerce_selling_title;

    #region Save Package
    [System.Serializable]
    public class CommerceActionCooldownSavePackage
    {
        public float _actionCooldownPeriod;

        public float _timeLastUsed; //saves time action was last used
        public bool _isActive; //tells if action can be used or if it's cooling down
    }
    #endregion

    public CommerceActionCooldownSavePackage commerce_action_cooldown_save_package;

    public CommerceActionCooldownSavePackage GetCommerceActionCooldownSavePackage()
    {
        return commerce_action_cooldown_save_package;
    }

    public void SetCommerceActionCooldownSavePackage(CommerceActionCooldownSavePackage save_package)
    {
        commerce_action_cooldown_save_package = save_package;
    }

    #region Cooldown Variables
    public float actionCooldownPeriod
    {
        get { return commerce_action_cooldown_save_package._actionCooldownPeriod; }
        set { commerce_action_cooldown_save_package._actionCooldownPeriod = value; }
    }

    public float timeLastUsed
    {
        get { return commerce_action_cooldown_save_package._timeLastUsed; }
        set { commerce_action_cooldown_save_package._timeLastUsed = value; }
    }
    public bool isActive
    {
        get { return commerce_action_cooldown_save_package._isActive; }
        set { commerce_action_cooldown_save_package._isActive = value; }
    }
    #endregion

    #region Public Constructors
    public CommerceAction(string actName, string actDescription, GameObject assignButton,
        string title, string buying_title, string selling_title, consequenceFunction bFunction,
        consequenceFunction sFunction, CommerceEventGO.BuyOrSellValue b_value, CommerceEventGO.BuyOrSellValue s_value,
        MiscInfo.variableTypes whats_being_sold, float actCoolPeriod)
    {
        commerce_action_cooldown_save_package = new CommerceActionCooldownSavePackage();
        actionName = actName;
        actionDescription = actDescription;
        assignedButton = assignButton;

        commerce_title = title;
        commerce_buying_title = buying_title;
        commerce_selling_title = selling_title;

        buyValueFunction = bFunction;
        sellValueFunction = sFunction;

        buy_value = b_value;
        sell_value = s_value;

        actionCooldownPeriod = actCoolPeriod;

        timeLastUsed = 0.0f;
        isActive = true;

        consequenceVar = whats_being_sold;
    }
    #endregion

    public void createVisualCommerceEvent(string title, string description)
    {
        //nope, no pausing, for tension reasons
        //TimeManager.instance.pauseGame();

        //erase other CommerceWindows
        if (GameObject.FindGameObjectsWithTag("Commerce Window").GetLength(0) != 0)
        {
            GameObject[] lista = GameObject.FindGameObjectsWithTag("Commerce Window");
            foreach (GameObject window in lista)
            {
                Destroy(window);
            }
        }

        //instantiates a prefab with the info of the event
        GameObject newEvent = (GameObject)Instantiate(ActionsManager.instance.commerceEventPrefab);

        //make it a child of the MainCanvas and adjust its scale
        newEvent.transform.SetParent(GameObject.Find("WindowsCanvas").transform, false);
        newEvent.name = "Commerce Window";

        newEvent.transform.GetComponent<CommerceEventGO>().ca = this;

        newEvent.transform.GetComponent<CommerceEventGO>().title = commerce_title;
        newEvent.transform.GetComponent<CommerceEventGO>().buying_title = commerce_buying_title;
        newEvent.transform.GetComponent<CommerceEventGO>().selling_title = commerce_selling_title;


        newEvent.transform.GetComponent<CommerceEventGO>().buy_value = buy_value;
        newEvent.transform.GetComponent<CommerceEventGO>().sell_value = sell_value;
        newEvent.transform.GetComponent<CommerceEventGO>().commerce_action = Commerce_Actions.Buying;
        newEvent.transform.GetComponent<CommerceEventGO>().what_is_being_bought_sold = consequenceVar;

        //change the values of the text boxes
        newEvent.transform.Find("CommerceEventPanel/EventTitle").GetComponent<Text>().text =
            commerce_buying_title + " " + title;
        newEvent.transform.Find("CommerceEventPanel/EventDescription").GetComponent<Text>().text = description;
        newEvent.transform.Find("CommerceEventPanel/PricesDescription").GetComponent<Text>().text =
            "Preço de compra de uma unidade: " + buy_value().ToString() + ".";
        newEvent.transform.Find("CommerceEventPanel/PricesDescription").GetComponent<Text>().text +=
            "\nPreço de venda de uma unidade: " + sell_value().ToString() + ".";

    }

    public void createThisVisualCommerceEvent()
    {
        createVisualCommerceEvent(actionName, actionDescription);
    }

    public void activateCooldown()
    {
        //turn off button
        assignedButton.SetActive(false);

        //gets time used, make action inactive
        timeLastUsed = TimerManager.time;
        isActive = false;
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
