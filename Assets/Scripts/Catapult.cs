﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{

    public float thrust;
    public Rigidbody rb;
    public Transform catapult;
    
    float distance = 10;
    private Vector3 cal;

    private float xForce;
    private float yForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.useGravity = false;
    }

    void Update()
    {
        Debug.Log(cal);
        cal = new Vector3(rb.transform.position.x - catapult.transform.position.x, rb.transform.position.y - catapult.transform.position.y,0);
        DistantansToObject();

        xForce = Mathf.Abs(cal.x);
        yForce = Mathf.Abs(cal.y);
    }

    private void DistantansToObject()
    {
        if (catapult)
        {
            float dist = Vector3.Distance(catapult.position, transform.position);
            print("Distance to catapult: " + dist);
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;
    }
    
    private void OnMouseUp()
    {
        Debug.Log("test");
        float dist = Vector3.Distance(catapult.position, transform.position);
        if (dist >= 1)
        {
            rb.useGravity = true;
            
            Shoot();
        }
        if (dist < 1)
        {
            transform.position = new Vector3(0,0,0);
        }
    }

    private void Shoot()
    {
        rb.AddForce(transform.right * xForce * thrust);
        rb.AddForce(transform.up * yForce * thrust);
    }
}