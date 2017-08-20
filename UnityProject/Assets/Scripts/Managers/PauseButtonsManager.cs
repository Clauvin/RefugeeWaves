using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonsManager : MonoBehaviour {

    public GameObject save_load_text;

    public void LoadMainMenu()
    {
        Basics_3.LoadScene.LoadMainMenu();
    }

    public void LoadGame()
    {
        if (SaveLoadManager.instance.Load())
        {
            save_load_text.GetComponent<Text>().text = "Game loaded";
        }
        else
        {
            save_load_text.GetComponent<Text>().text = "Load error";
        }
        
    }

    public void SaveGame()
    {
        if (SaveLoadManager.instance.Save())
        {
            save_load_text.GetComponent<Text>().text = "Game saved";
        }
        else
        {
            save_load_text.GetComponent<Text>().text = "Save error";
        }
    }

    public void EraseSaveLoadText()
    {
        save_load_text.GetComponent<Text>().text = "";
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
