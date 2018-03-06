using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;

    private bool rightGun = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform hip;

            if (rightGun)
            {
                hip = player.transform.Find("Bones/Hip/RightArmIk");
            }
            else
            {
                hip = player.transform.Find("Bones/Hip/LeftArmIk");
            }

            rightGun = !rightGun;

            player.GetComponent<Animator>().SetBool("Shot", true);


            var bulletObject = Instantiate(bullet, hip.transform.position, Quaternion.identity);
            bulletObject.GetComponent<Rigidbody2D>().AddForce((transform.position - player.transform.position) * 5, ForceMode2D.Impulse);
            Destroy(bulletObject, 1.0f);
        }else if (Input.GetMouseButtonUp(0))
        {
            player.GetComponent<Animator>().SetBool("Shot", false);
        }
    }
}
