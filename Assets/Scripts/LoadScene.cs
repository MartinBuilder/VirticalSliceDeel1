﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    private void SceneLoader(string Scene)
    {
        SceneManager.LoadScene(Scene);

    }


}