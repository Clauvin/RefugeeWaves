using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPausedShowsElseDont : MonoBehaviour {

	//holds the pause text and panel 
	public GameObject pausePanel;
	public GameObject pauseText;

	public void TogglePause()
	{
		//turns the pause elements on/off
		if (TimeManager.instance.gamePaused)
		{
			pausePanel.SetActive (true);
			pauseText.SetActive (true);
		} 
		else
		{
			pausePanel.SetActive (false);
			pauseText.SetActive (false);
		}
	}

	public void Start()
	{
		pausePanel.SetActive (false);
		pauseText.SetActive (false);

	}

    public void IfButtonPressed()
    {
        if (TimeManager.instance.gamePaused) IfPaused();
        else IfUnpaused();
    }

    public void IfPaused()
    {
        this.gameObject.SetActive(true);
    }

    public void IfUnpaused()
    {
        this.gameObject.SetActive(false);
    }
}
