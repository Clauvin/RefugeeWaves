using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CommerceAction : MonoBehaviour {

    public string actionName;
    public string actionDescription;

    public GameObject assignedButton;

    public delegate void consequenceFunction();

    #region Consequence Variables
    public consequenceFunction buyValueFunction;
    public consequenceFunction sellValueFunction;

    public PlayerAction doFunction;
    #endregion

    #region Cooldown Variables
    public float actionCooldownPeriod;

    public float timeLastUsed;//saves time action was last used
    public bool isActive;//tells if action can be used or if it's cooling down
    #endregion

    #region Public Constructors
    public CommerceAction(string actName, string actDescription, GameObject assignButton, consequenceFunction bFunction,
        consequenceFunction sFunction, PlayerAction dFunction, float actCoolPeriod)
    {
        actionName = actName;
        actionDescription = actDescription;
        assignedButton = assignButton;

        buyValueFunction = bFunction;
        sellValueFunction = sFunction;
        doFunction = dFunction;

        actionCooldownPeriod = actCoolPeriod;

        timeLastUsed = 0.0f;
        isActive = true;
    }
    #endregion

    public void createVisualCommerceEvent(string title, string description, UnityAction evento)
    {
        //nope, no pausing, for tension reasons
        //TimeManager.instance.pauseGame();

        //instantiates a prefab with the info of the event
        GameObject newEvent = (GameObject)Instantiate(ActionsManager.instance.commerceEventPrefab);

        //make it a child of the MainCanvas and adjust its scale
        newEvent.transform.SetParent(GameObject.Find("MainCanvas").transform, false);

        //change the values of the text boxes
        newEvent.transform.Find("CommerceEventPanel/EventTitle").GetComponent<Text>().text = title;
        newEvent.transform.Find("CommerceEventPanel/EventDescription").GetComponent<Text>().text = description;
        newEvent.transform.Find("CommerceEventPanel/OkButton").GetComponent<Button>().onClick.AddListener(evento);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
