using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounterPigs : MonoBehaviour {

    [SerializeField]
    private int scoreValue;

    private scoreCounter scorecounter;
    private Catapult catapult;

    void Start()
    {
        scorecounter = GameObject.FindObjectOfType<scoreCounter>();
        catapult = GameObject.FindObjectOfType<Catapult>();
        Debug.Log(scorecounter.Score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0 && catapult.PointsActive == true)
        {
            //Debug.Log(Mathf.RoundToInt(collision.relativeVelocity.magnitude));
            scoreValue = Mathf.RoundToInt(collision.relativeVelocity.magnitude) * 50;
            Debug.Log(scoreValue);
            scorecounter.Score += scoreValue;
        }


        switch (Mathf.RoundToInt(collision.relativeVelocity.magnitude))
        {
            case 16:

                break;
        }

        if (scoreValue >= 20)
        {
            scoreValue += 5000;
            Destroy(gameObject);
        }
    }
}
