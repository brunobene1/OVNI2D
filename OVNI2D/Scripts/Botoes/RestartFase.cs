﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFase : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void RestartAFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
