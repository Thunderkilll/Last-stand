using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("this boolean represent when the player is in detected by enemies")]
    [SerializeField]
    bool isDetected = false;
    [Tooltip("this boolean represent when the player is hiding in a bush")]
    [SerializeField]
    private bool isInvisible = false;
    
    [Tooltip("How much the player is transparent")]
    [Range(0, 1)]
    [SerializeField]
    private float tranceparencyLevel;

    public GameObject gameManager;
    private SpriteRenderer gfx;
    Vector3 initialPosition;

    void Awake()
    {
        gfx = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isInvisible)
        {
            ChangeTransparency(tranceparencyLevel);
        }
        else
        {
            ChangeTransparency(1);
        }
    }


    void ChangeTransparency(float a)
    {
        gfx.color = new Color(gfx.color.r, gfx.color.g, gfx.color.b , a);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            Time.timeScale = 0;
            gameManager.GetComponent<ScoreLives>().ChangeLives();

            transform.position = initialPosition;
            Time.timeScale = 1;
        }
    }
    #region getters and setters

    public bool GetIsDetected()
    {
        return isDetected;
    }

    public void SetIsDetected(bool value)
    {
        isDetected = value;
    }

    public bool GetInvisibility()
    {
        return isInvisible;
    }

    public void SetInvisiblity(bool value)
    {
        isInvisible = value;
    }
    #endregion
}
