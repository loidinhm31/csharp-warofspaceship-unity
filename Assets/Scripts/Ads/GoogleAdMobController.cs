using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.Events;
using UnityEngine.UI;
public class GoogleAdMobController : MonoBehaviour
{   
    //private RewardedAd rewardedAd;

    private InterstitialAd interstitialAd;


    void Start()
    {   
        
        if (GameController.instance.DeadTime == 2)
        {   
            
            RequestAndLoadInterstitialAd();
            
            PlayerPrefs.SetInt("DeadTime", 0);
        }
        
    }


    void Update()
    {   
        ShowInterstitialAd();
    }


 /*
    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
        
    #if UNITY_EDITOR
        string adUnitId = "unused";
    #elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    #else
        string adUnitId = "unexpected_platform";
    #endif

        // create new rewarded ad instance
        rewardedAd = new RewardedAd(adUnitId);

        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
    }
    

    public void ShowRewardedAd()
    {   
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
  
        
    }

    #endregion
    */

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
    
        
        string adUnitId = "ca-app-pub-3378359392301423/2027873364";
      
        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load an interstitial ad
        interstitialAd.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded() && interstitialAd != null)
        {
            interstitialAd.Show();
        }

    }
    
    #endregion

}
