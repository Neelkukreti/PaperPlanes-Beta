using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class admob : MonoBehaviour
{
    public BannerView bannerView;
    
    public adButtons cont;
    public InterstitialAd interstitial;

    String  BTest="ca-app-pub-3940256099942544/6300978111";
    String ITest	="ca-app-pub-3940256099942544/1033173712";
    String RTest="ca-app-pub-3940256099942544/5224354917";
  //  public RewardBasedVideoAd rewardBasedVideo;
     private RewardedAd rewardedAd;
    public bool Ibool=false;
    public bool Rbool=false;
    public bool isTesting;
    float timer=0f;
    int p=1;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
       
    MobileAds.Initialize(initStatus => { });
       
     //   
      

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
      
       loadInter();

    }

     void Update() {
      
    }


public void loadInter()
{
    
        string adUnitId ; // BTest;//
         if(isTesting)
    {
       adUnitId=ITest;
    }
    else
    {
            adUnitId ="ca-app-pub-4403834772476490/3074346860"; 
    }
//string adUnitId2  //ITest;//
  
    // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);
      AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
}
public void RequestInterstitial()
{
    
    GameOver();

}
private void GameOver()
{
   if (this.interstitial.IsLoaded()) {
    this.interstitial.Show();
    Ibool=true;
  }
  else
  {
      Ibool=false;
      loadInter();
      _ShowAndroidToastMessage("can't load ad try again");
  }
}
  public void _ShowAndroidToastMessage(string message)
    {
        if(message=="Ad complete")
       {
       }
       else
       {
          
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
       }
    }
}
