using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;
using System.Threading;

public class Ads : MonoBehaviour
{

    private void Awake()
    {
        Yodo1U3dMas.InitializeSdk();
    }

    void Start()
    {
        // Banner's delegate should be set before the show function is called.
        BannerEvents();

        // The show function should be called some time after the SDK is initialized, the ad loading will takes some time.
        // This is a simple time-lapse operation to test whether the ads is displayed, you can also do it the other way.
        // Because normally the show function is not called after the SDK initialization function.
        // You can call the show function after some events in the game.
        //Thread.Sleep(2);
    }

    public void ShowBanner()
    {
        // You can call the ShowBannerAd() function.(default bannerAd align type is BannerBottom | BannerHorizontalCenter)
        Yodo1U3dMas.ShowBannerAd();
    }

    public void BannerEvents()
    {
        Yodo1U3dMas.SetBannerAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] BannerdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Banner ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Banner ad has been shown.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Banner ad error, " + error.ToString());
                    break;
            }
        });
    }
}