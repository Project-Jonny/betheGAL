using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class five : MonoBehaviour
{
    public GameObject TrapObj;

    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(7f);
        transform.position += new Vector3(0, -3, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        TrapObj.SetActive(false);
    }
}