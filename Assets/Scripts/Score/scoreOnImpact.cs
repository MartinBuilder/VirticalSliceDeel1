using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOnImpact : MonoBehaviour {

    [SerializeField]
    private int scoreValue;

    private scoreCounter scorecounter;

    void Start () {
        scorecounter = GameObject.FindObjectOfType<scoreCounter>();
        Debug.Log(scorecounter.Score);
	}
	
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wood" && collision.relativeVelocity.magnitude > 8)
        {
            scorecounter.Score += scoreValue;
        }
        //Debug.Log(collision.relativeVelocity.magnitude);

        switch (Mathf.RoundToInt(collision.relativeVelocity.magnitude))
        {
            case 16:
                Debug.Log(Mathf.RoundToInt(collision.relativeVelocity.magnitude));
                break;
            

        }
    }
}
