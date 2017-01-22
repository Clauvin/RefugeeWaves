using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEventsManager : MonoBehaviour {

	public static VisualEventsManager instance;

	public GameObject actionsGO, moneyGO;


	public void showMoneyPanel()
    {
		foreach (Transform child in moneyGO.transform)
		{
			child.gameObject.SetActive(true);
		} 
    }
    public void hideMoneyPanel() {
		foreach (Transform child in moneyGO.transform)
		{
			child.gameObject.SetActive(false);
		} 
    }

	public void showHideEvents(){
		foreach (Transform child in actionsGO.transform)
		{
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		} 
	}
		




    public void Start() {
		instance = this;
		showHideEvents ();
		hideMoneyPanel ();
    }

}
