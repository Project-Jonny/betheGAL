using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;
    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    string sceneName = "";

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //PlayBGM("Title");
    }

    public void PlayBGM(string sceneName)
    {
        if (this.sceneName == sceneName)
        {
            return;
        }
        this.sceneName = sceneName;

        if (sceneName == "1" || sceneName == "2")
        {
            return;
        }
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;

            case "Main":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "1":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "2":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;

            case "3":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;

            case "4":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
            case "5":
                audioSourceBGM.clip = audioClipsBGM[4];
                break;
            case "6":
                audioSourceBGM.clip = audioClipsBGM[5];
                break;
            case "7":
                audioSourceBGM.clip = audioClipsBGM[6];
                break;

            case "GameOverScene":
                audioSourceBGM.clip = audioClipsBGM[7];
                break;

            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[8];
                break;

            case "8":
                audioSourceBGM.clip = audioClipsBGM[9];
                break;
        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}