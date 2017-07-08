using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Basics_3;


public class TimeManager : MonoBehaviour {

    public static TimeManager instance;

    #region Classe Para Salvar
    [System.Serializable]
    public class TimeSavePackage
    {
        public bool _gamePaused;
        public float _timeLastPaused, _timeLastUnpaused;
        public float _timeElapsed;
        public float _weekLengthInSeconds = 5.0f;
        public int _year, _month, _week;
        public int _gameDurationInYears = 2;
        public bool _gameOver;
    }
    #endregion

    public TimeSavePackage time_save_package;

    public TimeSavePackage GetTimeSavePackage()
    {
        return time_save_package;
    }

    public void SetTimeSavePackage(TimeSavePackage r)
    {
        time_save_package = r;
    }

    #region Public Variables
    public bool gamePaused {
        get { return time_save_package._gamePaused; }
        set { time_save_package._gamePaused = value; }
    }

    //when started counting again; new 0
    public float timeLastPaused {
        get { return time_save_package._timeLastPaused; }
        set { time_save_package._timeLastPaused = value; }
    }

    public float timeLastUnpaused {
        get { return time_save_package._timeLastUnpaused; }
        set { time_save_package._timeLastUnpaused = value; }
    }

    //saves time already elapsed in case user pauses
    public float timeElapsed {
        get { return time_save_package._timeElapsed; }
        set { time_save_package._timeElapsed = value; }
    }

    //in seconds
    public float weekLengthInSeconds {
        get { return time_save_package._weekLengthInSeconds; }
        set { time_save_package._weekLengthInSeconds = value; }
    }

    // start at 1
    public int year {
        get { return time_save_package._year; }
        set { time_save_package._year = value; }
    }

    // start at 1
    public int month {
        get { return time_save_package._month; }
        set { time_save_package._month = value; }
    }

    // start at 1
    public int week {
        get { return time_save_package._week; }
        set { time_save_package._week = value; }
    }

    public int gameDurationInYears {
        get { return time_save_package._gameDurationInYears; }
        set { time_save_package._gameDurationInYears = value; }
    } 

    public bool gameOver {
        get { return time_save_package._gameOver; }
        set { time_save_package._gameOver = value; }
    }
    #endregion

    //GO's and Text
    #region GO - The UI GameObjects + UI Texts
    public GameObject weekGO, monthGO, yearGO;
	Text weekText, monthText, yearText;
    #endregion

    #region Pause/Unpause Functions
    public void PauseOrUnpause()
    {
        if (!gamePaused) pauseGame();
        else unpauseGame();
    }

	public void pauseGame()
	{
		//only happens if game was unpaused
		if (!gamePaused)
		{
			Debug.Log ("Game Paused");
			gamePaused = true;
			//saves elapsed time
			timeElapsed = Time.time - timeLastUnpaused;
			timeLastPaused = Time.time;
		}
	}

	public void unpauseGame()
	{
		//only happens if game was paused
		if (gamePaused)
		{
			Debug.Log ("Game Unpaused");

			gamePaused = false;
			timeLastUnpaused = Time.time;
		}
	}
    #endregion

    #region Check For Passage Of Time Functions
    public void checkForPassageOfWeek()
	{
		if (timeElapsed+ (Time.time-timeLastUnpaused)>=weekLengthInSeconds)
		{
			//reset counters, use timeLastUpaused as a checkpoint for next time period
			timeElapsed=0.0f;
			timeLastUnpaused = Time.time;
			//one week has passed
			week++;
			weekText.text = week.ToString();
            foreach (PlayerAction pa in ActionsManager.instance.possibleActions)
            {
                pa.checkIfCooledDown();
            }
            foreach (CommerceAction ca in ActionsManager.instance.possibleCommerceActions)
            {
                ca.checkIfCooledDown();
            }
            ImmigrantManager.instance.checkForLegalizedImmigrantsVisas();
            ResourceManager.instance.UpdateResourcesSpentInBorderOfficers();
            ResourceManager.instance.UpdateResourcesSpentInSocialResources();
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

            StatsManager.instance.calculateStatsValues();
            ResourceManager.instance.receiveNewBudget();

            checkForPassageOfYear ();

			//after every end of month, check if a random event has occurred
			RandomEventManager.instance.CheckForRandomEvents();

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
		if (year > gameDurationInYears)
		{
			//game over, time's up
			gameOver=true;
			gamePaused = true;
			Debug.Log ("Game Over, time is up");
		}
	}
    #endregion

    void WinOrLose()
    {
        if (year >= 3)
        {
            Basics_3.LoadScene.LoadVictoryScreen();
        }
        else if ((StatsManager.instance.criminalityRate >= 0.575f) && (StatsManager.instance.unemploymentRate >= 0.575f))
        {
            Basics_3.LoadScene.LoadDefeatScreen();
        }
    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

        time_save_package = new TimeSavePackage();

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
	void FixedUpdate () {
		if(!gamePaused)
			checkForPassageOfWeek ();

		if (Input.GetKeyDown (KeyCode.P))
		{
			if (gamePaused)
				unpauseGame ();
			else
				pauseGame ();
		}

	}

    void Update()
    {
        WinOrLose();
    }
}
