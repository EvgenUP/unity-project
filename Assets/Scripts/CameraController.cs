using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset;
    public Transform target;
    
    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        transform.position = new(transform.position.x, transform.position.y, offset.z + target.position.z);
    }
}
