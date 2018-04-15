using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    public float maxSpeed = 10.0f;

    private Rigidbody2D rBody;
    private Animator animator;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        Transform hip = transform.Find("Bones/Hip");
        hip.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);
        rBody.velocity = new Vector2(rBody.velocity.x, moveVert * maxSpeed);

        var walk = moveHoriz != 0 || moveVert != 0;
        animator.SetBool("Walk", walk);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return (Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg) + 180;
    }
}
