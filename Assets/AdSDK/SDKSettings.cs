using UnityEngine;
using System.Collections;

public class SDKSettings : MonoBehaviour {
	public string publisherId = "inappertising";
	public string appKey = "appkey" ;
	public string affId = "inappertising" ;
	
	public string market = "googleplay";
	
	public string placementRKey = "r_game";
	public string placementIRKey = "ir_game";
	public string placementFKey = "f_game";
	
	public string flurryKey = "";

	public bool debug = true;
	
	#if (UNITY_ANDROID)
	public AdSDK.BannerAlignment alignment = AdSDK.BannerAlignment.BOTTOM;
	
	
	// Use this for initialization
	void Awake () {
		#if !UNITY_EDITOR
		InitSDK ();
		AdSDK.StartSDK (debug);
		#endif
	}
	
	void Start() {
		#if !UNITY_EDITOR
		AdSDK.setFullscreenListener ();
		#endif
	}
	
	void InitSDK()
	{
		AdSDK.publisherId = publisherId;
		AdSDK.appKey = appKey;
		AdSDK.affId = affId;
		AdSDK.placementRKey = placementRKey;
		AdSDK.placementIRKey = placementIRKey;
		AdSDK.placementFKey = placementFKey;
		AdSDK.flurryKey = flurryKey;
		AdSDK.alignment = alignment;
		AdSDK.market = market;	
		AdSDK.bannerWidth = 320;
		AdSDK.bannerHeight = 50;
	}
	
	
	/*void OnGUI () {
		if (GUI.Button (new Rect (10,100,200,50), "Set fullscreen listener")) {
			AdSDK.setFullscreenListener(new FullscreenListener());
		}
		if (GUI.Button (new Rect (10,200,200,50), "Preload fullscreen")) {
			AdSDK.PreloadFullscreen();
		}
		if (GUI.Button (new Rect (10,300,200,50), "Show fullscreen")) {
			AdSDK.ShowFullscreen();
		}
		if (GUI.Button (new Rect (10,400,200,50), "Set video listener")) {
			AdSDK.setVideoListener(new VideoListener());
		}
		if (GUI.Button (new Rect (10,500,200,50), "Preload video")) {
			AdSDK.PreloadVideo();
		}
		if (GUI.Button (new Rect (10,600,200,50), "Show video")) {
			AdSDK.ShowVideo();
		}
	}*/
	
	#endif
	
	
	
}
