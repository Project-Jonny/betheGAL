using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    int n;

    void Start()
    {
        n = SoundManager.instance.n;
        this.GetComponent<Image>().sprite = sprites[n];
    }

    void Update()
    {
        this.GetComponent<Image>().sprite = sprites[n];
    }

    public void Sound()
    {
        if (n == 0)
        {
            SoundManager.instance.VolumeDown();
            n = 1;
        }
        else
        {
            SoundManager.instance.VolumeUp();
            n = 0;
        }
    }
}
