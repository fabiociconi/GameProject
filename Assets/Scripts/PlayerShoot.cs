using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;

    private void OnMouseDown()
    {
        player.GetComponent<Animator>().SetBool("Shot", true);
        Transform hip = player.transform.Find("Bones/Hip");

        var bulletObject = Instantiate(bullet, hip.transform.position, Quaternion.identity);
        bulletObject.GetComponent<Rigidbody2D>().AddForce((transform.position - player.transform.position) * 5, ForceMode2D.Impulse);
        Destroy(bulletObject, 1.0f);
    }

    private void OnMouseUp()
    {
        player.GetComponent<Animator>().SetBool("Shot", false);
    }
}
