using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    GameObject target;
    Rigidbody2D bulletbody;
    public float speed;
    public int shotDamage;

    void Start()
    {
        bulletbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 moveDirection = target.transform.position - transform.position;
        bulletbody.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * speed;

        //float rotate = Mathf.Atan2(-moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rotate + 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<playerHealth>().takeDamage(shotDamage);
            //Debug.Log("Damage : " + shotDamage);
            //Debug.Log("playerHealth : " + target.gameObject.GetComponent<playerHealth>().health);
            Destroy(gameObject);
        }
    }
}
