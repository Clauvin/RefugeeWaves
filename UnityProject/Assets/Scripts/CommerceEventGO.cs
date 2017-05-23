using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommerceEventGO : MonoBehaviour {

    /*
     * Delegate functions to store:
     * 
     * 1 - Check buy values;
     * 2 - Check sell values;
     * 3 - Buy;
     * 4 - Sell;
     * 5 - Close window;
     * 
     */

    public void PressedOKEventButton()
	{
		//Destroy this Random Event Popup
		Destroy(this.gameObject);

	}

    public void PressedCancelEventButton()
    {
        //Destroy this Random Event Popup
        Destroy(this.gameObject);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
