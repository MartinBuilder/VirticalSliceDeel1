﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
    Vector2 mousePosition;
    bool overSprite;
    bool beingDragged;


    float distance = 10;

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;
    }


}
