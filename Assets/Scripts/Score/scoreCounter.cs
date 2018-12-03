using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    private Text textComponent;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            textComponent.text = "score: " + score;
        }
    }

    void Start()
    {
        textComponent = GetComponent<Text>();
        Score = 10;
    }


    /*
    void Update()
    {
        textComponent.text = "score: " + score;
    }   
    */
}

   




