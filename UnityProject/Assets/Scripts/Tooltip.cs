using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    public GameObject text;

	public void showPanel()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        text.SetActive(true);
    }
    public void hiddenPanel() {
        this.gameObject.GetComponent<Image>().enabled = false;
        text.SetActive(false);
    }
    public void Start() {
        this.gameObject.GetComponent<Image>().enabled = false;
        text.SetActive(false);
    }

}
