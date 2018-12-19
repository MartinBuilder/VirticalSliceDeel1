using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public float thrust;
    public float radius;
    public float power;
    public bool PointsActive;

    public Rigidbody rb;
    public Transform catapult;
    public ParticleSystem trail;
    //public ParticleSystem explotionpart;
    
    float distance = 10;
    private Vector3 cal;
    private bool trailactive;
    private bool AboutToDie;

    private float xForce;
    private float yForce;

    void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("MainCamera");
        varGameObject.GetComponent<CameraScript>().enabled = false;

        rb.useGravity = false;
        
        trail.Stop();
        PointsActive = false;
        AboutToDie = false;
    }

    void Update()
    {
        cal = new Vector3(rb.transform.position.x - catapult.transform.position.x, rb.transform.position.y - catapult.transform.position.y,0);

        if(Input.GetKey(KeyCode.Space))
        {
            Explotion();
        }

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

        PointsActive = true;
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

    void OnCollisionEnter(Collision collision)
    {
        Hit();
    }

    IEnumerator Example()
    {
        Debug.Log("test");
        if (AboutToDie)
        {
            Debug.Log("AboutToDie: True");
            yield return new WaitForSeconds(3);
            Explotion();
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

    private void Hit()
    {


        trail.Stop();

        AboutToDie = true;
        GameObject varGameObject = GameObject.FindWithTag("MainCamera");
        varGameObject.GetComponent<CameraScript>().enabled = false;
    }

    private void kill()
    {
        Destroy(gameObject);
    }

    public void Explotion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }

        //explotionpart.Play();

        kill();
    }
}