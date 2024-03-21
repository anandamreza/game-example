using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private Animator anim;
    public int maxHealth = 100;
    public int health;
    public GameOverScript gameOver;

    public HealthBar healthBar;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void takeDamage(int Damage)
    {
        health -= Damage;
        if(health <=0)
        {
            Destroy(gameObject);
            gameOver.Setup();
        }
        healthBar.SetHealth(health);
    }

}
