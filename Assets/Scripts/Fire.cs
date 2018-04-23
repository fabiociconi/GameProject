using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject blood;
    public GameObject[] items;

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
            
            var score = GameManager.instance.AddScore(10);
            scoreValue.text = score.ToString();

            Instantiate(blood, transform.position, Quaternion.identity);
            GameObject.FindGameObjectsWithTag("Canvas")[0].GetComponent<BloodUIController>().InstantiateBlood();

            int num = Random.Range(0, 100);

            if (num < 30)
            {
                Instantiate(items[0], transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
