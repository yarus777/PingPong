using UnityEngine;
using System;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api 
{
	public class Appodeal 
	{
		private static IAppodealAdsClient client;

		public const int INTERSTITIAL  = 1;
		public const int VIDEO         = 2;
		public const int BANNER        = 4;
		public const int BANNER_BOTTOM = 8;
		public const int BANNER_TOP    = 16;
		public const int BANNER_CENTER = 32;
		public const int ALL           = 127;
		public const int ANY           = 127;

		public static IAppodealAdsClient getInstance() {
			if (client == null) {
				client = AppodealAdsClientFactory.GetAppodealAdsClient();
			}
			return client;
		}

		public static void initialize(String appKey)
		{
			#if !UNITY_EDITOR
			getInstance().initialize(appKey);
			#endif
		}

		public static void initialize(String appKey, int adTypes)
		{
			#if !UNITY_EDITOR
			getInstance().initialize(appKey, adTypes);
			#endif
		}

		public static void setInterstitialCallbacks(IInterstitialAdListener listener)
		{
			#if !UNITY_EDITOR
			getInstance().setInterstitialCallbacks (listener);
			#endif
		}
		
		public static void setVideoCallbacks(IVideoAdListener listener)
		{
			#if !UNITY_EDITOR
			getInstance().setVideoCallbacks (listener);
			#endif
		}
		
		public static void setBannerCallbacks(IBannerAdListener listener)
		{
			#if !UNITY_EDITOR
			getInstance().setBannerCallbacks (listener);
			#endif
		}
		
		public static void cache(int adTypes)
		{
			#if !UNITY_EDITOR
			getInstance().cache (adTypes);
			#endif
		}
		
		public static Boolean isLoaded(int adTypes) 
		{
			Boolean isLoaded = false;
			#if !UNITY_EDITOR
			isLoaded = getInstance().isLoaded (adTypes);
			#endif
			return isLoaded;
		}
		
		public static Boolean isPrecache(int adTypes) 
		{
			Boolean isPrecache = false;
			#if !UNITY_EDITOR
			isPrecache = getInstance().isPrecache (adTypes);
			#endif
			return isPrecache;
		}
		
		public static Boolean show(int adTypes)
		{
			Boolean show = false;
			#if !UNITY_EDITOR
			show = getInstance().show (adTypes);
			#endif
			return show;
		}
		
		public static Boolean showWithPriceFloor(int adTypes)
		{
			Boolean showWithPriceFloor = false;
			#if !UNITY_EDITOR
			showWithPriceFloor = getInstance().showWithPriceFloor (adTypes);
			#endif
			return showWithPriceFloor;
		}
		
		public static void hide(int adTypes)
		{
			#if !UNITY_EDITOR
			getInstance().hide (adTypes);
			#endif
		}
		
		public static void orientationChange()
		{
			#if !UNITY_EDITOR
			getInstance().orientationChange ();
			#endif
		}
		
		public static void setAutoCache(int adTypes, Boolean autoCache) 
		{
			#if !UNITY_EDITOR
			getInstance().setAutoCache (adTypes, autoCache);
			#endif
		}
		
		public static void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) 
		{
			#if !UNITY_EDITOR
			getInstance().setOnLoadedTriggerBoth (adTypes, onLoadedTriggerBoth);
			#endif
		}
		
		public static void disableNetwork(String network) 
		{
			#if !UNITY_EDITOR
			getInstance().disableNetwork (network);
			#endif
		}
		
		public static void disableLocationPermissionCheck() 
		{
			#if !UNITY_EDITOR
			getInstance().disableLocationPermissionCheck ();
			#endif
		}		
		
		public static void setTesting(Boolean test) 
		{
			#if !UNITY_EDITOR
			getInstance().setTesting (test);
			#endif
		}
		
        public static string getVersion()
        {
            String version = null;
            #if !UNITY_EDITOR
            version = getInstance().getVersion();
            #endif
            return version;
        }

        public static Boolean isLoadedWithPriceFloor(int adTypes)
        {
            Boolean isLoadedWithPriceFloor = false;
            #if !UNITY_EDITOR
			isLoadedWithPriceFloor = getInstance().showWithPriceFloor (adTypes);
            #endif
            return isLoadedWithPriceFloor;
        }
	}
}
