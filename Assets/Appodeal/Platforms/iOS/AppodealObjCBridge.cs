using System;
using System.Runtime.InteropServices;

namespace AppodealAds.Unity.iOS
{

	internal delegate void AppodealNativeDelegate ();

	internal class AppodealObjCBridge
	{
		[DllImport("__Internal")]
		internal static extern void AppodealInitialize (string apiKey);

		[DllImport("__Internal")]
		internal static extern void AppodealInitializeWithTypes (string apiKey, int types);
		
		[DllImport("__Internal")]
		internal static extern bool AppodealShowAd (int style);

		[DllImport("__Internal")]
		internal static extern void AppodealSetAutocache (bool autocache, int types);

		[DllImport("__Internal")]
		internal static extern void AppodealCacheAd (int types);

		[DllImport("__Internal")]
		internal static extern bool AppodealIsReadyWithStyle (int style);

		[DllImport("__Internal")]
		internal static extern void AppodealHideBanner ();

		[DllImport("__Internal")]
		internal static extern void AppodealSetInterstitialDelegate (
			AppodealNativeDelegate interstitialDidLoadAd,
			AppodealNativeDelegate interstitialDidFailToLoadAd,
			AppodealNativeDelegate interstitialDidClick,
			AppodealNativeDelegate interstitialDidDismiss,
			AppodealNativeDelegate interstitialWillPresent
		);

		[DllImport("__Internal")]
		internal static extern void AppodealSetVideoDelegate (
			AppodealNativeDelegate videoDidLoadAd,
			AppodealNativeDelegate videoDidFailToLoadAd,
			AppodealNativeDelegate videoWillDismiss,
			AppodealNativeDelegate videoDidFinish,
			AppodealNativeDelegate videoDidPresent
		);

		[DllImport("__Internal")]
		internal static extern void AppodealSetBannerDelegate (
			AppodealNativeDelegate bannerDidLoadAd,
			AppodealNativeDelegate bannerDidFailToLoadAd,
			AppodealNativeDelegate bannerDidClick
		);

		[DllImport("__Internal")]
		internal static extern string AppodealGetVersion ();

		[DllImport("__Internal")]
		internal static extern void AppodealDisableNetwork(string networkName);

		[DllImport("__Internal")]
		internal static extern void AppodealDisableLocationPermissionCheck();

		[DllImport("__Internal")]
		internal static extern void AppodealSetDebugEnabled(bool debugEnabled);
	}
}