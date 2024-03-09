using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpPower;
    private Rigidbody2D body;
    public bool ground;
    public GameObject kaki;
    private Animator anim;

    private float horizontalInput;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        // if(Input.GetKey(KeyCode.Space) && ground){
        //     jump();
        // }
        if(horizontalInput < 0){
            transform.localScale = new Vector2(-1,1);
        }else if(horizontalInput > 0){
            transform.localScale = new Vector2(1,1);
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("ground", ground);
    }

    public void jump(){
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
        ground = false;
    }

    public bool canAttack(){
        return horizontalInput == 0 && ground;
    }
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if(collision.gameObject.tag == "Ground"){
    //         ground = true;
    //     }
    // }
}
