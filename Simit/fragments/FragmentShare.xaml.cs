using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Simit.page;
using TweetSharp;
using Microsoft.Phone.Tasks;
using Simit.page;
namespace Simit.fragments
{
    public partial class FragmentShare : UserControl
    {
        HomePage context;
        //twitter
        private TweetSharp.TwitterService service;
        private OAuthRequestToken requestToken;
        private OAuthAccessToken accessToken;
        private Uri uri;
        private String message;

        public FragmentShare(HomePage context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void button_share_facebook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //realiza el comentario en facebook y comparte el enlace
            Facebook.Client.Session.ShowFeedDialog(null, resources.@string.StringResource.url_site_simit, resources.@string.StringResource.app_name
                            , resources.@string.StringResource.dialog_share, null, null);

        }

        private void button_share_twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            dialogTwitter.Visibility = Visibility.Visible;
            textTwitterImput.Text = resources.@string.StringResource.dialog_share;
        }

        private void buttonCancel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            dialogTwitter.Visibility = Visibility.Collapsed;
        }

        private void button_accept_twiter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (textTwitterImput.Text.Length > 100)
            {
                MessageBox.Show(resources.@string.StringResource.text_dialog_twitter);
            }
            else
            {
                dialogTwitter.Visibility = Visibility.Collapsed;
                //realizo la publicacion
                try
                {
                    context.openBackgroundProgressBar();
                    TweetPost(textTwitterImput.Text);
                }
                catch (Exception exception)
                {
                    context.closeBackgroundProgressBar();
                    MessageBox.Show(resources.@string.StringResource.error_post_tweet);
                }
            }
        }

        public void onBackPress(System.ComponentModel.CancelEventArgs e)
        {
            if (dialogTwitter.Visibility == Visibility.Visible)
            {
                dialogTwitter.Visibility = Visibility.Collapsed;
                context.closeBackgroundProgressBar();
                e.Cancel = true;
            }
            else if (webView.Visibility == Visibility.Visible)
            {
                webView.Visibility = Visibility.Collapsed;
                context.closeBackgroundProgressBar();
                e.Cancel = true;
            }
            else
            {
                context.backTrue(e);
            }
        }

        //metodos para la publicacion con twitter
        /*-------------------------------------------------------------------------------------------------------------------------*/
        private void getRequestToken()
        {
            //creo el servicio
            service = new TwitterService(resources.@string.StringResource.consumer_token_twitter, resources.@string.StringResource.consumer_token_secret_twitter);
            var cb = new Action<OAuthRequestToken, TwitterResponse>(CallBackToken);
            service.GetRequestToken("", CallBackToken);//pido el request token
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
            Dispatcher.BeginInvoke(() =>
            {
                webView.Visibility = Visibility.Visible;
                Browser.Navigate(uri);
            });
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
                accessToken = rt;
                //envio el mensaje
                setTweet(accessToken.Token, accessToken.TokenSecret);
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
                        MessageBox.Show(resources.@string.StringResource.message_public_tweet_ok);
                    });
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            });
        }

        private void Browser_Navigating(object sender, NavigatingEventArgs e)
        {
            if (e.Uri.ToString().Contains("?oauth_token") && e.Uri.ToString().Contains("&oauth_verifier"))
            {
                string[] separators = { "?oauth_token=", "&oauth_verifier=" };
                string[] values = e.Uri.ToString().Split(separators, StringSplitOptions.None);
                webView.Visibility = Visibility.Collapsed;// cierro el navegador
                //llamo al metodo que obtiene el token de acceso con el de verificacion
                getAccesToken(values[2]);
            }
            else if (e.Uri.ToString().Contains("https://consulta.simit.org.co/Simit/index.html") || e.Uri.ToString().Contains("?denied"))
            {
                // se rechaso la autorizacion a la aplicacion
                //cierro el webView
                webView.Visibility = Visibility.Collapsed;
            }
        }

        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            context.closeBackgroundProgressBar();
        }

        private void button_send_mail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Body = resources.@string.StringResource.body_email;//cuerpo del mensaje a enviar
            email.Show();
        }

        private void button_page_facebook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_facebook, UriKind.RelativeOrAbsolute));
        }

        private void button_page_twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_twitter, UriKind.RelativeOrAbsolute));
        }

        private void button_page_simit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_simit, UriKind.RelativeOrAbsolute));
        }

        private void Browser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            context.closeBackgroundProgressBar();
        }

        private void button_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.popup_info.Visibility = Visibility.Visible;
        }

        private void button_close_popup_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.popup_info.Visibility = Visibility.Collapsed;
        }
    }
}
