using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class enemyBullets : MonoBehaviour
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

    private void Update()
    {
        //Debug.Log("bullet pos : " + Mathf.Abs(bulletbody.transform.position.x));
        //Debug.Log("Player pos : " + Mathf.Abs(target.transform.position.x));
        if (Mathf.Abs(target.transform.position.x) - Mathf.Abs(bulletbody.transform.position.x) < 0.1 
            && Mathf.Abs(target.transform.position.y) - Mathf.Abs(bulletbody.transform.position.y) < 0.1)
        {
            target.gameObject.GetComponent<playerHealth>().health -= shotDamage;
            Destroy(gameObject);
        }
    }
}
