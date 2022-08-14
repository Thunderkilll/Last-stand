using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 7.5f;
    Rigidbody2D rb;
    private GameObject player;
    private int direction;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb.velocity = transform.right * speed * direction ;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            Destroy(gameObject); 
        }

        if (col.gameObject.layer == LayerMask.GetMask("Wall") || col.gameObject.tag == "Wall" || col.gameObject.layer == LayerMask.GetMask("Wall"))
        {
            Destroy(gameObject);
        }
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (col.gameObject.layer == LayerMask.GetMask("Wall") || col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnEnable()
    {

         
        if (player.GetComponent<PlayerController>().GetFacingRight())
        {
            Debug.Log("shoot");
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
}
