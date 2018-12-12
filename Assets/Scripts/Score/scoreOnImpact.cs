using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOnImpact : MonoBehaviour {

    [SerializeField]
    private int scoreValue = 1;

    private scoreCounter scorecounter;

    void Start () {
        scorecounter = GameObject.FindObjectOfType<scoreCounter>();
        Debug.Log(scorecounter.Score);
	}
	
	
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wood" && collision.relativeVelocity.magnitude > 0)
        {
            scorecounter.Score += scoreValue;
            Debug.Log(Mathf.RoundToInt(collision.relativeVelocity.magnitude));
        }
        

        switch (Mathf.RoundToInt(collision.relativeVelocity.magnitude))
        {
            case 16:
                
                break;
            

        }
        
    }
}
