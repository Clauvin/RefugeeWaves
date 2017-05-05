using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour {

    #region Public Variables
    public static ActionsManager instance;

	public List<PlayerAction> possibleActions = new List<PlayerAction> ();

	public List<GameObject> buttons;//buttons to be assigned to each action

	public float weekLength = 15.0f;
    #endregion

    public void executeAction(int actionIndex)
	{
		possibleActions[actionIndex-1].actionUsed ();
	}
    


    // Use this for initialization
    void Start () {
		instance = this;

		//Create all possible actions

		//'Research' actions
		possibleActions.Add(ActionConstructor.BuildUnnecessaryLandmarks());

		possibleActions.Add(ActionConstructor.EncourageYoungProfessionals());

		possibleActions.Add (ActionConstructor.CallThePolice());

		possibleActions.Add(ActionConstructor.CanIHazSomeHelp());

		possibleActions.Add(ActionConstructor.HolaGringo());

		possibleActions.Add(ActionConstructor.TheyDontLookSoBad());

		possibleActions.Add (ActionConstructor.MikasaSuCasa());

		//Resource building actions
		possibleActions.Add(ActionConstructor.Houses());

		possibleActions.Add(ActionConstructor.SocialResources());

		possibleActions.Add(ActionConstructor.BorderOfficers());

		possibleActions.Add(ActionConstructor.BorderResources());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
