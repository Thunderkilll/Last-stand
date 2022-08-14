using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    #region params
    [Header("Enemy Global Settings")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rangeChase;
    [SerializeField]
    private float rangeAttack;
    [SerializeField]
    private float respawnDelay;
    [SerializeField]
    private bool isDead = false;
    bool isInAttackDistance = false;
    bool canAttack=false;
    bool isFacingPlayer = false;
    private Rigidbody2D rb;

 
    private Animator anim;
    [SerializeField]
    private SpriteRenderer sp;

    private Vector3 moveDirection;
    [SerializeField]
    private GameObject player;

  
    [Header("Enemy attack settings")]

    public float damage;
    public float stayDamage;
    private Player playerBehaviour;

    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (player != null)
        {
            playerBehaviour = player.GetComponent<Player>();
        }
        
    }
    void Update()
    {
        if (!playerBehaviour.GetInvisibility() && !isDead)
        {
        
            isInAttackDistance = PlayerInStrikingDistance();
            EnemyMoveDirection();
            EnemyMoveAnimation();
            EnemyAttackAnimation();
        }
       
    }

    private bool PlayerInStrikingDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > rangeAttack)
        {
            canAttack = false;
            playerBehaviour.SetIsDetected(false);
            return false;
        }
        else
        {
            
            canAttack = true;
            playerBehaviour.SetIsDetected(true);
            return true;
        }

    }

    private void EnemyMoveDirection()
    {
        //if (!isInAttackDistance)
        //{
            if (Vector3.Distance(transform.position, player.transform.position) < rangeChase)
            {
                moveDirection = player.transform.position - transform.position;
           
            }
            else
            {
                moveDirection = Vector3.zero;
            }
            moveDirection.Normalize();

            rb.velocity = new Vector2(moveDirection.x * moveSpeed, 0);
        //}
        //else
        //{
        //    moveDirection = Vector3.zero;
        //    moveDirection.Normalize();
        //    rb.velocity = Vector3.zero;
        //}
 
    }


    private void EnemyMoveAnimation()
    {
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isPatrolling", true);
        }
        else
        {
            FacePlayerWhenChasing();
            anim.SetBool("isPatrolling", false);
        }
    }

    private void EnemyAttackAnimation()
    {
         
            anim.SetBool("canAttack", canAttack);
         
    }

    public void FlipThisSprite()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void FacePlayerWhenChasing()
    {
        float directionX = transform.position.x - player.transform.position.x;
        if (directionX > 0)
        {

            if (!isFacingPlayer)
            {
                FlipThisSprite();
                isFacingPlayer = true;
            }
        }
       
    }
}
