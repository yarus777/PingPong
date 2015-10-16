using UnityEngine;
using System.Collections;
#if UNITY_IOS
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
#endif
public class AppodealSettings : MonoBehaviour
{
    public string appKey;
#if UNITY_IOS
    void Awake()
    {
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL);
    }
#endif
}
