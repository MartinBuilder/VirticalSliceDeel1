using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverUI;
    ///public GameObject endScore;
    public static bool die = false;


    void Start()
    {
   
        GameOverUI.SetActive(false);
    }
   
	// Update is called once per frame
	void Update () {
        if (die || Input.GetKeyDown("p"))
        {
          
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            //endScore = endScore.score;

        }
    }
}
