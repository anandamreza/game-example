using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit;
    float direction;
    private BoxCollider2D boxColider;

    void Awake()
    {
        boxColider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        gameObject.SetActive(false);
        Debug.Log("Test");
    }

    public void SetDirection(float _direction){
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