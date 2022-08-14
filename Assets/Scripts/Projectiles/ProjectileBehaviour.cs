using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4f;

    public float destructionDelay = 1f;

    public float damage = 1;

    public Vector3 launchOffset;

    public bool thrown;
    public GameObject explotion;
    private Rigidbody2D rb;
 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        if (thrown)
        {
            var dir = transform.right + Vector3.up;
            rb.AddForce(dir * speed, ForceMode2D.Impulse);
        }
        transform.Translate(launchOffset);
        StartCoroutine("DestroyBomb", destructionDelay); 
      
    }

    IEnumerator DestroyBomb(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        if (!thrown)
        {
            transform.position += transform.right * speed * Time.deltaTime;

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
                enemy.TakeDamage(damage);
                Debug.Log("<color=red> "+enemy.health+"</color>");
                Instantiate(explotion, transform.position, Quaternion.identity);
                Destroy(gameObject);
             
        }
        
        

        
    }
}
