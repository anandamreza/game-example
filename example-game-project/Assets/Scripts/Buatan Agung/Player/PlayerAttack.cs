using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackTime;
    public float betterAttackTime;
    public Transform firePoint;
    public GameObject[] fireBalls;
    public GameObject[] betterBalls;
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
        anim.SetBool("charging", Input.GetMouseButton(1) || Input.GetMouseButton(0) && pm.canAttack());

        if(Input.GetMouseButton(1)){
            chargeTime += Time.deltaTime;
        }else if(Input.GetMouseButton(0)){
            chargeTime += Time.deltaTime;  
        }
        if(Input.GetMouseButtonUp(1) && chargeTime >= betterAttackTime){
            if(pm.canAttack()){
                Attack2();
            }
        }else if(Input.GetMouseButtonUp(0) && chargeTime >= attackTime){
            if(pm.canAttack()){
                Attack();
            }
        }
        if(Input.GetMouseButtonUp(0) && chargeTime < attackTime){
            chargeTime = 0;
        }else if(Input.GetMouseButtonUp(1) && chargeTime < betterAttackTime){
            chargeTime = 0;
        }
    }

    private void Attack(){
        chargeTime = 0;

        fireBalls[FireBallTake()].transform.position = firePoint.position;
        fireBalls[FireBallTake()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private void Attack2(){
        chargeTime = 0;

        betterBalls[BetterBallTake()].transform.position = firePoint.position;
        betterBalls[BetterBallTake()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    int BetterBallTake(){
        for(int i=0; i< 10; i++){
            if(!betterBalls[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

    int FireBallTake(){
        for(int i=0; i< 10; i++){
            if(!fireBalls[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }
}
