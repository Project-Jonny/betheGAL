using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform PlayerTransform;

    void Update()
    {
        Vector3 NextPosition = transform.position;
        NextPosition.x = PlayerTransform.position.x;
        transform.position = NextPosition;
    }
}