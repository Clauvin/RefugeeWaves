using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour {

	public static ActionsManager instance;

	public List<PlayerAction> possibleActions = new List<PlayerAction> ();

	public List<GameObject> buttons;//buttons to be assigned to each action

	public float weekLength = 15.0f;

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

		possibleActions.Add(new PlayerAction(buttons[5],"They don't look so bad, right?",
			"Help your people see just how nice those foreigners may be",600,8*weekLength,MiscInfo.variableTypes.publicOpinion,
			StatsManager.instance.publicOpinionOnImmigrants*0.8));

		possibleActions.Add (new PlayerAction (buttons[6],"Mikasa, su casa s2",
			"Show the world you accept other peoples with open arms! Come on in, don't mind the mess.", 1000,
			5 * weekLength, MiscInfo.variableTypes.internationalOpinion, StatsManager.instance.internationalOpinion * 0.7));

		//Resource buildind actions
		possibleActions.Add(new PlayerAction(buttons[7],"Build Houses","Get those puppies up so people can rest a little",
			300,1.5f*weekLength,MiscInfo.variableTypes.availableHouses,1));

		possibleActions.Add(new PlayerAction(buttons[8],"Purchase social resources","Everyone needs some soup and some soap",
			100,1*weekLength,MiscInfo.variableTypes.socialResources,1));

		possibleActions.Add(new PlayerAction(buttons[9],"Hire Border Officers","Those borders won't defend themselves",
			125,2*weekLength,MiscInfo.variableTypes.availableBO,1));

		possibleActions.Add(new PlayerAction(buttons[10],"Build Border Resources","Fuel and ammo aren't free, you know.",
			75,1*weekLength,MiscInfo.variableTypes.borderResources,1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
