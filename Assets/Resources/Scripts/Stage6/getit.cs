using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getit : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(GetApper());
    }

    IEnumerator GetApper()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            text.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.5f);
            text.color = new Color(1, 1, 1, 0);
        }
    }

}
