using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour {

	public static VisualManager instance;

    public GameObject moneyGO, actionsGO, houseGO, unemployementGO, criminalityGO,
        BOGO, SocialResGO, BorderResGO;

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
            if ((t.GetComponent<Button>() != null) && (action_panel_is_active))
            {
                if (ActionsManager.instance.possibleActions
                        [t.GetComponent<PositionInFunctionArray>().position - 1].isActive)
                            t.gameObject.SetActive(action_panel_is_active);
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
	}

    public void Start() {
		instance = this;

		hideAllPanels ();

    }

}
