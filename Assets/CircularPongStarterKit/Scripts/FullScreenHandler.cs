using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#if UNITY_IOS
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
#endif
namespace Assets.CircularPongStarterKit.Scripts
{
    class FullScreenHandler
    {
        public static void ShowAds()
        {
            int count = PlayerPrefs.GetInt("lose_count", 0);
            count++;
            if (count == 5)
            {
#if UNITY_ANDROID
                if (AdSDK.readyFullScreen)
                {
                    AdSDK.readyFullScreen = false;
                    AdSDK.ShowFullscreen();
                    AdSDK.PreloadFullscreen();
                   
                }
#endif
//#if UNITY_IOS
//                Appodeal.show(Appodeal.INTERSTITIAL);
//#endif
                count = 0;
            }
            PlayerPrefs.SetInt("lose_count", count);
            PlayerPrefs.Save();
        }
    }


}
