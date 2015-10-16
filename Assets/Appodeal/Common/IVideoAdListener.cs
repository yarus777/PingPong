using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	public interface IVideoAdListener
	{
		void onVideoLoaded();
		void onVideoFailedToLoad();
		void onVideoShown();
		void onVideoFinished();
		void onVideoClosed();
		void onVideoClicked();
	}
}
