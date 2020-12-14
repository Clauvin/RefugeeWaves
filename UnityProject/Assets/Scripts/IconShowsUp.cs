using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconShowsUp : MonoBehaviour {

    bool it_appeared_yet = false;
    public int month_to_appear;
    public SpriteRenderer icon_to_show_up;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!it_appeared_yet)
        {
            if (month_to_appear <= TimeManager.instance.month)
            {
                icon_to_show_up.enabled = true;
                it_appeared_yet = true;
            }
        }
	}
}
