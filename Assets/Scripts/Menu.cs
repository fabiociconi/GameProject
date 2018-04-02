﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
    public void LoadScene(int levelNumber)
    {
        SceneManager.LoadScene("Level" + levelNumber.ToString());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
