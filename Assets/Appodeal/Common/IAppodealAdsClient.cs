using System;
using AppodealAds.Unity;

namespace AppodealAds.Unity.Common {
	public interface IAppodealAdsClient {
		// init sdk
		void initialize(string appKey);
		void initialize(string appKey, int type);

		void orientationChange ();
		void disableNetwork (String network);
		void disableLocationPermissionCheck();

		void setInterstitialCallbacks (IInterstitialAdListener listener);
		void setVideoCallbacks (IVideoAdListener listener);
		void setBannerCallbacks (IBannerAdListener listener);
		void cache (int adTypes);
		
		Boolean isLoaded (int adTypes);
		Boolean isLoadedWithPriceFloor (int adTypes);
		Boolean isPrecache (int adTypes);
		Boolean show(int adTypes);
		Boolean showWithPriceFloor(int adTypes);

		void hide (int adTypes);
		void setAutoCache (int adTypes, Boolean autoCache);
		void setOnLoadedTriggerBoth (int adTypes, Boolean onLoadedTriggerBoth);
		void setTesting(Boolean test);
		
		string getVersion();
		
	}
}
