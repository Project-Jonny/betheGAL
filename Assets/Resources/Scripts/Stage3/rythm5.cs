using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rythm5 : MonoBehaviour
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
            yield return new WaitForSeconds(1.5f);
            Instantiate(Popn, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(Popn, this.transform.position, Quaternion.identity);
        }
    }
}
