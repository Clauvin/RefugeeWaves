using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonsManager : MonoBehaviour {

    public void LoadMainMenu()
    {
        Basics_3.LoadScene.LoadMainMenu();
    }

    public void LoadGame()
    {
        Basics_3.LoadScene.LoadMainGameplay();
    }

    public void SaveGame()
    {
        Basics_3.LoadScene.CloseGame();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
