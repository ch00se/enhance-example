using UnityEngine;
using System.Runtime.InteropServices;

namespace FGL.Enhance.Internals
{
    internal class FGLiOSInternals
    {
        [DllImport("__Internal")]
        private static extern void EnhanceConnector_setReceivedCurrencyCallback(string bridgeObjectName);

        [DllImport("__Internal")]
        private static extern bool FGLConnector_requestInterstitialEvents(string bridgeObjectName);
        
        [DllImport ("__Internal")]
		private static extern bool EnhanceConnector_isInterstitialAdReady(string placement);

        [DllImport ("__Internal")]
		private static extern void EnhanceConnector_showInterstitialAd(string placement);

        [DllImport ("__Internal")]
		private static extern bool EnhanceConnector_isRewardedAdReady(string placement);

        [DllImport ("__Internal")]
		private static extern void EnhanceConnector_showRewardedAd(string placement, string bridgeObjectName);

		[DllImport("__Internal")]
		private static extern bool EnhanceConnector_isBannerAdReady(string placement);

		[DllImport("__Internal")]
		private static extern void EnhanceConnector_showBannerAd(string placement, string position);

		[DllImport("__Internal")]
		private static extern void EnhanceConnector_hideBannerAd();

        [DllImport("__Internal")]
		private static extern bool EnhanceConnector_isSpecialOfferReady(string placement);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_showSpecialOffer(string placement);

        [DllImport("__Internal")]
		private static extern bool EnhanceConnector_isOfferwallReady(string placement);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_showOfferwall(string placement);

        [DllImport ("__Internal")]
		private static extern void EnhanceConnector_logEvent(string eventType, string paramKey, string paramValue);

        [DllImport("__Internal")]
        private static extern void FGLConnector_logMessage(string tag, string message);

        [DllImport("__Internal")]
        private static extern void FGLConnector_setSdkValue(string sdkId, string key, string value);

        [DllImport("__Internal")]
        private static extern void FGLConnector_setCurrentScreen(string name);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_requestLocalNotificationsPermission(string bridgeObjectName);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_enableLocalNotifications(string title, string message, int delay);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_disableLocalNotifications();

        [DllImport("__Internal")]
		private static extern bool EnhanceConnector_isPurchasingSupported();

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_attemptPurchase(string sku, string bridgeObjectName);

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_consumePurchase(string sku, string bridgeObjectName);

        [DllImport("__Internal")]
		private static extern string EnhanceConnector_getDisplayPrice(string sku, string defaultPrice);

		[DllImport("__Internal")]
		private static extern string EnhanceConnector_getDisplayTitle(string sku, string defaultTitle);

		[DllImport("__Internal")]
		private static extern string EnhanceConnector_getDisplayDescription(string sku, string defaultDescription);

        [DllImport("__Internal")]
		private static extern bool EnhanceConnector_isItemOwned(string sku);

		[DllImport("__Internal")]
		private static extern int EnhanceConnector_getOwnedItemCount(string sku);

        [DllImport("__Internal")]
        private static extern bool FGLConnector_isRestoringNeeded();

        [DllImport("__Internal")]
		private static extern void EnhanceConnector_manuallyRestorePurchases(string bridgeObjectName);

        [DllImport("__Internal")]
        private static extern void FGLConnector_requestAppConfig(string bridgeObjectName);

        public static void Initialize()
        {
        }

        public static void RequestInterstitialEvents(string bridgeObjectName)
        {
            FGLConnector_requestInterstitialEvents(bridgeObjectName);
        }

        public static void SetCurrencyCallback(string bridgeObjectName)
        {
            EnhanceConnector_setReceivedCurrencyCallback(bridgeObjectName);
        }

        public static bool IsInterstitialReady(string placement)
        {
            return EnhanceConnector_isInterstitialAdReady(placement);
        }

        public static void ShowInterstitialAd(string placement)
        {
            EnhanceConnector_showInterstitialAd(placement);
        }

        public static bool IsRewardedAdReady(string placement)
        {
            return EnhanceConnector_isRewardedAdReady(placement);
        }

        public static void ShowRewardedAd(string placement, string bridgeObjectName)
        {
            EnhanceConnector_showRewardedAd(placement, bridgeObjectName);
        }

		public static bool IsBannerAdReady(string placement)
		{
			return EnhanceConnector_isBannerAdReady(placement);
		}

		public static void ShowBannerAd(string placement, string position)
		{
			EnhanceConnector_showBannerAd(placement, position);
		}

		public static void HideBannerAd()
		{
			EnhanceConnector_hideBannerAd();
		}

        public static bool IsSpecialOfferReady(string placement)
        {
            return EnhanceConnector_isSpecialOfferReady(placement);
        }

        public static void ShowSpecialOffer(string placement)
        {
            EnhanceConnector_showSpecialOffer(placement);
        }

        public static bool IsOfferwallReady(string placement)
        {
            return EnhanceConnector_isOfferwallReady(placement);
        }

        public static void ShowOfferwall(string placement)
        {
            EnhanceConnector_showOfferwall(placement);
        }

        public static void LogEvent(string eventType)
        {
            EnhanceConnector_logEvent(eventType, null, null);
        }

        public static void LogEvent(string eventType, string paramKey, string paramValue)
        {
            EnhanceConnector_logEvent(eventType, paramKey, paramValue);
        }

        public static void LogMessage(string tag, string message)
        {
            FGLConnector_logMessage(tag, message);
        }

        public static void SetSdkValue(string sdkId, string key, string value)
        {
            FGLConnector_setSdkValue(sdkId, key, value);
        }

        public static void SetCurrentScreen(string name)
        {
            FGLConnector_setCurrentScreen(name);
        }

        public static void RequestLocalNotificationsPermission(string bridgeObjectName)
        {
            EnhanceConnector_requestLocalNotificationsPermission(bridgeObjectName);
        }

        public static void EnableLocalNotifications(string title, string message, int delay)
        {
            EnhanceConnector_enableLocalNotifications(title, message, delay);
        }

        public static void DisableLocalNotifications()
        {
            EnhanceConnector_disableLocalNotifications();
        }

        public static bool IsPurchasingSupported()
        {
            return EnhanceConnector_isPurchasingSupported();
        }

        public static void AttemptPurchase(string sku, string bridgeObjectName)
        {
            EnhanceConnector_attemptPurchase(sku, bridgeObjectName);
        }

        public static void ConsumePurchase(string sku, string bridgeObjectName)
        {
            EnhanceConnector_consumePurchase(sku, bridgeObjectName);
        }

        public static string GetDisplayPrice(string sku, string defaultPrice)
        {
            return EnhanceConnector_getDisplayPrice(sku, defaultPrice);
        }

		public static string GetDisplayTitle(string sku, string defaultTitle)
		{
			return EnhanceConnector_getDisplayTitle(sku, defaultTitle);
		}

		public static string GetDisplayDescription(string sku, string defaultDescription)
		{
			return EnhanceConnector_getDisplayDescription(sku, defaultDescription);
		}

        public static bool IsItemOwned(string sku)
        {
            return EnhanceConnector_isItemOwned(sku);
        }

		public static int GetOwnedItemCount(string sku)
		{
			return EnhanceConnector_getOwnedItemCount(sku);
		}

        public static bool IsRestoringNeeded()
        {
            return FGLConnector_isRestoringNeeded();
        }

		public static void ManuallyRestorePurchases(string bridgeObjectName)
        {
			EnhanceConnector_manuallyRestorePurchases(bridgeObjectName);
		}

        public static void RequestAppConfig(string bridgeObjectName)
        {
            FGLConnector_requestAppConfig(bridgeObjectName);
        }
    }
}
