using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAreaEffect : MonoBehaviour
{

    public float radiusEffect;
    public float damageAmount;
    
    public CircleCollider2D circleCollider;

    
    void Start()
    {
        circleCollider.radius = radiusEffect;
        if (radiusEffect != 0)
        {
            damageAmount /= radiusEffect;
        }
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.gameObject.GetComponent<Enemy>();
        if (col.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(damageAmount);
        }
    }
}
