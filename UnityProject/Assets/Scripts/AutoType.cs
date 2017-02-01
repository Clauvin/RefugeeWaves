using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {

	public string message;
	public float letterPause = 0.05f;
	public float fullStopPause = 0.2f;

	public AudioClip click;
	AudioSource audioS;
	Text textToFill;

	public IEnumerator autoType()
	{
		foreach (char letter in message.ToCharArray())
		{
			textToFill.text += letter;
			if (click)
				audioS.PlayOneShot (click);
			if (letter == '.')
				yield return new WaitForSeconds (fullStopPause);
			else
				yield return new WaitForSeconds (letterPause);
		}

	}

	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource> ();
		textToFill = gameObject.GetComponent<Text> ();
		message = textToFill.text;
		textToFill.text = "";
		StartCoroutine (autoType ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
