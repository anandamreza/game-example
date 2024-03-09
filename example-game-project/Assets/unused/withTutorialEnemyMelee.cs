using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class withTutorialEnemyMelee : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;

    //references
    private Animator anim;
    //private Health playerHealth;
    private playerHealth health;

    private withTutorialEnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<withTutorialEnemyPatrol>();
    }

    private void Update()
    {
        coolDownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
            //Attack only when player in sight!
            if (coolDownTimer >= attackCooldown)
            {
                //Attack
                coolDownTimer = 0;
                anim.SetTrigger("MeleeIsAttacking");
                
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled =  !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            //playerHealth = hit.transform.GetComponent<Health>()
            health = hit.transform.GetComponent<playerHealth>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damagePlayer()
    {
        if(PlayerInSight())
        {
            //playerHealth.TakeDamage(damage);
            health.takeDamage(damage);
        }
    }
}


