using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit;
    public int damage;
    private float projectileHilang;
    float direction;
    private BoxCollider2D boxColider;
    private GameObject enemy;

    void Awake()
    {
        boxColider = GetComponent<BoxCollider2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);
        if(projectileHilang >= 5){
            gameObject.SetActive(false);
        }
        projectileHilang += Time.deltaTime;
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        gameObject.SetActive(false);
        if(other.gameObject.tag == "Enemy"){
            enemy.GetComponent<enemyHealth>().takeDamage(50);
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        gameObject.SetActive(false);
        enemyHealth health = other.GetComponent<enemyHealth>();
        bossHealth health2 = other.GetComponent<bossHealth>();  
        if(health != null)
        {
            health.takeDamage(damage);
        }
        
        if(health2 != null)
        {
            health2.takeDamage(damage);
        }
    }

    public void SetDirection(float _direction){
        projectileHilang = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction){
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    
}
