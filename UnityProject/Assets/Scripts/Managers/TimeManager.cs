using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public static TimeManager instance;

	public bool gamePaused;
	public float timeLastPaused, timeLastUnpaused;//when started counting again; new 0
	public float timeElapsed;//saves time already elapsed in case user pauses
	public float weekLength = 15.0f;//in seconds
	public int year, month, week; // all start at 1
	public int gameDuration = 2;//in years
	public bool gameOver;


	//GO's and Text

	GameObject weekGO, monthGO, yearGO;
	Text weekText, monthText, yearText; 


	public void pauseGame()
	{
		Debug.Log ("Game Paused");
		gamePaused = true;
		//saves elapsed time
		timeElapsed = Time.time -timeLastUnpaused;
		timeLastPaused = Time.time;
	}

	public void unpauseGame()
	{
		Debug.Log ("Game Unpaused");

		gamePaused = false;
		timeLastUnpaused = Time.time;
	}


	public void checkForPassageOfWeek()
	{
		if (timeElapsed+ (Time.time-timeLastUnpaused)>=weekLength)
		{
			//reset counters, use timeLastUpaused as a checkpoint for next time period
			timeElapsed=0.0f;
			timeLastUnpaused = Time.time;
			//one week has passed
			week++;
			weekText.text = week.ToString();
			checkForPassageOfMonth ();
		}
	}


	public void checkForPassageOfMonth()
	{
		if (week > 4)
		{
			//a month has passed
			week = 1;
			weekText.text = week.ToString();
		
			month++;
			monthText.text = month.ToString();

			checkForPassageOfYear ();
		}
	}

	public void checkForPassageOfYear()
	{
		if (month > 12)
		{
			//a year has passed
			month=1;
			monthText.text = month.ToString();

			year++;
			yearText.text = year.ToString();

			checkForEndOfGame ();
		}
	}

	public void checkForEndOfGame()
	{
		//if x years have passed...
		if (year > gameDuration)
		{
			//game over, time's up
			gameOver=true;
			gamePaused = true;
			Debug.Log ("Game Over, time is up");
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
		year = 1;
		month = 1;
		week = 1;
		timeLastUnpaused = 0;
		timeLastPaused = 0;
		gamePaused = false;
		gameOver = false;


		weekText = weekGO.GetComponent<Text>();
		monthText = monthGO.GetComponent<Text> ();
		yearText = yearGO.GetComponent<Text> ();

		weekText.text = week.ToString();
		monthText.text = month.ToString();
		yearText.text = year.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		checkForPassageOfWeek ();
	}
}
