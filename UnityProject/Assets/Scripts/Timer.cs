using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script possível candidato à fazer companhia à biblioteca Básicas, é responsável por servir de timer para
/// outras funções.
/// </summary>
public class Timer : MonoBehaviour {

    public int time = 100;

    private float time_passed = 0.0f;
    private float start_time = 0.0f;

	// Use this for initialization
	void Start () {
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        time_passed += Time.time - start_time;
        start_time = Time.time;
        // Pegar código de passagem de tempo lá do Not Valentine
        while (time_passed >= 1.0f)
        {
            time -= 1;
            time_passed -= 1.0f;
        }

	}
}
