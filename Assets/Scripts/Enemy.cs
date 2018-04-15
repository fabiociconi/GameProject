using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRange;


    public enum State { Idle, Stopping, Attacking };
    private Animator animator;


    private Transform target;
    private State currentState;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        currentState = State.Idle;
        animator = GetComponent<Animator>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Environment"))
        {
            //Destroy(this.gameObject);
            currentState = State.Stopping;
            animator.SetBool("Walk", false);
            animator.SetBool("Atack", false);
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            currentState = State.Attacking;
            animator.SetBool("Walk", false);
            animator.SetBool("Atack", true);
        }
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            StartCoroutine(Attack());



        }
        else
        {
            currentState = State.Idle;
            animator.SetBool("Walk", false);
            animator.SetBool("Atack", false);
        }


    }

    //move the zombie to attack the player
    IEnumerator Attack()
    {
        float attackSpeed = 0.4f;
        float percent = 0;


        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 attackPosition = target.position - dirToTarget * 0.5f;

        while (percent <= 0.8 && currentState == State.Idle)
        {
            percent += Time.deltaTime * attackSpeed;
            float interpolation = percent;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);
            animator.SetBool("Walk", true);
            animator.SetBool("Atack", false);

            yield return null;
        }



        //currentState = State.Attacking;

    }
}