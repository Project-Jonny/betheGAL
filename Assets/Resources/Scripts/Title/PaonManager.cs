using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaonManager : MonoBehaviour
{
    public GameObject PaonPanel;
    public GameObject BuyBotton;

    public void BuyPaon()
    {
        Debug.Log("paon");
        PlayerPrefs.SetInt("PaonKaetayo",1);
        PlayerPrefs.Save();
        PaonPanel.SetActive(false);
        BuyBotton.SetActive(false);
    }
}
