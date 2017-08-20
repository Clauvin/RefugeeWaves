using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonsManager : MonoBehaviour {

    public GameObject save_load_text;

    public void LoadMainMenu()
    {
        Basics_3.LoadScene.LoadMainMenu();
    }

    public void LoadGame()
    {
        SaveLoadManager.instance.Load();
    }

    public void SaveGame()
    {
        SaveLoadManager.instance.Save();
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
