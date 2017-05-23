using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {

	public GameObject creditsGO;

    public void LoadMainMenu()
    {
        Basics_3.LoadScene.LoadMainMenu();
    }

    public void LoadMainGameplay()
    {
        Basics_3.LoadScene.LoadMainGameplay();
    }

    public void CloseGame()
    {
        Basics_3.LoadScene.CloseGame();
    }

	public void ShowResponsibles()
	{
		creditsGO.SetActive (true);
	}

	public void HideResponsibles()
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
