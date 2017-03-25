using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImmigrantWaveLauncher))]
public class WaveLauncherButtons : Editor
{
    private string activate_timer = "Activate Timer";
    private string deactivate_timer = "Deactivate Timer";

    private string which_string;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ImmigrantWaveLauncher myScript = (ImmigrantWaveLauncher)target;
        if (GUILayout.Button("New Wave"))
        {
            myScript.RandomInstantaneousWaveInstance();
        }

        if (GUILayout.Button("New Super Wave"))
        {
            myScript.RandomInstantaneousWaveInstance(true);
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
