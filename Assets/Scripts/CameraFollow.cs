using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 range;
    public Vector3 offset;

    void FixedUpdate()
    {
            transform.position = new Vector3(range.x + player.position.x + offset.x,
                range.y + player.position.y + offset.y, range.z + player.position.z);
    }

    void Start()
    {
        range = transform.position - player.position;
    }
}
