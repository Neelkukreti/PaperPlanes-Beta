using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class admobManager : MonoBehaviour
{
    public BannerView bannerView;
    
   public adButtons cont;
    //public InterstitialAd interstitial;

    private RewardedAd rewardedAd;
  
    String PTest	="ca-app-pub-4403834772476490/5401083147";
    String RTest="ca-app-pub-3940256099942544/1712485313";
    public RewardBasedVideoAd rewardBasedVideo;
    public bool Ibool=false;
    public bool Rbool=false;
    public bool isTesting;
    float timer=0f;
    int p=1;
    public void Start()
    {
    MobileAds.Initialize(initStatus => { });
   // this.rewardBasedVideo = RewardBasedVideoAd.Instance;
    this.RequestRewardBasedVideo();
    // this.rewardedAd = new RewardedAd(RTest);
            
    }

     void Update() {
       
    }
     
 public void RequestRewardBasedVideo()
    {
     // this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
     
    string adUnitId;
    if(isTesting)
    {
       adUnitId=RTest;
    }
    else
    {
            adUnitId ="ca-app-pub-4403834772476490/5401083147"; 
    }
        
 this.rewardedAd = new RewardedAd(adUnitId);
   this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
       this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
      this.rewardedAd.LoadAd(request);
    }

    public void UserOptToWatchAd()
    {
  if (rewardedAd.IsLoaded()) {
    rewardedAd.Show();
  //  object sender; Reward args;
 //  _ShowAndroidToastMessage("User requested ad");
   this.RequestRewardBasedVideo();
    }
      else
    {
      Rbool=false;
       this.RequestRewardBasedVideo();
      _ShowAndroidToastMessage("Can't load ad try again in 2 sec");
    }
  
    }
       public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
      //   _ShowAndroidToastMessage("Ad didnt complete");
       this.RequestRewardBasedVideo();
       
    }
      public void HandleUserEarnedReward(object sender, Reward args)
    { //cont.giveReward();
    _ShowAndroidToastMessage("Ad complete");
    }

void cRbool()
{
    Rbool=true;
}



  

  public void _ShowAndroidToastMessage(string message)
    {
        if(message=="Ad complete")
       { cRbool();
        cont.giveReward();
        
       }
       else
       {
           this.RequestRewardBasedVideo();
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
