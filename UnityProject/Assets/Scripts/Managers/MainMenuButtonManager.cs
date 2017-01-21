using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {

    public static void CarregaMenuPrincipal()
    {
        Basicas_2.CarregaCena.CarregaMenuPrincipal();
    }

    public static void CarregaGameplay()
    {
        Basicas_2.CarregaCena.CarregaGameplay();
    }

    public static void FechaJogo()
    {
        Basicas_2.CarregaCena.FechaJogo();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
