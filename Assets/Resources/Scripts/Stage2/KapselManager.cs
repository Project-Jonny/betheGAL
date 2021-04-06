using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapselManager : MonoBehaviour
{
    public GameObject TrapObj;
    public GameObject SecTrapObj;

    public GameObject Virus1;
    public GameObject Virus2;

    public Sprite Imagesprite;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        StartCoroutine(Moving());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.3f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.3f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.3f);
        transform.position += new Vector3(-1, 0, 0);
        //transform.Rotate(0, 0, 90);
        TrapObj.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        transform.position += new Vector3(0.5f, 0, 0);
        spriteRenderer.sprite = Imagesprite;
        SecTrapObj.SetActive(true);
        Destroy(Virus1);
        Destroy(Virus2);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        SecTrapObj.SetActive(false);
    }
}
