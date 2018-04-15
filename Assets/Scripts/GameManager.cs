using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance ;
    private int score;
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

    public void Pause(bool paused)
    {
        
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public int AddScore(int aux)
    {
        Debug.Log("Score antes: " + aux.ToString());
        score  = score + aux;
        Debug.Log("Score depois: " + score.ToString());

        return score;
    }
}
