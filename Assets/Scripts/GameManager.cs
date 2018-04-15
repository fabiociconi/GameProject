using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float levelStartDelay = 2f;
    private Text levelText;

    private GameObject backgroundLevelTransition;
    private int level = 1;

    public static GameManager instance = null ;
    private int score = 0;
    private int health = 100;

    private void Awake()
    {
        Debug.Log("Singleton Instance: " + gameObject.GetInstanceID());
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
     
    }

    public void Transition()
    {
        levelText.text = "Level"+ level;
        SceneManager.LoadScene("Level" + level.ToString());
    }

 
    public void GameOver()
    {
        backgroundLevelTransition.SetActive(true);
        enabled = false;
    }

    public int AddScore(int aux)
    {
        Debug.Log("Score antes: " + aux.ToString());
        score  = score + aux;
        Debug.Log("Score depois: " + score.ToString());

        return score;
    }
}
