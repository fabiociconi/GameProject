using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddHealth(Random.Range(5, 30));
            Destroy(gameObject);
        }
    }
}
