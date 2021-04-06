using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApperBlock : MonoBehaviour
{
    public GameObject[] block;

    void Start()
    {
        StartCoroutine(BlockApper());
    }

    IEnumerator BlockApper()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            block[0].SetActive(true);
            block[1].SetActive(true);
            yield return new WaitForSeconds(2f);
            block[0].SetActive(false);
            block[1].SetActive(false);
        }
    }
}
