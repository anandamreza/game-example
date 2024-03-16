using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedMovement : MonoBehaviour
{
    private Animator anim;
    private bool enemyGo;
    private float timerGo;

    [Header("Enemy Size")]
    [SerializeField] private float size_x;
    [SerializeField] private float size_y;
    [SerializeField] private float size_z;

    [Header("Enemey Movement")]
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int destination;
    public float idleTime;

    [Header("Enemy Chasing")]
    private Transform playerTransform;
    public float chaseSpeed;
    public float chaseDistance;

    [Header("Range Attack")]
    public float shootingRange;
    public GameObject gun;
    public GameObject bullet;
    //public float fireRate;
    //private float nextFireTime;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Start()
    {
        destination = 0;
        enemyGo = true;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < chaseDistance)
        {
            anim.SetBool("IsEnemyChasing?", true);
            //Debug.Log("chaseMode activated\n");

            if (transform.position.x > playerTransform.position.x && distanceToPlayer > shootingRange)
            {
                transform.localScale = new Vector3(-size_x, size_y, size_z);
                transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
                //Debug.Log("Enemy is chasing to the left...\n");
            }
            else if (transform.position.x < playerTransform.position.x && distanceToPlayer > shootingRange)
            {
                transform.localScale = new Vector3(size_x, size_y, size_z);
                transform.position += Vector3.right * chaseSpeed * Time.deltaTime;
                //Debug.Log("Enemy is chasing to the right...\n");
            }
            else
            { 
                if (transform.position.x < playerTransform.position.x)
                {
                    anim.SetBool("IsEnemyAttacking?", true);
                    transform.localScale = new Vector3(size_x, size_y, size_z);
                    //Fire();
                }
                else
                {
                    anim.SetBool("IsEnemyAttacking?", true);
                    transform.localScale = new Vector3(-size_x, size_y, size_z);
                    //Fire();
                }
            }
        }
        else
        {
            anim.SetBool("IsEnemyAttacking?", false);
            anim.SetBool("IsEnemyChasing?", false);

            if (destination == 0 && enemyGo == true)
            {
                //Debug.Log("Roaming to 0\n");
                anim.SetBool("IsEnemyMoving?", true);
                transform.localScale = new Vector3(size_x, size_y, size_z);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[0].position) < 0.2f)
                {
                    StartCoroutine(reachPoint());
                }
            }
            else if (destination == 1 && enemyGo == true)
            {
                //Debug.Log("Roaming to 1\n");
                anim.SetBool("IsEnemyMoving?", true);
                transform.localScale = new Vector3(-size_x, size_y, size_z);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoint[1].position) < 0.2f)
                {
                    StartCoroutine(reachPoint());
                }
            }
        }
    }

    public void Fire()
    {
        //if(nextFireTime < Time.time)
        //{
        //  transform.localScale = new Vector3(size_x, size_y, size_z);
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
        //  nextFireTime = Time.time + fireRate;
        //}
    }

    private IEnumerator reachPoint()
    {
        Debug.Log("test : ");
        anim.SetBool("IsEnemyMoving?", false);
        enemyGo = false;
        timerGo = 0;
        timerGo += Time.deltaTime;
        yield return new WaitForSeconds(idleTime);
        destination = destination == 0 ? 1 : 0;
        enemyGo = true;
        anim.SetBool("IsEnemyMoving?", true);
    }
}
