using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
    }
}
