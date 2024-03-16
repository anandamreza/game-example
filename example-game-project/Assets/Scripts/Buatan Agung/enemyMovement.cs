using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Animator anim;

    //enemy size
    [SerializeField] private float size_x;
    [SerializeField] private float size_y;
    [SerializeField] private float size_z;

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
        anim = GetComponent<Animator>();
    }

    public void Start()
    {
        destination = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            chaseMode = true;
            anim.SetBool("IsEnemyChasing?", true);
            Debug.Log("chaseMode activated\n");

            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(size_x, size_y, size_z);
                transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
                Debug.Log("Enemy is chasing to the left...\n");
            }
            else if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-size_x, size_y, size_z);
                transform.position += Vector3.right * chaseSpeed * Time.deltaTime;
                Debug.Log("Enemy is chasing to the right...\n");
            }

        }
        else
        {
            chaseMode = false;
            anim.SetBool("IsEnemyChasing?", false);

            if (destination == 0)
            {
                anim.SetBool("IsEnemyMoving?", true);
                transform.localScale = new Vector3(size_x, size_y, size_z);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[0].position) < 0.2f)
                {
                    destination = 1;
                    Debug.Log("Roaming to 1\n");
                }
            }
            else if (destination == 1)
            {
                transform.localScale = new Vector3(-size_x, size_y, size_z);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[1].position) < 0.2f)
                {
                    anim.SetTrigger("IsEnemyMoving?");
                    destination = 0;
                    Debug.Log("Roaming to 0\n");
                }
            }
        }
    }
}