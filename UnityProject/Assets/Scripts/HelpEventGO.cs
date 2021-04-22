using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEventGO : MonoBehaviour {

	public void DeactivateThis()
    {
		transform.parent.parent.gameObject.active = false;
	}

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
