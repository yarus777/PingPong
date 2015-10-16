#if UNITY_ANDROID && !UNITY_EDITOR

using System;
using System.Collections.Generic;

using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android
{
	public class AndroidAppodealClient : IAppodealAdsClient 
	{

		AndroidJavaClass appodealClass;
		AndroidJavaObject activity;

		public AndroidJavaClass getAppodealClass() {
			if (appodealClass == null) {
				appodealClass = new AndroidJavaClass("com.appodeal.ads.Appodeal");
			}
			return appodealClass;
		}
		
		public AndroidJavaObject getActivity() {
			if (activity == null) {
				AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			return activity;
		}
		
		public void initialize(string appKey) 
		{
			getAppodealClass().CallStatic("initialize", getActivity(), appKey);
		}

		public void initialize(string appKey, int adTypes) 
		{
			getAppodealClass().CallStatic("initialize", getActivity(), appKey, adTypes);
		}


		public void setInterstitialCallbacks(IInterstitialAdListener listener) 
		{
			getAppodealClass().CallStatic("setInterstitialCallbacks", new AppodealInterstitialCallbacks(listener));
		}
		
		public void setVideoCallbacks(IVideoAdListener listener)
		{
			getAppodealClass().CallStatic("setVideoCallbacks", new AppodealVideoCallbacks(listener));
		}
		
		public void setBannerCallbacks(IBannerAdListener listener)
		{
			getAppodealClass().CallStatic("setBannerCallbacks", new AppodealBannerCallbacks(listener));
		}
		
		public void cache(int adTypes)
		{
			getAppodealClass().CallStatic("cache", getActivity(), adTypes);
		}
		
		public Boolean isLoaded(int adTypes) 
		{
			return getAppodealClass().CallStatic<Boolean>("isLoaded", adTypes);
		}
		
		public Boolean isPrecache(int adTypes) 
		{
			return getAppodealClass().CallStatic<Boolean>("isPrecache", adTypes);
		}
		
		public Boolean show(int adTypes)
		{
			return getAppodealClass().CallStatic<Boolean>("show", getActivity(), adTypes);
		}
		
		public Boolean showWithPriceFloor(int adTypes)
		{
			return getAppodealClass().CallStatic<Boolean>("showWithPriceFloor", getActivity(), adTypes);	
		}
		
		public void hide(int adTypes)
		{
			getAppodealClass().CallStatic("hide", getActivity(), adTypes);
		}
		
		public void setAutoCache(int adTypes, Boolean autoCache) 
		{
			getAppodealClass().CallStatic("setAutoCache", adTypes, autoCache);	
		}
		
		public void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) 
		{
			getAppodealClass().CallStatic("setOnLoadedTriggerBoth", adTypes, onLoadedTriggerBoth);
		}

		public void disableNetwork(String network) 
		{
			getAppodealClass().CallStatic("disableNetwork", getActivity(), network);
		}
		
		public void disableLocationPermissionCheck() 
		{
			getAppodealClass().CallStatic("disableLocationPermissionCheck");
		}
		
		public void orientationChange()
		{
			getAppodealClass().CallStatic("orientationChange");
		}
		
		public Boolean isLoadedWithPriceFloor(int adTypes) 
		{
			return getAppodealClass().CallStatic<Boolean>("isLoadedWithPriceFloor", adTypes);
		}

		public void setTesting(Boolean test)
		{
			getAppodealClass().CallStatic("setTesting", test);
		}
		
		public string getVersion()
		{
			return getAppodealClass().CallStatic<string>("getVersion");
		}

	}
}

#endif