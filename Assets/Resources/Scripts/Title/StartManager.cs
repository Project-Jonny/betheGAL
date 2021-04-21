using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    const string SAVE_KEY = "GAME_DATA_KEY";

    public Text StartText;

    public GameObject pien;
    public GameObject paon;
    public GameObject StartButton;

    public Image pienImage;
    public Image paonImage;

    public GameObject Clear;

    SaveData saveData;

    private void Awake()
    {
        Load();
    }

    void Start()
    {
        Player.DeathCount = 0;
        string SceneName = SceneManager.GetActiveScene().name;
        SoundManager.instance.PlayBGM(SceneName);

        if (saveData.GameClear == true)
        {
            Clear.SetActive(true);
        }
    }

    public void StartPush()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        int count = 0;
        while (count < 6)
        {
            // 消える
            StartText.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.03f);
            // つく
            StartText.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.03f);
            count++;
        }
        StartButton.SetActive(false);
        StartText.enabled = false;

        yield return new WaitForSeconds(0.15f);
        PienActive();
    }

    IEnumerator PienFlash()
    {
        int count = 0;
        while (count < 4)
        {
            // 消える
            pienImage.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.05f);
            // つく
            pienImage.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.05f);
            count++;
        }
    }

    IEnumerator PaonFlash()
    {
        int count = 0;
        while (count < 4)
        {
            // 消える
            paonImage.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.05f);
            // つく
            paonImage.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.05f);
            count++;
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene("Main");
    }

    void PienActive()
    {
        pien.SetActive(true);
        paon.SetActive(true);
    }

    public void PienPush()
    {
        SoundManager.instance.PlaySE(1);
        GameData.instance.PaonMode = false;
        GameData.instance.Life = 1;
        StartCoroutine(PienFlash());
        Invoke("MoveScene", 0.4f);
    }

    public void PaonPush()
    {
        SoundManager.instance.PlaySE(1);
        GameData.instance.PaonMode = true;
        GameData.instance.Life = 1;
        StartCoroutine(PaonFlash());
        Invoke("MoveScene", 0.4f);
    }

    // セーブとロードの機能
    void Save()
    {
        // GameDataをJson化（文字列化）する
        string json = JsonUtility.ToJson(saveData);
        // PlayerPrefsを使って文字列を保存する
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    void Load()
    {
        // セーブデータがある場合
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            // PlayerPrefsを使ってセーブした文字列を取得
            string json = PlayerPrefs.GetString(SAVE_KEY);
            // jsonからクラスを復元
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }
    }
}

public class SaveData
{
    public bool GameClear;
}