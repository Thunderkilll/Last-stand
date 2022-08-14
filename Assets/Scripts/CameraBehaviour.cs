using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x , minY, transform.position.z);
        }
    }
}
