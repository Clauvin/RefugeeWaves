using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImmigrantManager : MonoBehaviour {

	public static ImmigrantManager instance;

	public List<ImmigrantWave> legalWaves;//holds the waves of legal immigrants
	public List<ImmigrantWave> illegalWaves;


	public int numberOfLegalImmigrants;
	public int numberOfIllegalImmigrants;

	public int numberOfNaturalizedImmigrants;//how many immigrants you have helped get citizenship

    public void WaveReceived(GameObject onda)
    {

        //Receber onda de imigrantes
        ImmigrantWave imigrantes = onda.GetComponent<ImmigrantWave>();

        //Quantos imigrantes temos?
        int quant_imigrantes = imigrantes.numberOfImmigrants;

        //Temos casas disponíveis?
        if (ResourceManager.instance.numberOfAvailableHouses > 0)
        {
            //Temos casas suficientes?
            if (ResourceManager.instance.numberOfAvailableHouses >= quant_imigrantes)
            {
                //Se sim, resolvido.
                ResourceManager.instance.numberOfAvailableHouses -= quant_imigrantes;
                legalWaveArrived(new ImmigrantWave(quant_imigrantes, Time.time, true));
                quant_imigrantes = 0;
            }
            else
            {
                //Se não, em frente.
                legalWaveArrived(new ImmigrantWave(ResourceManager.instance.numberOfAvailableHouses, Time.time, true));
                quant_imigrantes -= ResourceManager.instance.numberOfAvailableHouses;
                ResourceManager.instance.numberOfAvailableHouses = 0;
            }
        }

        //já cuidamos de todos?
        if (quant_imigrantes > 0)
        {
            //Hora da defesa.
            //Temos soldados suficientes?
            if (ResourceManager.instance.numberOfAvailableBorderOfficers >= quant_imigrantes)
            {
                //Se sim, ok.
                ResourceManager.instance.numberOfAvailableBorderOfficers -= quant_imigrantes;
                quant_imigrantes = 0;
            }
            else
            {
                //Se não...
                quant_imigrantes -= ResourceManager.instance.numberOfAvailableBorderOfficers;
                ResourceManager.instance.numberOfAvailableBorderOfficers = 0;
            }
        }

        //temos ilegais?
        if (quant_imigrantes > 0)
        {
            illegalWaveArrived(new ImmigrantWave(quant_imigrantes, Time.time, false));
        }

    }

	public void illegalWaveArrived(ImmigrantWave illegalW)
	{
		//illegal wave arrived in country
		illegalWaves.Add(illegalW);
		//add that to total illegals
		numberOfIllegalImmigrants+= illegalW.numberOfImmigrants;
	}

	public void legalWaveArrived (ImmigrantWave legalW)
	{
		//legal wave arrived in country
		legalWaves.Add(legalW);
		//add that to total legals
		numberOfLegalImmigrants+= legalW.numberOfImmigrants;
	}

	public void checkForLegalizedImmigrantsVisas()
	{
		//Beginning of a new month. Check if (legal) immigrants cn get visas
		foreach (ImmigrantWave immigrant in legalWaves)
		{
			if (immigrant.checkIfBecameLegal ())//if this immigrant wave can become part of the country now
			{
				StatsManager.instance.legalPopulation+= immigrant.numberOfImmigrants;
				numberOfNaturalizedImmigrants+= immigrant.numberOfImmigrants;//to be used as statistics in the end
				//delete wave of immigrants; part of the country now
				legalWaves.Remove(immigrant);
			}
		}
	}

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

		legalWaves = new List<ImmigrantWave> ();
		illegalWaves = new List<ImmigrantWave> ();
		numberOfNaturalizedImmigrants = 0;
		numberOfLegalImmigrants = 0;
		numberOfIllegalImmigrants = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
