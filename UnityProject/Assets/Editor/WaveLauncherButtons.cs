using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImmigrantWaveLauncher))]
public class WaveLauncherButtons : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ImmigrantWaveLauncher myScript = (ImmigrantWaveLauncher)target;
        if (GUILayout.Button("New Wave"))
        {
            myScript.RandomInstantaneousWaveInstance();
        }

        /*if (GUILayout.Button("New Super Wave"))
        {

        }*/

    }



}
