using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmigrantManager : MonoBehaviour {

	public static ImmigrantManager instance;

	public List<ImmigrantWave> legalWaves;//holds the waves of legal immigrants
	public List<ImmigrantWave> illegalWaves;

	public int numberOfLegalizedImmigrants;//how many immigrants you have legalized


	public void illegalWaveArrived(ImmigrantWave illegalW)
	{
		//illegal wave arrived in country
		illegalWaves.Add(illegalW);
	}

	public void legalWaveArrived (ImmigrantWave legalW)
	{
		//legal wave arrived in country
		legalWaves.Add(legalW);
	}

	public void checkForLegalizedImmigrantsVisas()
	{
		//Beginning of a new month. Check if (legal) immigrants cn get visas
		foreach (ImmigrantWave immigrant in legalWaves)
		{
			if (immigrant.checkIfBecameLegal ())//if this immigrant wave can become part of the country now
			{
				StatsManager.instance.legalPopulation+= immigrant.numberOfImmigrants;
				numberOfLegalizedImmigrants+= immigrant.numberOfImmigrants;
				//delete wave of immigrants; part of the country now
				legalWaves.Remove(immigrant);
			}
		}
	}



	// Use this for initialization
	void Start () {
		instance = this;
		legalWaves = new List<ImmigrantWave> ();
		illegalWaves = new List<ImmigrantWave> ();
		numberOfLegalizedImmigrants = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
