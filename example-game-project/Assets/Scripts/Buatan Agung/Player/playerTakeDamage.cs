using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int damage;
    private playerHealth health;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.takeDamage(damage);
        }
    }

}
