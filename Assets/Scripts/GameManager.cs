using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    public static GameManager instance = null ;
   
    public int score { get; set; }

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

 
    public void GameOver()
    {
       
    }

    public int AddScore(int aux)
    {
       // Debug.Log("Score antes: " + aux.ToString());
        score  = score + aux;
        //Debug.Log("Score depois: " + score.ToString());

        return score;
    }
}
