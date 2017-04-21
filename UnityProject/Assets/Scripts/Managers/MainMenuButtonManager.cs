using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {

	public GameObject creditsGO;


    public void CarregaMenuPrincipal()
    {
        Basicas_2.LoadScene.CarregaMenuPrincipal();
    }

    public void CarregaGameplay()
    {
        Basicas_2.LoadScene.CarregaGameplay();
    }

    public void FechaJogo()
    {
        Basicas_2.LoadScene.FechaJogo();
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

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
