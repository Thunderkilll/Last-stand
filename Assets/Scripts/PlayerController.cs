using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region Properties

    [SerializeField]
    [Tooltip("Amount of force added when the player jumps.")]
    private float m_JumpForce = 400f;

    //[Range(0, 1)]
    //[SerializeField]
    //[Tooltip(" Amount of maxSpeed applied to crouching movement. 1 = 100%")]
    //private float m_CrouchSpeed = .36f;   

    [SerializeField]
    [Tooltip("How much to smooth out the movement")]
    [Range(0, .3f)]
    private float m_MovementSmoothing = .05f;

    [SerializeField]
    [Tooltip("Whether or not a player can steer while jumping")]
    private bool m_AirControl = false;

    [SerializeField]
    [Tooltip(" A mask determining what is ground to the character")]
    private LayerMask m_WhatIsGround;

    [SerializeField]
    [Tooltip("A position marking where to check if the player is grounded.")]
    private Transform m_GroundCheck;

    [SerializeField]
    [Tooltip(" A position marking where to check for ceilings")]
    private Transform m_CeilingCheck;

    #endregion

    #region Throwables

    public ProjectileBehaviour throwableBomb;
    public Transform launchPosition;
    #endregion
    #region local variables

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    #endregion

    #region Events
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;

    private bool m_wasCrouching = false;
    #endregion

    void Awake()
    {
        //we first get our regidbody2d
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        //detecting if we are on ground
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    void FixedUpdate()
    {
        bool wasGrounded = m_Grounded; //create new boolean to test if we are on the ground
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {

                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(throwableBomb, launchPosition.position, transform.rotation);
        }
    }


    public void Move(float move, bool jump)
    {


        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {


            //if (m_CrouchDisableCollider != null)
            //	m_CrouchDisableCollider.enabled = true;

            if (m_wasCrouching)
            {
                m_wasCrouching = false;
                OnCrouchEvent.Invoke(false);
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    #region encapsulation


    public bool GetFacingRight()
    {
        return m_FacingRight;
    }
    #endregion
}
