﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEventGO : MonoBehaviour {

	public void DestroyThis()
    {
		Destroy(this.transform.parent.parent.gameObject);
	}

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
