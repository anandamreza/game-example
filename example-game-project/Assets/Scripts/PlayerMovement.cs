using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpPower;
    private Rigidbody2D body;
    private bool ground;

    private Animator anim;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if(Input.GetKey(KeyCode.Space) && ground){
            jump();
        }
        if(horizontalInput < 0){
            transform.localScale = new Vector2(-1,1);
        }else if(horizontalInput > 0){
            transform.localScale = new Vector2(1,1);
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("ground", ground);
    }

    private void jump(){
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
        ground = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            ground = true;
        }
    }
}
