using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnhanceExample : MonoBehaviour
{
    // Simple Enhance implementation for our UI to use:

    public void ShowInterstitialAd()
    {
        FGLEnhance.ShowInterstitialAd(FGLEnhance.INTERSTITIAL_PLACEMENT_DEFAULT);
        Log("Showing interstitial ad");
    }

    public void ShowRewardedAd()
    {
        FGLEnhance.ShowRewardedAd(FGLEnhance.REWARDED_PLACEMENT_NEUTRAL, OnRewardGranted, OnRewardDeclined, OnRewardUnavailable);
        Log("Showing rewarded ad");
    }

    public void LogEvent()
    {
        FGLEnhance.LogEvent("test_event");
        Log("Sent analytics event 'test_event'");
    }



    // Callbacks for our rewarded ad:

    private void OnRewardGranted(FGLEnhance.RewardType rewardType, int count)
    {
        if (rewardType == FGLEnhance.RewardType.REWARDTYPE_COINS)
        {
            Log(string.Format("Granted reward of {0} coins", count));
        }
        else
        {
            Log(string.Format("Granted reward"));
        }
    }

    private void OnRewardDeclined()
    {
        Log(string.Format("Reward declined"));
    }

    private void OnRewardUnavailable()
    {
        Log(string.Format("Reward unavailable"));
    }




    // Non-enhance logic:

    public Text LogText;
    private Queue<string> logItems = new Queue<string>();

    private void Log(string text)
    {
        logItems.Enqueue(text);
        if (logItems.Count > 10) logItems.Dequeue();

        LogText.text = string.Join("\n", logItems.ToArray());
    }

}
