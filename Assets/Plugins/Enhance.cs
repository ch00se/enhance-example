/**
 * Enhance connector for Unity
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;
using System.Collections.Generic;

public class Enhance
{
    ///// PUBLIC /////

    // Where the rewarded as was triggered
    public const string REWARDED_PLACEMENT_SUCCESS = "SUCCESS";                 // Ad following success in the game, such as completing a level
    public const string REWARDED_PLACEMENT_HELPER = "HELPER";                   // Ad to help the user, for instance after losing a level or when needing currency
    public const string REWARDED_PLACEMENT_NEUTRAL = "NEUTRAL";                 // Ad in a neutral circumstance, for instance the user tapping "Watch video for a reward"

    // default placement type
    public const string PLACEMENT_DEFAULT = "default";             // Default ad placement

    // Where the interstitial was triggered
    public const string INTERSTITIAL_PLACEMENT_DEFAULT = "default";             // Default ad placement
    public const string INTERSTITIAL_LEVEL_COMPLETED = "level_completed";       // Level completed

	public static EnhanceInAppPurchases Purchases = new EnhanceInAppPurchases();

    // Type of reward that was granted
    public enum RewardType
    {
        ITEM,           // Arbitrary game-defined item granted (no coin amount reported)
        COINS          // A defined coins amount was granted
    };

	// Position of banner
	public enum Position
	{
		TOP,
		BOTTOM
	}

    /**
      * Set currency received callback
      * 
      * @param onCurrencyReceived callback executed when a currency is received
      */
	public static void SetReceivedCurrencyCallback(Action<int> onCurrencyReceived)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnCurrencyReceivedCallback = onCurrencyReceived;

        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.SetCurrencyCallback(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.SetCurrencyCallback(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.SetCurrencyCallback(FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

    /**
     * Check if an interstitial ad is ready
     * 
     * @return true if an interstitial ad is ready, false if not
     */
    public static bool IsInterstitialReady(string placement = INTERSTITIAL_PLACEMENT_DEFAULT)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsInterstitialReady(placement);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsInterstitialReady(placement);
#elif UNITY_IOS
        return FGLiOSInternals.IsInterstitialReady(placement);
#else
        return true;
#endif
    }

    /**
     * Show interstitial ad
     */
    public static void ShowInterstitialAd(string placement = INTERSTITIAL_PLACEMENT_DEFAULT)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.ShowInterstitialAd(placement);
#elif UNITY_ANDROID
        FGLAndroidInternals.ShowInterstitialAd(placement);
#elif UNITY_IOS
        FGLiOSInternals.ShowInterstitialAd(placement);
#endif
    }

    /**
     * Check if a rewarded ad is ready
     * 
     * @return true if a rewarded ad is ready, false if not
     */
    public static bool IsRewardedAdReady(string placement = REWARDED_PLACEMENT_NEUTRAL)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsRewardedAdReady(placement);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsRewardedAdReady(placement);
#elif UNITY_IOS
        return FGLiOSInternals.IsRewardedAdReady(placement);
#else
        return false;
#endif
    }

    /**
      * Show rewarded ad
      * 
      * @param placement placement type for this ad
      * @param onRewardGrantedCallback callback executed when the ad reward is granted
      * @param onRewardDeclinedCallback callback executed when the ad reward is declined
      * @param onRewardUnavailableCallback callback executed when the ad reward is unavailable
      */
    public static void ShowRewardedAd(string placement, Action<RewardType, int> onRewardGrantedCallback, Action onRewardDeclinedCallback, Action onRewardUnavailableCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnRewardGrantedCallback = onRewardGrantedCallback;
        FGLEnhance_Callbacks.OnRewardDeclinedCallback = onRewardDeclinedCallback;
        FGLEnhance_Callbacks.OnRewardUnavailableCallback = onRewardUnavailableCallback;

        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.ShowRewardedAd(placement, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.ShowRewardedAd(placement, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.ShowRewardedAd(placement, FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

	/**
	  * Show rewarded ad 
	  */
	
	public static void ShowRewardedAd(Action<RewardType, int> onRewardGrantedCallback, Action onRewardDeclinedCallback, Action onRewardUnavailableCallback)
	{
		ShowRewardedAd (REWARDED_PLACEMENT_NEUTRAL, onRewardGrantedCallback, onRewardDeclinedCallback, onRewardUnavailableCallback);
	}

	/**
	* Check if a banner ad is ready
	*
	* @return true if an banner ad is ready, false if not
	*/
	public static bool IsBannerAdReady()
	{
        return IsBannerAdReady(PLACEMENT_DEFAULT);
	}

    /**
    * Check if a banner ad is ready
    *
    * @return true if an banner ad is ready, false if not
    */
    public static bool IsBannerAdReady(string placement)
    {
        InitializeEnhance();
#if UNITY_EDITOR
        return FGLEditorInternals.IsBannerAdReady(placement);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsBannerAdReady(placement);
#elif UNITY_IOS
        return FGLiOSInternals.IsBannerAdReady(placement);
#else
        return false;
#endif
    }

    /**
    * Show banner ad
    * 
    * @param position position (top or bottom)
    */
    public static void ShowBannerAdWithPosition (Position position)
    {
        ShowBannerAdWithPosition(PLACEMENT_DEFAULT, position);
    }

	/**
	* Show banner ad
	* 
	* @param position position (top or bottom)
	*/
	public static void ShowBannerAdWithPosition (string placement, Position position)
	{
		string strPos = "BOTTOM";
		if (position == Position.TOP)
			strPos = "TOP";

        InitializeEnhance();
#if UNITY_EDITOR
		FGLEditorInternals.ShowBannerAd(placement, strPos);
#elif UNITY_ANDROID
        FGLAndroidInternals.ShowBannerAd(placement, strPos);
#elif UNITY_IOS
        FGLiOSInternals.ShowBannerAd(placement, strPos);
#endif
	}

	/**
	* Hide banner ad
	*/
	public static void HideBannerAd ()
	{
        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.HideBannerAd();
#elif UNITY_ANDROID
        FGLAndroidInternals.HideBannerAd();
#elif UNITY_IOS
        FGLiOSInternals.HideBannerAd();
#endif
	}

    /**
     * Check if a special offer is ready
     *
     * @return true if a special offer is ready, false if not
     */
    public static bool IsSpecialOfferReady()
    {
        return IsSpecialOfferReady(PLACEMENT_DEFAULT);
    }

	/**
     * Check if a special offer is ready
     *
     * @return true if a special offer is ready, false if not
     */
    public static bool IsSpecialOfferReady(string placement)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsSpecialOfferReady(placement);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsSpecialOfferReady(placement);
#elif UNITY_IOS
        return FGLiOSInternals.IsSpecialOfferReady(placement);
#else
        return false;
#endif
    }

    /**
     * Show special offer
     */
    public static void ShowSpecialOffer()
    {
        ShowSpecialOffer(PLACEMENT_DEFAULT);
    }

    /**
     * Show special offer
     */
    public static void ShowSpecialOffer(string placement)
    {
        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.ShowSpecialOffer(placement);
#elif UNITY_ANDROID
        FGLAndroidInternals.ShowSpecialOffer(placement);
#elif UNITY_IOS
        FGLiOSInternals.ShowSpecialOffer(placement);
#endif
    }

    /**
     * Check if an offerwall is ready
     *
     * @return true if an offerwall is ready, false if not
     */
    public static bool IsOfferwallReady()
    {
        return IsOfferwallReady(PLACEMENT_DEFAULT);
    }

    /**
     * Check if an offerwall is ready
     *
     * @return true if an offerwall is ready, false if not
     */
    public static bool IsOfferwallReady(string placement)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsOfferwallReady(placement);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsOfferwallReady(placement);
#elif UNITY_IOS
        return FGLiOSInternals.IsOfferwallReady(placement);
#else
        return false;
#endif
    }

    /**
     * Show offerwall
     */
    public static void ShowOfferwall()
    {
        ShowOfferwall(PLACEMENT_DEFAULT);
    }

    /**
     * Show offerwall
     */
    public static void ShowOfferwall(string placement)
    {
        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.ShowOfferwall(placement);
#elif UNITY_ANDROID
        FGLAndroidInternals.ShowOfferwall(placement);
#elif UNITY_IOS
        FGLiOSInternals.ShowOfferwall(placement);
#endif
    }

    /**
     * Log custom analytics event
     * 
     * @param eventType event type (for instance 'menu_shown')
     */
    public static void LogEvent(string eventType)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.LogEvent(eventType);
#elif UNITY_ANDROID
        FGLAndroidInternals.LogEvent(eventType);
#elif UNITY_IOS
        FGLiOSInternals.LogEvent(eventType);
#endif
    }

    /**
     * Log custom analytics event
     * 
     * @param eventType event type (for instance 'level_completed')
     * @param paramKey parameter key (for instance 'level')
     * @param paramValue parameter value (for instance '3')
     */
    public static void LogEvent(string eventType, string paramKey, string paramValue)
    {
        InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.LogEvent(eventType, paramKey, paramValue);
#elif UNITY_ANDROID
        FGLAndroidInternals.LogEvent(eventType, paramKey, paramValue);
#elif UNITY_IOS
        FGLiOSInternals.LogEvent(eventType, paramKey, paramValue);
#endif
    }


    /**
     * Request permission from the user to show local notifications
     * 
     * @param onPermissionGrantedCallback executed when the permission is granted
     * @param onPermissionRefusedCallback executed when the permission is refused
     */
    public static void RequestLocalNotificationPermission(Action onPermissionGrantedCallback, Action onPermissionRefusedCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnLocalNotificationPermissionGrantedCallback = onPermissionGrantedCallback;
        FGLEnhance_Callbacks.OnLocalNotificationPermissionRefused = onPermissionRefusedCallback;

        Enhance.InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.RequestLocalNotificationsPermission(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.RequestLocalNotificationsPermission(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.RequestLocalNotificationsPermission(FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

    /**
     * Enable local notifications
     *
     * @param title notification title
     * @param message notification message
     * @param delay notification delay in seconds
     */
    public static void EnableLocalNotification(string title, string message, int delay)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.EnableLocalNotifications(title, message, delay);
#elif UNITY_ANDROID
        FGLAndroidInternals.EnableLocalNotifications(title, message, delay);
#elif UNITY_IOS
        FGLiOSInternals.EnableLocalNotifications(title, message, delay);
#endif
    }

    /**
     * Disable local notifications
     */
    static public void DisableLocalNotification()
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.DisableLocalNotifications();
#elif UNITY_ANDROID
        FGLAndroidInternals.DisableLocalNotifications();
#elif UNITY_IOS
        FGLiOSInternals.DisableLocalNotifications();
#endif
    }

    ///// PRIVATE /////
    static public void InitializeEnhance()
    {
        if (!mInitialized)
        {
            mInitialized = true;

#if UNITY_EDITOR
            FGLEditorInternals.Initialize();
#elif UNITY_ANDROID
            FGLAndroidInternals.Initialize();
#elif UNITY_IOS
            FGLiOSInternals.Initialize();
#endif
        }
    }

    static bool mInitialized = false;
}