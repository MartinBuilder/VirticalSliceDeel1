using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{

    public float thrust;
    public Rigidbody rb;
    public Transform catapult;
    public ParticleSystem trail;
    
    float distance = 10;
    private Vector3 cal;
    private bool trailactive;

    private float xForce;
    private float yForce;

    void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("MainCamera");
        varGameObject.GetComponent<CameraScript>().enabled = false;

        rb = GetComponent<Rigidbody>();
        trail = GetComponent<ParticleSystem>();

        rb.useGravity = false;
        
        trail.Stop();
    }

    void Update()
    {
        cal = new Vector3(rb.transform.position.x - catapult.transform.position.x, rb.transform.position.y - catapult.transform.position.y,0);

        if(cal.x <= 0)
        {
            xForce = Mathf.Abs(cal.x);
        }
        else
        {
            xForce = -Mathf.Abs(cal.x);
        }
        if(cal.y <= 0)
        {
            yForce = Mathf.Abs(cal.y);
        }
        else
        {
            yForce = -Mathf.Abs(cal.y);
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

        trail.Play();

        GameObject varGameObject = GameObject.FindWithTag("MainCamera");
        varGameObject.GetComponent<CameraScript>().enabled = true;
    }
}