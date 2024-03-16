using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int damage;
    public playerHealth health;
    public float timer;

    private void Update()
    {
        timer = Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timer = 0;
            if(timer > 2)
            {
                health.takeDamage(damage);
                timer = 0;
            }
        }
    }

}
