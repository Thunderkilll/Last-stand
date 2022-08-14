using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    public GameObject sprite;

    public void FlipSprites()
    {
        sprite.transform.localScale = new Vector2(sprite.transform.localScale.x * -1, sprite.transform.localScale.y);
    }

    public void FlipThisSprite()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FlipSprites();
            //or 
            //FlipThisSprite();
        }
    }
}
