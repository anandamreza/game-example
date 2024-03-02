using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Animator anim;

    //movement var
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int destination;

    //chase var
    public Transform playerTransform;
    public bool chaseMode;
    public float chaseSpeed;
    public float chaseDistance;

    private void Awake()
    {
        chaseMode = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseMode)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
            }
            else if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                transform.position += Vector3.right * chaseSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                chaseMode = true;
                anim.SetBool("IsPeterChasing?", true);
            }
            else
            {
                anim.SetBool("IsPeterChasing?", false);
            }

            if (destination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[0].position) < 0.2f)
                {
                    transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    destination = 1;
                }
            }
            else if (destination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[1].position) < 0.2f)
                {
                    transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                    destination = 0;
                }
            }
        }
    }
}
