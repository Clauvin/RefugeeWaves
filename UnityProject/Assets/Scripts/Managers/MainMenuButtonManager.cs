using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {

	public GameObject creditsGO;


    public void CarregaMenuPrincipal()
    {
        Basicas_2.CarregaCena.CarregaMenuPrincipal();
    }

    public void CarregaGameplay()
    {
        Basicas_2.CarregaCena.CarregaGameplay();
    }

    public void FechaJogo()
    {
        Basicas_2.CarregaCena.FechaJogo();
    }


	public void showResponsibles()
	{
		creditsGO.SetActive (true);
	}

	public void hideResponsibles()
	{
		creditsGO.SetActive (false);
	}

    // Use this for initialization
    void Start () {
		hideResponsibles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
