using UnityEngine;
using System.Collections;

public static class AdSDK {
	#if (UNITY_ANDROID || UNITY_EDITOR)
	
	public enum GenderType {
		UNKNOWN, MALE, FEMALE
	}
	
	private static AndroidJavaObject banner = null;
	private static AndroidJavaObject debugBanner = null;
	
	public static string publisherId = "adeco";
	public static string appKey = "barleybreak" ;
	public static string affId = "adeco" ;
	
	public static string market = "4shared.com";
	
	public static string placementRKey = "r_game";
	public static string placementVRKey = "vr_game";
	public static string placementIRKey = "ir_game";
	public static string placementFKey = "f_game";
	
	public static string flurryKey = "";
	
	public enum BannerAlignment { TOP = 0, BOTTOM = 1 }
	public static BannerAlignment alignment;
	
	public static int bannerWidth;
	public static int bannerHeight;
	
	public static bool readyFullScreen;
	
	private static bool isFirstLaunch = true;
	
	private static void Init(bool debug) {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("initialize", getCurrentActivity(), debug, flurryKey);
	}
	
	public static void PreloadVideo() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("preloadVideo", getCurrentActivity());
	}
	
	public static void ShowVideo() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("showVideo", getCurrentActivity());
	}
	
	public static void setVideoListener() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("setVideoScreenListener", new FullscreenListener());
	}
	
	public static void PreloadFullscreen() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("preloadFullscreen", getCurrentActivity());
	}
	
	public static void ShowFullscreen() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("showFullscreen", getCurrentActivity());
	}
	
	public static void setFullscreenListener() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("setFullScreenListener",new FullscreenListener());
	}
	
	public static void StartDebug () {
		AndroidJavaObject param = BuildBannerParams(placementFKey);  
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("startDebug", param, getCurrentActivity());
	}
	
	
	public static void StopDebug () {
		AndroidJavaObject param = BuildBannerParams(placementFKey);  
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("stopDebug", getCurrentActivity());    
	}
	
	public static void DestroyBanner() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("deleteBanner", getCurrentActivity());
	}
	
	
	private static AndroidJavaObject BuildBannerParams(string placement) {
		AndroidJavaObject obj = GetParams();
		obj.Call<AndroidJavaObject>("setPlacementKey", placement);
		AndroidJavaObject obj2 = new AndroidJavaObject ("com.inappertising.ads.core.model.AdSize", bannerWidth, bannerHeight);
		obj.Call<AndroidJavaObject> ("setSize", obj2);
		AndroidJavaObject param = obj.Call<AndroidJavaObject>("build");
		return param;
	}
	
	
	private static AndroidJavaObject GetParams() {
		AndroidJavaObject obj = new AndroidJavaObject("com.inappertising.ads.core.model.AdParametersBuilder");
		obj.Call<AndroidJavaObject>("setPublisherId", publisherId);
		obj.Call<AndroidJavaObject>("setAppKey", appKey);
		
		obj.Call<AndroidJavaObject>("setMarket", market);
		
		obj.Call<AndroidJavaObject>("setAffId", affId);
		return obj;
	}
	
	public static void CreateBanner() {
		AndroidJavaObject param = BuildBannerParams(placementRKey);
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("addBanner", param, (int) alignment, getCurrentActivity());
	}
	
	public static void SetBannerVisible(bool visible) {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("setBannerVisible", visible, getCurrentActivity());
	}
	
	private static AndroidJavaObject getCurrentActivity() {
		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = ajc.GetStatic<AndroidJavaObject>("currentActivity");
		return activity;
	}
	
	// Analytics methods
	
	public static void StartFlurrySession() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		AndroidJavaObject param = BuildBannerParams(placementVRKey);
		clazz.CallStatic("onStart", getCurrentActivity(), flurryKey, param);
	}
	
	private static void StopFlurrySession() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("onStop", getCurrentActivity());
	}
	
	private static void SendDownload() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("sendDownload", getCurrentActivity(), publisherId, affId, appKey);
	}
	
	public static void SendConversion() {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("sendConversion", getCurrentActivity(), publisherId, affId, appKey);
	}
	
	public static void SendEvent(string someEvent) {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("sendCustomEvent", getCurrentActivity(), publisherId, affId, appKey, someEvent);
	}
	
	public static void listenForInstall(string packageName, string eventName) {
		AndroidJavaClass clazz = new AndroidJavaClass("com.inappertising.ads.unity.AdSDKPlugin");
		clazz.CallStatic("listenForInstall", getCurrentActivity(), packageName, eventName, publisherId, affId, appKey);
	}
	
	public static void StartSDK(bool debug = true) {
		if (isFirstLaunch) {
			Init (debug);
			StartFlurrySession();
			if(!PlayerPrefs.HasKey("startApp"))
			{
				SendDownload();
				PlayerPrefs.SetInt("startApp", 1);
			}
			isFirstLaunch = false;
		}
//		listenForInstall("com.better.alarm", "FULL_VERSION_MARKET");
	}
	
	class FullscreenListener : AndroidJavaProxy {
		public FullscreenListener() : base("com.inappertising.ads.interstitial.ads.Interstitial$InterstitialListener") { 
			Debug.Log("FullscreenListener created");
		}
		void onAdLoaded(AndroidJavaObject ad){
		}
		void onAdLoadFailed(AndroidJavaObject ad){
			Debug.Log("ShowFullscreen onAdLoadFailed");
		}
		void onAdReady(AndroidJavaObject ad){
			AdSDK.readyFullScreen = true;
		}
		void onAdReadyFailed(AndroidJavaObject ad){
			AdSDK.PreloadFullscreen();
		}
	}
	
	class VideoListener : AndroidJavaProxy {
		public VideoListener() : base("com.inappertising.ads.video.ads.VideoAdListener") { 
			Debug.Log("VideoListener created");
		}
		void onAdFailedToLoad(System.String reason){
			Debug.Log("ShowVideo onAdLoadFailed " + reason);
		}
		void onAdLoaded(){
			Debug.Log("ShowVideo onAdLoaded");
		}
	}
	
	
	#endif
	
}