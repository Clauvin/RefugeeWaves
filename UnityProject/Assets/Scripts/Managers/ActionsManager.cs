using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour {

    #region Public Variables
    public static ActionsManager instance;

	public List<PlayerAction> possibleActions = new List<PlayerAction> ();

    public List<CommerceAction> possibleCommerceActions = new List<CommerceAction>();

    public List<GameObject> buttons;//buttons to be assigned to each action

    public GameObject commerceEventPrefab;

	public float weekLength = 15.0f;
    #endregion

    public void createVisualCommerceEvent(string title, string description)
    {
        //nope, no pausing, for tension reasons
        //TimeManager.instance.pauseGame();

        //instantiates a prefab with the info of the event
        GameObject newEvent = (GameObject)Instantiate(commerceEventPrefab);

        //make it a child of the MainCanvas and adjust its scale
        newEvent.transform.SetParent(GameObject.Find("MainCanvas").transform, false);
        //newEvent.transform.localScale = new Vector3 (1, 1, 1);

        //change the values of the text boxes
        newEvent.transform.Find("CommerceEventPanel/EventTitle").GetComponent<Text>().text = title;
        newEvent.transform.Find("CommerceEventPanel/EventDescription").GetComponent<Text>().text = description;
    }

    public void executeAction(int actionIndex)
	{
		possibleActions[actionIndex-1].actionUsed ();
	}

    public void executeCommerce(int commerceIndex)
    {
        possibleCommerceActions[commerceIndex - 1].createThisVisualCommerceEvent();
    }

    // Use this for initialization
    void Start () {
		instance = this;

        //Create all possible actions

        #region Research Actions
        //'Research' actions
        possibleActions.Add(ActionConstructor.BuildUnnecessaryLandmarks());

		possibleActions.Add(ActionConstructor.EncourageYoungProfessionals());

		possibleActions.Add (ActionConstructor.CallThePolice());

		possibleActions.Add(ActionConstructor.CanIHazSomeHelp());

		possibleActions.Add(ActionConstructor.HolaGringo());

		possibleActions.Add(ActionConstructor.TheyDontLookSoBad());

		possibleActions.Add (ActionConstructor.MikasaSuCasa());
        #endregion

        #region Building Actions
        //Resource building actions
        possibleActions.Add(ActionConstructor.Houses());

		possibleActions.Add(ActionConstructor.SocialResources());

		possibleActions.Add(ActionConstructor.BorderOfficers());

		possibleActions.Add(ActionConstructor.BorderResources());
        #endregion

        possibleCommerceActions.Add(ActionConstructor.CommerceHouses());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
