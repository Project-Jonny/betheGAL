using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third : MonoBehaviour
{
    public GameObject TrapObj;

    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(2f);
        transform.position += new Vector3(0, -3, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        TrapObj.SetActive(false);
    }
}
