//
//  AppodealInterface.m
//
//  Created by ewgenius on 4.08.15.
//  Copyright (c) 2015 Appodeal. All rights reserved.
//

#if defined(__has_include) && __has_include("UnityAppController.h")
#import "UnityAppController.h"
#else
#import "EmptyUnityAppController.h"
#endif

#import <Appodeal/Appodeal.h>
#import <Appodeal/AppodealInterstitialDelegate.h>
#import <Appodeal/AppodealBannerDelegate.h>
#import <Appodeal/AppodealVideoDelegate.h>

#import "AppodealObjCBridge.h"
#import "AppodealInterstitialDelegate.h"
#import "AppodealVideoDelegate.h"
#import "AppodealBannerDelegate.h"


static NSString *StringFromUTF8String(const char *bytes) { return bytes ? @(bytes) : nil; }

static char * UTF8StringFromString(NSString *string) {
    const char *cString = [[Appodeal getVersion] UTF8String];
    char *cStringCopy = calloc([string length]+1, 1);
    return strncpy(cStringCopy, cString, [string length]);
}

static UIViewController* RootViewController() {
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
}

/// AppodealAdType enum:
///   AppodealAdTypeInterstitial = 1 << 0,
///   AppodealAdTypeVideo        = 1 << 1,
///   AppodealAdTypeBanner       = 1 << 2,
///   AppodealAdTypeAll          = AppodealAdTypeInterstitial | AppodealAdTypeVideo | AppodealAdTypeBanner

void AppodealInitialize(const char *apiKey) {
    [Appodeal initializeWithApiKey:StringFromUTF8String(apiKey)];
}

void AppodealInitializeWithTypes(const char *apiKey, int types) {
    [Appodeal initializeWithApiKey:StringFromUTF8String(apiKey) types:types];
}

/// AppodealShowStyle enum:
///   AppodealShowStyleInterstitial        = 1,
///   AppodealShowStyleVideo               = 2,
///   AppodealShowStyleVideoOrInterstitial = 3,
///   AppodealShowStyleBannerTop           = 4,
///   AppodealShowStyleBannerCenter        = 5,
///   AppodealShowStyleBannerBottom        = 6

BOOL AppodealShowAd(int style) {
    return [Appodeal showAd:style rootViewController: RootViewController()];
}

void AppodealSetAutocache(BOOL autocache, int types) {
    [Appodeal setAutocache:autocache types:types];
}

void AppodealCacheAd(int types) {
    [Appodeal cacheAd:types];
}

BOOL AppodealIsReadyWithStyle(int style) {
    return [Appodeal isReadyForShowWithStyle:style];
}

void AppodealHideBanner() {
    [Appodeal hideBanner];
}

static AppodealInterstitialDelegate *AppodealInterstitialDelegateInstance;

void AppodealSetInterstitialDelegate(AppodealNativeDelegate interstitialDidLoadAd,
                                     AppodealNativeDelegate interstitialDidFailToLoadAd,
                                     AppodealNativeDelegate interstitialDidClick,
                                     AppodealNativeDelegate interstitialDidDismiss,
                                     AppodealNativeDelegate interstitialWillPresent) {
    
    AppodealInterstitialDelegateInstance = [AppodealInterstitialDelegate new];
    
    AppodealInterstitialDelegateInstance.interstitialDidLoadAdDelegate = interstitialDidLoadAd;
    AppodealInterstitialDelegateInstance.interstitialDidFailToLoadAdDelegate = interstitialDidFailToLoadAd;
    AppodealInterstitialDelegateInstance.interstitialDidClickDelegate = interstitialDidClick;
    AppodealInterstitialDelegateInstance.interstitialDidDismissDelegate = interstitialDidDismiss;
    AppodealInterstitialDelegateInstance.interstitialWillPresentDelegate = interstitialWillPresent;
    
    [Appodeal setInterstitialDelegate:AppodealInterstitialDelegateInstance];
}


static AppodealBannerDelegate *AppodealBannerDelegateInstance;

void AppodealSetBannerDelegate(AppodealNativeDelegate bannerDidLoadAd,
                               AppodealNativeDelegate bannerDidFailToLoadAd,
                               AppodealNativeDelegate bannerDidClick) {
    
    AppodealBannerDelegateInstance = [AppodealBannerDelegate new];
    
    AppodealBannerDelegateInstance.bannerDidLoadAdDelegate = bannerDidLoadAd;
    AppodealBannerDelegateInstance.bannerDidFailToLoadAdDelegate = bannerDidFailToLoadAd;
    AppodealBannerDelegateInstance.bannerDidClickDelegate = bannerDidClick;
    
    [Appodeal setBannerDelegate:AppodealBannerDelegateInstance];
}

static AppodealVideoDelegate *AppodealVideoDelegateInstance;

void AppodealSetVideoDelegate(AppodealNativeDelegate videoDidLoadAd,
                              AppodealNativeDelegate videoDidFailToLoadAd,
                              AppodealNativeDelegate videoWillDismiss,
                              AppodealNativeDelegate videoDidFinish,
                              AppodealNativeDelegate videoDidPresent) {
    
    AppodealVideoDelegateInstance = [AppodealVideoDelegate new];
    
    AppodealVideoDelegateInstance.videoDidLoadAdDelegate = videoDidLoadAd;
    AppodealVideoDelegateInstance.videoDidFailToLoadAdDelegate = videoDidFailToLoadAd;
    AppodealVideoDelegateInstance.videoWillDismissDelegate = videoWillDismiss;
    AppodealVideoDelegateInstance.videoDidFinishDelegate = videoDidFinish;
    AppodealVideoDelegateInstance.videoDidPresentDelegate = videoDidPresent;
    
    [Appodeal setVideoDelegate:AppodealVideoDelegateInstance];
}

char * AppodealGetVersion() {
    return UTF8StringFromString([Appodeal getVersion]);
}

void AppodealDisableNetwork(const char * networkName) {
    [Appodeal disableNetworkForAdType:AppodealAdTypeAll name:StringFromUTF8String(networkName)];
}

void AppodealDisableLocationPermissionCheck() {
    [Appodeal disableLocationPermissionCheck];
}

void AppodealSetDebugEnabled(BOOL debugEnabled) {
    [Appodeal setDebugEnabled:debugEnabled];
}
