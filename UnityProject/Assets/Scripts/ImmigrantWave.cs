using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds information for an immigrant wave(can be big or small)
/// </summary>
public class ImmigrantWave : MonoBehaviour {

    #region Classe Para Salvar
    [System.Serializable]
    public class ImmigrantWaveSavePackage
    {
        public int _numberOfImmigrants;
        public float _timeOfArrival;
        public float _timeToBecomeLegal;
        public bool _isLegalWave;
        public bool _becameCitizens;
    }
    #endregion

    public ImmigrantWaveSavePackage immigrant_wave_save_package;

    #region Public Variables
    public int numberOfImmigrants {
        get { return immigrant_wave_save_package._numberOfImmigrants; }
        set { immigrant_wave_save_package._numberOfImmigrants = value; }
    }

    //time it arrived in your country
    public float timeOfArrival {
        get { return immigrant_wave_save_package._timeOfArrival; }
        set { immigrant_wave_save_package._timeOfArrival = value; }
    }

    //time it takes for a wave to become part of the country(if they entered legally)
    public float timeToBecomeLegal {
        get { return immigrant_wave_save_package._timeToBecomeLegal; }
        set { immigrant_wave_save_package._timeToBecomeLegal = value; }
    }

    //true if they're legal immigrants
    public bool isLegalWave {
        get { return immigrant_wave_save_package._isLegalWave; }
        set { immigrant_wave_save_package._isLegalWave = value; }
    }

    //true if they are now legal citizens
    public bool becameCitizens {
        get { return immigrant_wave_save_package._becameCitizens; }
        set { immigrant_wave_save_package._becameCitizens = value; }
    }
    #endregion

    public ImmigrantWaveSavePackage GetImmigrantWaveSavePackage() { return immigrant_wave_save_package; }

    public void SetImmigrantWaveSavePackage(ImmigrantWaveSavePackage sp)
    {
        immigrant_wave_save_package = sp;
    }

    public bool checkIfBecameLegal()
	{
		if (isLegalWave && Time.time - timeOfArrival >= timeToBecomeLegal)
			return true;
		return false;
	}

	public ImmigrantWave(int nImm, float t, bool legal)
	{
        immigrant_wave_save_package = new ImmigrantWaveSavePackage();
        numberOfImmigrants = nImm;
		timeOfArrival = t;
		isLegalWave = legal;
		becameCitizens = false;//always starts with false
	}

    public ImmigrantWave(ImmigrantWaveSavePackage iwsp)
    {
        immigrant_wave_save_package = iwsp;
    }




}
