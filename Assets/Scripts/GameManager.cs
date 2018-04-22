using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool imune = false;
   
    public int score { get; set; }
    public int health = 100;
    private int bullets = 100;

    private void Awake()
    {
        //Debug.Log("Singleton Instance: " + gameObject.GetInstanceID());
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

    private void Update()
    {
        if (health < 1 && SceneManager.GetActiveScene().name != "FinalScene")
        {
            GameOver();
        }   
    }

    public void GameOver()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public int AddScore(int aux)
    {
       // Debug.Log("Score antes: " + aux.ToString());
        score  = score + aux;
        //Debug.Log("Score depois: " + score.ToString());

        return score;
    }

    public int AddHealth (int aux)
    {
        health = health + aux;
        return health;
    }

    public void SetImune()
    {
        imune = true;
    }

    public void SetNotImune()
    {
        imune = false;
    }

    public int RemoveHealth(int aux)
    {
        if (imune)
        {
            return health;
        }

        health = health - aux;
        return health;
    }
}
