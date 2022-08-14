using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    public float speed = 10;
    public float carryingSpeed;
    PlayerController controller;
    private PlayerAnimation playerAnimation;
    private float direction;
    [SerializeField]
    private string axis;
    [SerializeField]
    private string jumpButton;
    [Header("Flags")]
    [SerializeField]
    private bool pickUp1 = false;
    [SerializeField]
    private bool pickUp2 = false;
    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private bool isDead = false;
    [SerializeField]
    private bool isCarrying = false;

    #region Companion Setting

    public bool haveDog = false;
    public DogFollow dog;

    #endregion


    #region fire mechanism
    [Header("Shooting Settings")]
    public Transform shootPosition;
    [SerializeField]
    float timeBetweenShots = 0f;
    public GameObject bulletPrefab;
    float fireCounter;
    #endregion

    bool isJumping = false;
    private float move;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<PlayerController>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Start()
    {
        isDead = false;
        isJumping = false;
        pickUp2 = false;
        pickUp1 = false;
        isAttacking = false;
    }
    void Update()
    {
        if (!isDead)
        {
            PickUpButtonController();
            GettingHurt();
            AttackButtonController();
            CarryObject();
            MovePlayer();




            //pickUp 1 & 2 

        }
        else
        {
            //dog stay still
            dog.SetStatus(-1);
            PlayDeathAnimation();
        }


    }

    /// <summary>
    /// Movement transition of our player
    /// </summary>
    private void MovePlayer()
    {
        if (!pickUp1 && !pickUp2 && !isAttacking && !isCarrying)
        {
            direction = Input.GetAxisRaw(axis);
            move = direction * speed * Time.deltaTime;

            //animation
            playerAnimation.SetMovementSpeedAnimation(direction);
            if (haveDog)
            {
                DogMoveAnimation();
            }


            if (Input.GetButtonDown(jumpButton))
            {
                isJumping = true;
                //animation kick and jump
                playerAnimation.TriggerJumpAnimation();
            }
            else
            {
                isJumping = false;
            }

            //technical movement
            controller.Move(move, isJumping);
            if (haveDog)
            {
                if (move < 0 && dog.GetFacingRight())
                {
                    dog.FlipDog();
                }

                if (move > 0 && !dog.GetFacingRight())
                {
                    dog.FlipDog();
                }
            }

        }
    }

    private void DogMoveAnimation()
    {
        if (Mathf.Abs(direction) <= 0.2f)
        {
            dog.SetStatus(0);
        }
        else if (Mathf.Abs(direction) >= 0.5f && Mathf.Abs(direction) < 0.75f)
        {
            dog.SetStatus(2);
        }
        else
        {
            dog.SetStatus(3);
        }
    }

    /// <summary>
    /// death animation starting from here
    /// </summary>
    void PlayDeathAnimation()
    {
        playerAnimation.SetDeathAnimation(isDead);
    }

    /// <summary>
    /// function monitor shooting buttons
    /// </summary>
    void AttackButtonController()
    {
        if (Input.GetMouseButton(0))
        {
            fireCounter -= Time.deltaTime;
            if (fireCounter <= 0)
            {
                GameObject go = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
                go.name = bulletPrefab.name;
                 
                fireCounter = timeBetweenShots;
                //Animation
                isAttacking = true;

                playerAnimation.SetAttackAnimation(isAttacking);
                if (haveDog)
                {
                    //dog animation
                dog.SetStatus(1); 
                }
               

                fireCounter = timeBetweenShots;
            }
        }
        else
        {

            isAttacking = false;
            playerAnimation.SetAttackAnimation(isAttacking);
            if (haveDog)
            {
                //dog animation
                dog.SetStatus(0);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (haveDog)
            {
                //dog animation
                dog.SetStatus(1);
            }

            //Animation
            isAttacking = true;
            playerAnimation.SetAttackAnimation(isAttacking); 
            fireCounter = timeBetweenShots;
        }


    }

    void GettingHurt()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerAnimation.TriggerPlayerHurtAnimation();
        }
    }

    void CarryObject()
    {
        if (isCarrying)
        {


            isJumping = false;
            direction = Input.GetAxisRaw(axis);
            move = direction * carryingSpeed * Time.deltaTime;
            //animation
            playerAnimation.SetCarryingAnimation(isCarrying);

            //technical movement
            controller.Move(move, isJumping);
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("DROP ITEM");
                isCarrying = false;
                //animation
                playerAnimation.SetCarryingAnimation(isCarrying);
            }
        }
    }

    void PickUpButtonController()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (haveDog)
            {
                //dog bark 
                dog.SetStatus(0);
            }

            pickUp1 = true;
            playerAnimation.PickUpAnimation(pickUp1);
            StartCoroutine("EndPickingUp");
        }
    }

    IEnumerator EndPickingUp()
    {
        yield return new WaitForSeconds(.6f);
        pickUp1 = false;
        isCarrying = true;
        playerAnimation.PickUpAnimation(pickUp1);
    }
}
