using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private enemyHealth bossHealth;

    [Header("Attack")]
    public GameObject bossGun;
    public GameObject bossBullet;
    public float bossRange;

    [Header("Spawner")]
    public GameObject spawnEnemy;
    public GameObject bossSpawnMelee;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossHealth = GetComponent<enemyHealth>();
    }
    public void Start()
    {

    }

    public void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < bossRange)
        {
            anim.SetBool("IsBossAttacking?", true);
            /*
            if (bossHealth.health >= 500)
            {
                anim.SetBool("IsBossAttacking?", true);
            }
            else if (bossHealth.health < 500 && bossHealth.health > 0)
            {
                anim.SetBool("IsBossAttacking?", false);
            }
            */
        }
    }

    public void bossFire()
    {
        Instantiate(bossBullet, bossGun.transform.position, Quaternion.identity);
    }

    public void bossSpawnEnemy()
    {
        Instantiate(spawnEnemy, bossGun.transform.position, Quaternion.identity);
    }
}
