using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds information for an immigrant wave(can be big or small)
/// </summary>
[System.Serializable]
public class ImmigrantWave : MonoBehaviour {


    
    #region Public Variables
    public int numberOfImmigrants;
	public float timeOfArrival; //time it arrived in your country
	public float timeToBecomeLegal;//time it takes for a wave to become part of the country(if they entered legally)
	public bool isLegalWave; //true if they're legal immigrants

	public bool becameCitizens; //true if they are now legal citizens
    #endregion

    public bool checkIfBecameLegal()
	{
		if (isLegalWave && Time.time - timeOfArrival >= timeToBecomeLegal)
			return true;
		return false;
	}

	public ImmigrantWave(int nImm, float t, bool legal)
	{
		numberOfImmigrants = nImm;
		timeOfArrival = t;
		isLegalWave = legal;
		becameCitizens = false;//always starts with false

	}




}
