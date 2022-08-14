using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public bool isPatrolling = true;
    public bool canPatroll = true;
    public bool mustFlip ;
    public float enemy_speed = 10f;
    float currSpeed;
    private Rigidbody2D rb;
    Animator animator;

    public GameObject groundCheck;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public BoxCollider2D boxCollider;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }

    void Start()
    {
        currSpeed = enemy_speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (canPatroll)
        {
            Patrol();

        }
        else
        {
            isPatrolling = false;
        }

        PatrollingAnimation(isPatrolling);
    }

    void FixedUpdate()
    {
        if (canPatroll)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.transform.position, .1f, groundLayer);
        }
    }
    private void Patrol()
    {
        if (mustFlip || boxCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(currSpeed * Time.fixedDeltaTime, rb.velocity.y);
  
    }

    void Flip()
    {
       
        StartCoroutine("DelayResumePatrolling");
    }

    IEnumerator DelayResumePatrolling()
    {
        isPatrolling = false;
        canPatroll = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
       
        yield return new WaitForSeconds(.1f);
        //Debug.Log("here");
      
        currSpeed *= -1;
        isPatrolling = true;
        canPatroll = true;
        mustFlip = false;
         
        
    }

    void PatrollingAnimation(bool checker)
    {
        animator.SetBool("isPatrolling", checker);
    }
}
