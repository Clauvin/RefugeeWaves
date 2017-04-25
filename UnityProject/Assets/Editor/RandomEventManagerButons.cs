using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RandomEventManager))]
public class RandomEventManagerButons : Editor {

    private string an_event_happens = "An Event Happens";

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RandomEventManager myScript = (RandomEventManager)target;
        if (GUILayout.Button(an_event_happens))
        {
            myScript.AnEventHappens();
        }
    }
}
