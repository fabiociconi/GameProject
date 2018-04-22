using System.Collections;
using UnityEngine;

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

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        currentState = State.Idle;
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);

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
        
        rBody.velocity = target.transform.position - transform.position;
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
        currentState = State.Attacking;
    }
}