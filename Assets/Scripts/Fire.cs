using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{

    void FireDone()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fire")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Enemy")
        {

            var scoreValue = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<Text>();

    
            //por enquanto descontando 10 pontos fixos
            var score = GameManager.instance.AddScore(10);
            Debug.Log("ScoreClass: " + score.ToString());
            scoreValue.text = score.ToString();

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
