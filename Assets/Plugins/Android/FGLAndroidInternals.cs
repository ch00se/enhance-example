#if UNITY_ANDROID
using UnityEngine;

namespace FGL.Enhance.Internals
{
    internal class FGLAndroidInternals
    {
        public static void Initialize()
        {
        }
        
        public static void SetCurrencyCallback(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setCurrencyCallback", bridgeObjectName);
        }

        public static void RequestInterstitialEvents(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestInterstitialEvents", bridgeObjectName);
        }

        public static bool IsInterstitialReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isInterstitialReady", placement);
        }

        public static void ShowInterstitialAd(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showInterstitialAd", placement);
        }

        public static bool IsRewardedAdReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isRewardedAdReady", placement);
        }

        public static void ShowRewardedAd(string placement, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showRewardedAd", placement, bridgeObjectName);
        }

		public static bool IsBannerAdReady(string placement)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			return adConnectorClass.CallStatic<bool>("isBannerAdReady", placement);
		}

		public static void ShowBannerAd(string placement, string position)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("showBannerAd", placement, position);
		} 

		public static void HideBannerAd()
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("hideBannerAd");
		}

        public static bool IsSpecialOfferReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isSpecialOfferReady", placement);
        }

        public static void ShowSpecialOffer(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showSpecialOffer", placement);
        }

        public static bool IsOfferwallReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isOfferwallReady", placement);
        }

        public static void ShowOfferwall(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showOfferwall", placement);
        }

        public static void LogEvent(string eventType)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logEvent", eventType, null, null);
        }

        public static void LogEvent(string eventType, string paramKey, string paramValue)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logEvent", eventType, paramKey, paramValue);
        }

        public static void LogMessage(string tag, string message)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logMessage", tag, message);
        }

        public static void SetSdkValue(string sdkId, string key, string value)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setSdkValue", sdkId, key, value);
        }

        public static void SetCurrentScreen(string name)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setCurrentScreen", name);
        }

        public static void RequestLocalNotificationsPermission(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestLocalNotificationsPermission", bridgeObjectName);
        }

        public static void EnableLocalNotifications(string title, string message, int delay)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("enableLocalNotifications", title, message, delay);
        }

        public static void DisableLocalNotifications()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("disableLocalNotifications");
        }

        public static bool IsPurchasingSupported()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isPurchasingSupported");
        }

        public static void AttemptPurchase(string sku, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("attemptPurchase", sku, bridgeObjectName);
        }

        public static void ConsumePurchase(string sku, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("consumePurchase", sku, bridgeObjectName);
        }

        public static string GetDisplayPrice(string sku, string defaultPrice)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getPurchaseDisplayPrice", sku, defaultPrice);
        }

        public static bool IsItemOwned(string sku)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isPurchaseItemOwned", sku);
        }

		public static int GetOwnedItemCount(string sku)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass ("com.fgl.enhance.unityconnector.FGLUnityConnector");
			return adConnectorClass.CallStatic<int>("getOwnedItemCount", sku);
		}

        public static bool IsRestoringNeeded()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isRestoringNeeded");
        }

        public static void RestorePurchases(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("restorePurchases", bridgeObjectName);
        }

        public static void RequestAppConfig(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestAppConfig", bridgeObjectName);
        }

        public static void ManuallyRestorePurchases(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("manuallyRestorePurchases", bridgeObjectName);
        }

        public static string GetDisplayTitle(string sku, string defaultTitle)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getDisplayTitle", sku, defaultTitle);
        }

        public static string GetDisplayDescription(string sku, string defaultDescription)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getDisplayDescription", sku, defaultDescription);
        }
    }
}
#endif
