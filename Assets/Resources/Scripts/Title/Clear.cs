using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    const string SAVE_KEY = "GAME_DATA_KEY";
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        Save();
        Invoke("ButtonOn", 3f);

        string SceneName = SceneManager.GetActiveScene().name;
        SoundManager.instance.PlayBGM(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Home()
    {
        SceneManager.LoadScene("Title");
    }

    // セーブとロードの機能
    void Save()
    {
        // GameDataをJson化（文字列化）する
        SaveData saveData = new SaveData();
        saveData.GameClear = true;
        string json = JsonUtility.ToJson(saveData);
        // PlayerPrefsを使って文字列を保存する
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    void ButtonOn()
    {
        Button.SetActive(true);
    }
}
