using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public admobManager admobManager;
     public admob admob;
    public int counter=0;
    public GameObject powerUp;
    public GameObject powerUpM;
    public GameObject conti;public GameObject contiM;

    public GameObject restart;
    
    public void powerUPpressed()
    {
        admobManager.UserOptToWatchAd();
      
      //  restart.SetActive(false);
        //conti.SetActive(false);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(admob.Ibool)
        {
         restart.SetActive(false);
        powerUp.SetActive(false);
        contiM.SetActive(true);
        conti.SetActive(false);
        admobManager.Ibool=false;
        counter++;
        }
    
    }
    public void Contpressed()
    {
        admob.RequestInterstitial();
        
    }

    public void giveReward()
    {
        restart.SetActive(false);
        conti.SetActive(false);
        powerUpM.SetActive(true);
        powerUp.SetActive(false);
          counter++;
    }


}
