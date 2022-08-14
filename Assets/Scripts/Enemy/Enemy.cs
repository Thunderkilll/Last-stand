using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5;




    public void TakeDamage(float dmg)
    {
        if (health > dmg)
         health -= dmg;
        else
        {
            health = 0;
            Debug.Log("Enemy is dead");
        }
    }
}
