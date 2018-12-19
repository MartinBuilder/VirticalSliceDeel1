using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui: MonoBehaviour {
  
    private GameObject GameOverUI, PauseUI,WinUI;

    // Use this for initialization
    void Start()
    {
        GameOverUI = GameObject.FindWithTag("GameOver");
       
        PauseUI = GameObject.FindWithTag("Pause");
        WinUI = GameObject.FindWithTag("Win");

        GameOverUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);



    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("f"))
        {

            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
         

        }
        if (Input.GetKeyDown("w"))
        {

            WinUI.SetActive(true);
            Time.timeScale = 0f;


        }
        if (Input.GetKeyDown("g"))
        {

            PauseUI.SetActive(true);
            Time.timeScale = 0f;


        }

    }
 
    private void ChangeSceenTo(string message)
    {

        if (message == "Pause")
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0f;

        }
        else if (message == "Resume")
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }



}
