using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DogFollow : MonoBehaviour
{
    public int status = 0;
    public Vector3 offset;
    Animator animator;
    MovementBehaviour movementBehaviour;
    private GameObject player;
    bool m_FacingRight =true;
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        movementBehaviour = player.GetComponent<MovementBehaviour>();
    }
    void Start()
    {
        transform.position = offset + player.transform.position;
        animator.SetInteger("status" , status);
    }

    void Update()
    {
        animator.SetInteger("status", status);
    }
    void FixedUpdate()
    {
        
        if (status == 2 || status == 3)
        {
             transform.position = new Vector3(offset.x + player.transform.position.x, transform.position.y, transform.position.z);
        }

        
    }

    public void SetStatus(int value)
    {
        status = value;
    }

    public void FlipDog()
    {
        SetFacingRight();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetFacingRight()
    {
       m_FacingRight= !m_FacingRight;
    }

    public bool GetFacingRight()
    {
        return m_FacingRight;
    }
}
