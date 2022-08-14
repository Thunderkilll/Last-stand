using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamouflagePlant : MonoBehaviour
{
    private float health = 2f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!col.gameObject.GetComponent<Player>().GetIsDetected())
            {
                col.gameObject.GetComponent<Player>().SetInvisiblity(true);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!col.gameObject.GetComponent<Player>().GetIsDetected())
            {
                col.gameObject.GetComponent<Player>().SetInvisiblity(true);
            }
        
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            col.gameObject.GetComponent<Player>().SetInvisiblity(false);
        }
    }
}
