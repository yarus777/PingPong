#if UNITY_ANDROID

using UnityEngine;
using AppodealAds.Unity.Common;
using AppodealAds.Unity.Api;

namespace AppodealAds.Unity.Android
{
	internal class AdListener : AndroidJavaProxy
	{
		private IAdListener listener;
		internal AdListener(IAdListener listener, int adTypes)
			: base(Utils.GetListenerFromType(adTypes))
		{
			this.listener = listener;
		}

		#region Banner Callbacks implementation

		void onBannerLoaded() {
			listener.FireAdLoaded();
		}
		
		void onBannerFailedToLoad() {
			listener.FireAdFailedToLoad("");
		}
		
		void onBannerShown() {
			listener.FireAdOpened();
		}
		
		void onBannerClicked() {
			listener.FireAdLeftApplication();
		}

		#endregion

		#region Interstitial Callbacks implementation

		void onInterstitialLoaded(bool isPrecache) {
			listener.FireAdLoaded();
		}
		
		void onInterstitialFailedToLoad() {
			listener.FireAdFailedToLoad ("");
		}
		
		void onInterstitialShown() {
			listener.FireAdOpened();
		}
		
		void onInterstitialClicked() {
			listener.FireAdLeftApplication();
		}
		
		void onInterstitialClosed() {
			listener.FireAdClosing();
			listener.FireAdClosed();
		}

		#endregion

		#region Video Callbacks implementation

		void onVideoLoaded() {
			listener.FireAdLoaded();
		}
		
		void onVideoFailedToLoad() {
			listener.FireAdFailedToLoad ("");
		}
		
		void onVideoShown() {
			listener.FireAdOpened();
		}
		
		void onVideoFinished() {
			listener.FireRewardUser(0);
		}
		
		void onVideoClosed() {
			listener.FireAdClosing();
			listener.FireAdClosed();
		}

		#endregion
	}
}

#endif
