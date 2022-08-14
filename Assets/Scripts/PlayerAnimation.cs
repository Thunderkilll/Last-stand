using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    

    public void SetMovementSpeedAnimation(float value)
    {
        animator.SetFloat("speed" , value);
    }

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("jump");
    }

    public void SetDeathAnimation(bool value)
    {
        animator.SetBool("death" , value);
    }

    public void SetAttackAnimation(bool value)
    {
        animator.SetBool("attack" , value);
    }

    public void TriggerPlayerHurtAnimation()
    {
        animator.SetTrigger("hurt");
    }

    public void SetCarryingAnimation(bool isCarrying)
    {
      animator.SetBool("carry" , isCarrying);
    }

    public void PickUpAnimation(bool value)
    {
        animator.SetBool("pickUp" , value);
    }
    public void PickUpFrontAnimation(bool value)
    {
        animator.SetBool("pickUp2", value);
    }
}
