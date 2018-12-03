using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOnImpact : MonoBehaviour {

    [SerializeField]
    private int scoreValue = 1;

    private scoreCounter scorecounter;

    void Start () {
        scorecounter = GameObject.FindObjectOfType<scoreCounter>();
       // scorecounter.Score = 10;
        Debug.Log(scorecounter.Score);
	}
	
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wood" && collision.relativeVelocity.magnitude > 8)
        {
            scorecounter.Score += scoreValue;
        }
        Debug.Log(collision.relativeVelocity.magnitude);
    }
}
