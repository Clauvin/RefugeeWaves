using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour {

	public static ActionsManager instance;

	public List<PlayerAction> possibleActions = new List<PlayerAction> ();

	public List<GameObject> buttons;//buttons to be assigned to each action


	public float weekLength = TimeManager.instance.weekLength;


	public void executeAction(int actionIndex)
	{
		possibleActions [actionIndex-1].actionUsed ();
	}


	// Use this for initialization
	void Start () {
		instance = this;

		//Create all possible actions

		//'Research' actions
		possibleActions.Add(new PlayerAction(buttons[0],"Build unnecessary landmarks",
			"No, we don't need new bridges. But people like looking at them and need work, so we'll have one anyway",300.0,
			4*weekLength,MiscInfo.variableTypes.unemployementRate,-1*0.1*StatsManager.instance.unemployementRate));

		possibleActions.Add(new PlayerAction(buttons[1],"Encourage young professionals",
			"Make those teenagers get off their phones and work a little",400,3*weekLength,MiscInfo.variableTypes.unemployementRate,
			-1*0.07*StatsManager.instance.unemployementRate,MiscInfo.variableTypes.baseTaxPerCitizen,0.05*ResourceManager.instance.baseTaxPerCitizen));

		possibleActions.Add (new PlayerAction (buttons[2],"Call the police!",
			"New police officers should be just what these recent crime waves need!", 600, 4 * weekLength,
			MiscInfo.variableTypes.criminalityRate, -0.2*StatsManager.instance.criminalityRate));

		possibleActions.Add(new PlayerAction(buttons[3],"Can I haz some help?",
			"Since the UN wants you to help, nothing is more fair than if they help with the bills."
			+"(Obs: This likely won't work if you've been a bad boy internationally)",500,24*weekLength,
			MiscInfo.variableTypes.playerCurrentMoney,100000));

		possibleActions.Add(new PlayerAction(buttons[4],"Hola gringo!","Show people Wavestan is a nice place to live (and lure some professionals while you're at it",
			1000,6*weekLength,MiscInfo.variableTypes.legalPopulation,1000,
			MiscInfo.variableTypes.publicOpinion,
			-0.15*StatsManager.instance.publicOpinionOnImmigrants));

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
