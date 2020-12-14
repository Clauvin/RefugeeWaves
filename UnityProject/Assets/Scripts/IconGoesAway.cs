using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconGoesAway : MonoBehaviour
{

    bool it_disappeared_yet = false;
    public int month_to_disappear;
    public SpriteRenderer icon_to_disappear_yet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!it_disappeared_yet)
        {
            if (month_to_disappear <= TimeManager.instance.month)
            {
                icon_to_disappear_yet.enabled = false;
                it_disappeared_yet = true;
            }
        }
    }
}
