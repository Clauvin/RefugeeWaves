using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour {
    public GameObject moneyGO, actionsGO, houseGO, unemployementGO, criminalityGO,
	BOGO, SocialResGO, BorderResGO;


	public static VisualManager instance;

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


	public void toggleActionsPanel()
	{
		foreach(Transform t in actionsGO.transform)
		{
			t.gameObject.SetActive(!t.gameObject.activeSelf);
		}
	}



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
