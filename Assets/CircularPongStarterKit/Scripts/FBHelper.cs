using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Facebook;

namespace Assets.CircularPongStarterKit.Scripts
{
    static class FBHelper
    {
        static FBHelper()
        {
            FB.Init(OnInitComplete);
        }

        public static void Init()
        {
            Debug.Log("Init");
        }

        private static void OnInitComplete()
        {
            Debug.Log("PostInit");
        }

        public static void Feed()
        {
            string permissions = "email";
            if (!FB.IsInitialized)
            {
                FB.Init(Feed);
            }
            if (!FB.IsLoggedIn)
            {
                FB.Login("publish_action, public_profile, user_friends, email", OnLogin);
            }
            else
            {
                FeedInternal();
            }

            Debug.Log("Feed");
        }

        private static void FeedInternal()
        {
            string text = "Я набрал " + GameLogic2d.Instance.GetCurrentScore().ToString() + " очков";
            FB.Feed(linkName: "My Game", linkDescription: text, linkCaption: "fregrth", callback: OnFeed);
            Debug.Log("FeedInternal");
        }

        private static void OnFeed(FBResult result)
        {
            Debug.Log(result.Error);
            Debug.Log("Feed success");
        }

        private static void OnLogin(FBResult result)
        {
            Debug.Log("Login" + FB.UserId + " number");
            FeedInternal();
            
        }
    }
}
