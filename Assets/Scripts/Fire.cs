using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {

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
            int score = int.Parse(scoreValue.text);
            int newScore = score + 10;
            scoreValue.text = newScore.ToString();

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
