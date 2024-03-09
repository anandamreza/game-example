using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;

    void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int Damage)
    {
        health -= Damage;
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

}
