using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverText;

    public float shakePower;
    Vector3 TextPos;

    void Start()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        SoundManager.instance.PlayBGM(SceneName);
        TextPos = GameOverText.transform.position;
    }

    void Update()
    {
        GameOverText.transform.position = TextPos + Random.insideUnitSphere * shakePower;
    }

    public void MoveScene()
    {
        SceneManager.LoadScene("Title");
    }
}
