using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;

    private int gun = 0;
    private bool rightGun = false;
    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gun = gun == 0
                ? 1
                : 0;

            canShoot = false;

            player.GetComponent<Animator>().SetBool("Shot", false);
            player.GetComponent<Animator>().SetInteger("Gun", gun);

            Invoke("ShootEnd", 0.1f);
        }


        if (Input.GetMouseButton(0) && canShoot)
        {
            player.GetComponent<Animator>().SetBool("Shot", true);
            Shoot();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            player.GetComponent<Animator>().SetBool("Shot", false);
        }
    }

    private void Shoot()
    {
        Transform hip;

        hip = rightGun
               ? player.transform.Find("Bones/Hip/RightArmIk")
               : player.transform.Find("Bones/Hip/LeftArmIk");

        rightGun = !rightGun;

        var bulletObject = Instantiate(bullet, hip.transform.position, Quaternion.identity);
        bulletObject.GetComponent<Rigidbody2D>().AddForce((transform.position - player.transform.position) * 5, ForceMode2D.Impulse);
        Destroy(bulletObject, 1.0f);

        canShoot = false;

        Invoke("ShootEnd", gun == 0 ? 0.3f : 0.1f);
    }

    private void ShootEnd()
    {
        canShoot = true;
    }
}
