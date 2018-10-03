using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowInterstitial()
    {
        Debug.Log("interstitial");
        Enhance.ShowInterstitialAd();

    }

    public void ShowRewarded()
    {
        Debug.Log("rewarded");
        if (Enhance.IsRewardedAdReady())
        { 
            Enhance.ShowRewardedAd(OnRewardGranted, OnRewardDeclined, OnRewardUnavailable);
        }
        
    }

    private void OnRewardUnavailable()
    {
        Debug.Log("Not Available");
    }

    private void OnRewardDeclined()
    {
        Debug.Log("Declined");
    }

    private void OnRewardGranted(Enhance.RewardType arg1, int arg2)
    {
        Debug.Log("Reward Granted");
    }
    
}
