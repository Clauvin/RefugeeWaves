using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour {

	public static ActionsManager instance;

	public List<PlayerAction> possibleActions = new List<PlayerAction> ();


	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
