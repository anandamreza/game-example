using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpPower;
    private Rigidbody2D body;
    private bool ground;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if(Input.GetKey(KeyCode.Space) && ground){
            jump();
        }
    }

    private void jump(){
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        ground = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            ground = true;
        }
    }
}
