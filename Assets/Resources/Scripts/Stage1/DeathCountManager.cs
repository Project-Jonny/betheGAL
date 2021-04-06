using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCountManager : MonoBehaviour
{
    public Text DeathCountText;

    void Start()
    {
        if (GameData.instance.PaonMode == true)
        {
            DeathCountText.text = Player.DeathCount.ToString();
        }
    }
}
