using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rythm3 : MonoBehaviour
{
    public GameObject Popn;

    void Start()
    {
        StartCoroutine(PopShot());
    }

    IEnumerator PopShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Instantiate(Popn, this.transform.position, Quaternion.identity);
        }
    }
}
