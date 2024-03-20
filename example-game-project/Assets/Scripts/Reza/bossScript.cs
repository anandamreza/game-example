using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private bossHealth bhealth;

    [Header("Attack")]
    public GameObject bossGun;
    public GameObject bossBullet;
    public float bossRange;
    public bool finalBoss;

    [Header("Spawner")]
    public GameObject spawnEnemy;
    public GameObject bossSpawnMelee;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bhealth = GetComponent<bossHealth>();
    }
    public void Start()
    {

    }

    public void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < bossRange)
        {
            if(!finalBoss)
            {
                anim.SetBool("IsBossAttacking?", true);
            }
            else
            {
                if (bhealth.health >= 1000)
                {
                    anim.SetBool("IsBossAttacking?", true);
                }
                else if (bhealth.health < 500 && bhealth.health > 0)
                {
                    anim.SetBool("IsBossAttacking?", false);
                    anim.SetBool("IsBossFinalAttacking?", true);
                }
            }
        }
    }

    public void bossFire()
    {
        Instantiate(bossBullet, bossGun.transform.position, Quaternion.identity);
    }

    public void bossSuper()
    {
        Instantiate(bossBullet, bossGun.transform.position, Quaternion.identity);
        Instantiate(bossBullet, bossGun.transform.position, Quaternion.identity);
    }
}
