using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKapsel : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(8f);
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
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.05f);
        transform.position += new Vector3(0, -1, 0);
    }
}