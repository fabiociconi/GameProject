using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public float attackRange;

    public enum State { Idle, Chasing, Attacking };

    private State currentState;
    private float myCollisionRadius;

    void Start()
    {
        currentState = State.Idle;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            if (currentState == State.Idle)
            {
                StartCoroutine(Attack());
            }

            currentState = State.Idle;
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

        while (percent <= 0.8 )
        {
            percent += Time.deltaTime * attackSpeed;
            float interpolation = percent;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }

        currentState = State.Attacking;
    }
}
