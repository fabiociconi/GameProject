using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float followRange = 40;
    public float attackRange = 5;
    public enum State { Idle, Following, Attacking};

    private Animator animator;
    private Transform target;
    private State currentState = State.Idle;
    private float distanceToPlayer;
    private Rigidbody2D rBody;
    private Vector2 XLimits;
    private Vector2 YLimits;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        currentState = State.Idle;
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();

        XLimits = GameObject.Find("Main Camera").GetComponent<CameraHandler>().XLimits;
        YLimits = GameObject.Find("Main Camera").GetComponent<CameraHandler>().YLimits;
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > followRange * 2 || 
            transform.position.x < XLimits.x - 28 || transform.position.x > XLimits.y + 28 ||
            transform.position.y < YLimits.x - 15 || transform.position.y > YLimits.y + 15)
        {
            Destroy(gameObject);
        }

        if (rBody.velocity.x > 0 || rBody.velocity.y > 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Following:
                Follow();
                break;

            case State.Attacking:
                Attack();
                break;
        }
    }

    void Idle()
    {
        if (distanceToPlayer < followRange)
        {
            currentState = State.Following;
        }
    }

    private void Follow()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
        
        rBody.velocity = (target.transform.position - transform.position).normalized * 11;
    }

    private void Attack()
    {
        if (distanceToPlayer > attackRange)
        {
            currentState = State.Following;
            animator.SetBool("Atack", false);
        }

        animator.SetBool("Atack", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && currentState == State.Attacking)
        {
            GameManager.instance.RemoveHealth(1);
            return;
        }

        currentState = State.Attacking;
    }
}