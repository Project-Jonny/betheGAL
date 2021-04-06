using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public GameObject prefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            // プレハブからインスタンスを生成
            Instantiate(prefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
