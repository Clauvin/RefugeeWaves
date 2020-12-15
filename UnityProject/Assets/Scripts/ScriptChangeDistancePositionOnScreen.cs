using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChangeDistancePositionOnScreen : MonoBehaviour
{

    public bool gambiarra = true;

    public void ChangeDistanciaPosition()
    {
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ScriptFixedRatio fixed_ratio = camera.GetComponent<ScriptFixedRatio>();
        float x = Screen.width; float y = Screen.height;
        float percentage_of_x = camera.rect.x; float percentage_of_y = camera.rect.y;

        float extra_position_x = x * percentage_of_x; float extra_position_y = y * percentage_of_y;
        extra_position_y *= -1;

        Vector3 new_position = GetComponent<RectTransform>().position;
        new_position.x += extra_position_x;
        new_position.y += extra_position_y;
        GetComponent<RectTransform>().position = new_position;
    }

    void Update()
    {
        if (gambiarra)
        {
            ChangeDistanciaPosition();
            gambiarra = false;
        }
    }


}
