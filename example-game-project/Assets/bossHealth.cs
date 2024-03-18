using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;


    void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameBehaviour.Instance.sceneToMoveTo();
        }
    }

}
