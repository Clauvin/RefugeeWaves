using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {

	public GameObject creditsGO;
    public GameObject load_button;

    public void LoadMainMenu()
    {
        Basics_3.LoadScene.LoadMainMenu();
    }

    public void LoadMainGameplay()
    {
        Basics_3.LoadScene.LoadMainGameplay();
    }

    public void LoadMainWithSaveFile()
    {
        DontDestroyOnLoad(FindObjectOfType<LoadFromMainMenu>());
        LoadMainGameplay();
        FindObjectOfType<LoadFromMainMenu>().only_once = true;
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
        if (load_button != null)
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.waves"))
            {
                load_button.SetActive(true);
            }
            else load_button.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
