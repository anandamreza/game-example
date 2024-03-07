using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackTime;
    public Transform firePoint;
    public GameObject[] fireBalls;
    private float chargeTime;
    private Animator anim;
    private PlayerMovement pm;
    void Awake()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        anim.SetBool("charging", Input.GetMouseButton(0));
        if(Input.GetMouseButton(0)){
            chargeTime += Time.deltaTime;
            
        }
        if(Input.GetMouseButtonUp(0) && chargeTime >= attackTime){
            Attack();
        }
        if(Input.GetMouseButtonUp(0) && chargeTime < attackTime){
            chargeTime = 0;
        }
    }

    private void Attack(){
        chargeTime = 0;
        Debug.Log("Fire");

        fireBalls[0].transform.position = firePoint.position;
        fireBalls[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
