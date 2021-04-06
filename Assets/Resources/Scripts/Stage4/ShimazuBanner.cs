using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShimazuBanner : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer smd;

    void Start()
    {
        smd = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeBanner());
    }

    IEnumerator ChangeBanner()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            smd.sprite = sprites[1];
            yield return new WaitForSeconds(5f);
            smd.sprite = sprites[0];
        }
    }
}
