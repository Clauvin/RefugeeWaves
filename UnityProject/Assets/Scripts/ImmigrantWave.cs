using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmigrantWave {


	//Holds information for an immigrant wave(can be big or small)

	public int numberOfImmigrants;
	public float timeOfArrival; //time it arrived in your country
	public bool isLegalWave; //true if they're legal immigrants

	public bool becameCitizens; //true if they are now legal citizens



	public ImmigrantWave(int nImm, float t, bool legal)
	{
		numberOfImmigrants = nImm;
		timeOfArrival = t;
		isLegalWave = legal;
		becameCitizens = false;//always starts with false

	}




}
