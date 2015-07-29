using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using Hammock;
using System.Net;
using Microsoft.Phone.Controls;
using System.Windows;
using System.Threading;

namespace Simit.classAux
{
    class TwitterSharpIntegrated
    {
        private TweetSharp.TwitterService service;
        private OAuthRequestToken requestToken;
        private OAuthAccessToken accessToken;
        private String accessTokenFinal;
        private String accessTokensecretFinal;
        private Uri uri;
        private WebBrowser webBrowser;
        private String message;
        public PhoneApplicationPage pageHome { get; set; }

        public TwitterSharpIntegrated()
        {
            service = new TwitterService("oyPeJmke0eto8rxZZuOBzrNim", "dOh3sS9pNzzhsyPocKFg7Be51l9Q60KvaE1UoTBeK2Q0VEqX02");
        }



        private void getRequestToken()
        {
            var cb = new Action<OAuthRequestToken, TwitterResponse>(CallBackToken);
            service.GetRequestToken("", CallBackToken);
        }

        private void CallBackToken(OAuthRequestToken rt, TwitterResponse response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Unable to connect to twitter");
            }
            uri = service.GetAuthorizationUri(rt);
            requestToken = rt;
            //creo el webView donde se loquea el usuario para la autorizacion
            webBrowser.Dispatcher.BeginInvoke(() =>
            {
                webBrowser.Navigate(uri);
            });
        }

        void webBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            if (e.Uri.ToString().Contains("?oauth_token"))
            {
                webBrowser.Visibility = System.Windows.Visibility.Collapsed;
                string[] separators = { "?oauth_token=" };
                string[] values = e.Uri.ToString().Split(separators, StringSplitOptions.None);
                getAccesToken(values[1]);
            }
        }

        private void getAccesToken(String veriferToken)
        {
            var cb = new Action<OAuthAccessToken, TwitterResponse>(CallBackVeriferToken);
            service.GetAccessToken(requestToken, veriferToken, CallBackVeriferToken);
        }

        private void CallBackVeriferToken(OAuthAccessToken rt, TwitterResponse arg2)
        {
            if (rt != null)
            {
                accessTokenFinal = rt.Token;
                accessTokensecretFinal = rt.TokenSecret;
                //envio el mensaje
                setTweet(accessTokenFinal, accessTokensecretFinal);
            }
        }


        public void TweetPost(String message)
        {
            if (message != null)
            {
                getRequestToken();
                this.message = message;//guardo el mensaje
            }
        }

        private void setTweet(String AccessToken, String AccessTokenSecret)
        {

            service.AuthenticateWith(AccessToken, AccessTokenSecret);
            service.SendTweet(new SendTweetOptions { Status = this.message + " " + "http://www.simit.org.co" }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        //TwitterStatus tweet = status;

                    });
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            });
        }

    }

    
}
