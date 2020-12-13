using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VFXWaveLauncher))]
public class VFXWaveLauncherButtons : Editor
{
    private string activate_timer = "Activate Timer";
    private string deactivate_timer = "Deactivate Timer";

    private string which_string;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        VFXWaveLauncher myScript = (VFXWaveLauncher)target;
        if (GUILayout.Button("New Wave"))
        {
            myScript.RandomInstantaneousWaveInstance();
        }

        if (GUILayout.Button("New Super Wave"))
        {
            myScript.RandomInstantaneousWaveInstance(true);
        }

        if (GUILayout.Button("Destroy All Travelling Waves"))
        {
            myScript.DeleteAllTravellingWaves();
        }

        if (myScript.GetWaveInstantiationTimer())
        {
            which_string = deactivate_timer;
        }
        else
        {
            which_string = activate_timer;
        }

        if (GUILayout.Button(which_string))
        {
            myScript.ToggleWaveInstantiationTimer();
        }

    }



}

