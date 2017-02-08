using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPausedShowsElseDont : MonoBehaviour {

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
