using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
    [SerializeField] private bool isEater;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int attackDamage = 5;

    [SerializeField] private float attackTimeThreshold = 1f;
    [SerializeField] private float eatTimeThreshold = 2f;

    [SerializeField] private LayerMask bushMask;

    [HideInInspector] public bool isMoving, left;

    private Artifact artifact;
    private BushFruits fruitsTarget;

    private float attackTimer;
    private float eatTimer;

    private bool killingBush;
    private bool isAttacking;

    void Start()
    {
        if (isEater)
        {
            SearchForTarget();
            killingBush = false;
        }
        else
        {
            isAttacking = false;
        }

        artifact = GameObject.FindWithTag("Artifact").GetComponent<Artifact>();
    }

    void Update()
    {
        if (!artifact)
        {
            return;
        }

        if(isEater)
        {
            if (fruitsTarget && fruitsTarget.HasFruits() && fruitsTarget.enabled && !killingBush)
            {
                if (Vector2.Distance(transform.position, fruitsTarget.transform.position) > 0.5f)
                {
                    float step = moveSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, fruitsTarget.transform.position, step);

                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    fruitsTarget.HarvestFruits();
                    eatTimer = Time.time + eatTimeThreshold;
                    killingBush = true;
                }
            }
            else if(killingBush)
            {
                if(Time.time > eatTimer)
                {
                    fruitsTarget.EatFruits();
                    killingBush = false;

                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }

            if(fruitsTarget)
            {
                if (fruitsTarget.transform.position.x < transform.position.x)
                {
                    left = true;
                }
                else
                {
                    left = false;
                }
            }

            if(!fruitsTarget)
            {
                SearchForTarget();
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, artifact.transform.position) > 1.5f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);

                isMoving = true;
            }
            else if(!isAttacking)
            {
                isAttacking = true;
                attackTimer = Time.time + attackTimeThreshold;

                isMoving = false;
            }
            else if(isAttacking)
            {
                if(Time.time > attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attackTimeThreshold;
                }
            }

            if(artifact.transform.position.x < transform.position.x)
            {
                left = true;
            }
            else
            {
                left = false;
            }
        }
    }

    void SearchForTarget()
    {
        fruitsTarget = null;

        Collider2D[] hits;

        for (int i = 1; i < 50; i++)
        {
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);

            foreach (Collider2D hit in hits)
            {
                if (hit && hit.GetComponent<BushFruits>().HasFruits() && hit.GetComponent<BushFruits>().enabled)
                {
                    fruitsTarget = hit.GetComponent<BushFruits>();
                    break;
                }
            }

            if (fruitsTarget)
            {
                break;
            }
        }
    }

    void Attack()
    {
        artifact.TakeDamage(attackDamage);
    }
}
