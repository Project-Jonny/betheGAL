using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 10;
    public Vector3 pos;

    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.position += new Vector3(pos.x,0,0) * Time.deltaTime * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
