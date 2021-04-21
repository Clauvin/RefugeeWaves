using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour {

	public static VisualManager instance;

    public GameObject moneyGO, actionsGO, houseGO, unemployementGO, criminalityGO,
        BOGO, SocialResGO, BorderResGO, timeMultiplier1xGO, timeMultiplier2xGO,
        timeMultiplier3xGO, pausebuttonGO;

    //At the moment, does nothing.
    public bool action_panel_is_active;

    #region Show/Hide Money Panel Functions
    public void showMoneyPanel()
    {
		foreach(Transform t in moneyGO.transform)
		{
			t.gameObject.SetActive(true);
		}
    }
    public void hideMoneyPanel() {
		foreach(Transform t in moneyGO.transform)
		{
			t.gameObject.SetActive(false);
		}
    }
    #endregion

    public void toggleActionsPanel()
	{
        //invert value of action_panel_is_active
        action_panel_is_active = action_panel_is_active != true;

        foreach (Transform t in actionsGO.transform)
        {
            if ((t.GetComponent<Button>() != null) && (t.GetComponent<Text>() == null) && (action_panel_is_active))
            {
                if (t.GetComponent<PositionInFunctionArray>() == null) t.gameObject.SetActive(action_panel_is_active);
                else if (t.GetComponent<PositionInFunctionArray>().action_or_commerce == "Action")
                {
                    if (ActionsManager.instance.possibleActions
                        [t.GetComponent<PositionInFunctionArray>().position - 1].isActive)
                        t.gameObject.SetActive(action_panel_is_active);
                }
                else if (t.GetComponent<PositionInFunctionArray>().action_or_commerce == "Commerce")
                {
                    if (ActionsManager.instance.possibleCommerceActions
                        [t.GetComponent<PositionInFunctionArray>().position - 1].isActive)
                        t.gameObject.SetActive(action_panel_is_active);
                }


            }
            else
            {
                t.gameObject.SetActive(action_panel_is_active);
            } 
        }

    }


    #region Show/Hide House Panel Functions
    public void showHousePanel()
	{
		foreach(Transform t in houseGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}

	public void hideHousePanel() {
		foreach(Transform t in houseGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide Unemployment Panel Functions
    public void showUnemploymentPanel()
	{
		foreach(Transform t in unemployementGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}

	public void hideUnemploymentPanel() {
		foreach(Transform t in unemployementGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide Criminality Panel Functions
    public void showCriminalityPanel()
	{
		foreach(Transform t in criminalityGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}

	public void hideCriminalityPanel() {
		foreach(Transform t in criminalityGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide BO Panel Functions
    public void showBOPanel()
	{
		foreach(Transform t in BOGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}

	public void hideBOPanel() {
		foreach(Transform t in BOGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide Border Res Panel Functions
    public void showBorderResPanel()
	{
		foreach(Transform t in BorderResGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}

	public void hideBorderResPanel() {
		foreach(Transform t in BorderResGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide Social Res Panel Functions
    public void showSocialResPanel()
	{
		foreach(Transform t in SocialResGO.transform)
		{
			t.gameObject.SetActive(true);
		}
	}
	public void hideSocialResPanel() {
		foreach(Transform t in SocialResGO.transform)
		{
			t.gameObject.SetActive(false);
		}
	}
    #endregion

    #region Show/Hide Time Multiplier 1x Panel Functions
    public void showTimeMultiplier1xPanel()
    {
        foreach (Transform t in timeMultiplier1xGO.transform)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void hideTimeMultiplier1xPanel()
    {
        foreach (Transform t in timeMultiplier1xGO.transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    #endregion Show/Hide Time Multiplier 1x Panel Functions

    #region Show/Hide Time Multiplier 2x Panel Functions
    public void showTimeMultiplier2xPanel()
    {
        foreach (Transform t in timeMultiplier2xGO.transform)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void hideTimeMultiplier2xPanel()
    {
        foreach (Transform t in timeMultiplier2xGO.transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    #endregion Show/Hide Time Multiplier 2x Panel Functions

    #region Show/Hide Time Multiplier 3x Panel Functions
    public void showTimeMultiplier3xPanel()
    {
        foreach (Transform t in timeMultiplier3xGO.transform)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void hideTimeMultiplier3xPanel()
    {
        foreach (Transform t in timeMultiplier3xGO.transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    #endregion Show/Hide Time Multiplier 3x Panel Functions

    #region Show/Hide Pause Button Panel Functions
    public void showPauseButtonPanel()
    {
        foreach (Transform t in pausebuttonGO.transform)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void hidePauseButtonPanel()
    {
        foreach (Transform t in pausebuttonGO.transform)
        {
            t.gameObject.SetActive(false);
        }
    }
    #endregion

    public void hideAllPanels()
	{
		toggleActionsPanel ();
		hideCriminalityPanel ();
		hideHousePanel ();
		hideMoneyPanel ();
		hideUnemploymentPanel ();
		hideSocialResPanel ();
		hideBorderResPanel ();
		hideBOPanel ();
        hidePauseButtonPanel();
	}

    public void Start() {
		instance = this;

		//hideAllPanels ();

    }

}
