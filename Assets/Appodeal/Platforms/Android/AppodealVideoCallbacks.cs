using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealVideoCallbacks 
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IVideoAdListener listener;

		internal AppodealVideoCallbacks(IVideoAdListener listener) : base("com.appodeal.ads.VideoCallbacks") {
			this.listener = listener;
		}
		
		void onVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
			listener.onVideoLoaded();
		}
		
		void onVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
			listener.onVideoFailedToLoad();
		}
		
		void onVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
			listener.onVideoShown();
		}
		
		void onVideoFinished() {
			//Debug.Log("Appodeal onVideoFinished");
			listener.onVideoFinished();
		}
		
		void onVideoClosed() {
			//Debug.Log("Appodeal onVideoClosed");
			listener.onVideoClosed();
		}
	}
#else
	{
		public AppodealVideoCallbacks(IVideoAdListener listener) { }
	}
#endif
}
