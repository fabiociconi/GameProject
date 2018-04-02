using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public float bulletSpeed = 40;

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
        Transform hip = rightGun
               ? player.transform.Find("Bones/Hip/RightArmIk")
               : player.transform.Find("Bones/Hip/LeftArmIk");

        rightGun = !rightGun;

        var bulletObject = Instantiate(bullet, hip.transform.position, Quaternion.identity);
        var targetDirection = (transform.position - player.transform.position);

        bulletObject.GetComponent<Rigidbody2D>().velocity = targetDirection.normalized * bulletSpeed;
        Destroy(bulletObject, 1.0f);

        canShoot = false;

        Invoke("ShootEnd", gun == 0 ? 0.3f : 0.1f);
    }

    private void ShootEnd()
    {
        canShoot = true;
    }
}
