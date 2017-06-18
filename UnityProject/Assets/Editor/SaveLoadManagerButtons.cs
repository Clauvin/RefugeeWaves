using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveLoadManager))]
public class SaveLoadManagerButtons : Editor
{

    private string save_game = "Save Game";
    private string load_game = "Load Game";

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveLoadManager myScript = (SaveLoadManager)target;

        if (GUILayout.Button(save_game))
        {
            Debug.Log(Application.persistentDataPath);
            myScript.Save();
        }

        if (GUILayout.Button(load_game))
        {

        }
    }
}