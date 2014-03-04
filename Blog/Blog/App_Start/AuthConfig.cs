using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using BlogSite.Models;

namespace BlogSite
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "FES8xpSXXWERWYMPnjyIxw",
                consumerSecret: "fqamtiOuI0b35H6ymkeoCJxtXZ5q7mVZhGyONL07U");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "279311015524396",
                appSecret: "221faaae8f88d7b1f6f514c0da4d4e99");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
