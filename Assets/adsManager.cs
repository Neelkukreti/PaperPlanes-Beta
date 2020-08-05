using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class adsManager : MonoBehaviour
{
    public BannerView bannerView;
    
   // public uiManagement cont;
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
       // this.rewardedAd = new RewardedAd(RTest);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        this.RequestBanner();
        // Load the rewarded ad with the request.
       // this.rewardedAd.LoadAd(request);
       

    }

     void Update() {
      
    }
         private void RequestBanner()
    {
           
        Debug.Log("ad init");
   
          string    adUnitId ="ca-app-pub-4403834772476490/3050064628";// BTest;//
         if(isTesting)
    {
       adUnitId=BTest;
    }
    else
    {
        
            adUnitId ="ca-app-pub-4403834772476490/3050064628"; 
    }
     
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
       //  _ShowAndroidToastMessage("load Banner 2 "); 
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
}
 public void HideAd()
    {
        bannerView.Destroy ();
        bannerView.Hide ();
    }

 public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
                             this.RequestBanner();
                              
    }
}