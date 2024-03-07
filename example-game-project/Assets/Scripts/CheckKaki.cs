using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKaki : MonoBehaviour
{
    PlayerMovement pm;

    void Awake()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && pm.ground){
            pm.jump();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground"){
            pm.ground = true;
        }
    }
}
