using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;
using Simit.classAux;
using Simit.data;
using Simit.entities;
using System.Xml.Linq;
using Microsoft.Phone.Controls.Maps;
using System.Windows.Media;
using Microsoft.Phone.Controls.Maps.Platform;
using Facebook.Client;
using Simit.resources.@string;
using TweetSharp;
using TweetSharp.Model;
using Hammock.Authentication.OAuth;
using Hammock;
using Microsoft.Phone.Tasks;

namespace Simit.page
{
    public partial class HomePage : PhoneApplicationPage
    {
        public static String ICON_CONSULTATION_GREEN = "/image/Consultas_verde.png";
        public static String ICON_CONSULTATION_WHITE = "/image/Consultas_blanco.png";

        public static String ICON_ATENTION_GREEN = "/image/Puntos_verde.png";
        public static String ICON_ATENTION_WHITE = "/image/Puntos_blanco.png";

        public static String ICON_NEWS_GREEN = "/image/Noticias_verde.png";
        public static String ICON_NEWS_WHITE = "/image/Noticias_blanco.png";

        public static String ICON_SHARE_GREEN = "/image/Compartir_verde.png";
        public static String ICON_SHARE_WHITE = "/image/Compartir_blanco.png";

        //colores
        private static string COLOR_WHITE = "#ffffff";
        private static String COLOR_GREEN = "#73cf17";

        //para la ubicacion
        private static String LATITUDE = "-34.603623";//valor por defecto
        private static String LONGITUDE = "-58.381528";//valor por defecto
        private static String LATITUDE1 = "-34.603630";//valor por defecto
        private static String LONGITUDE1 = "-58.381528";//valor por defecto

        //list document prueba
        List<TypeDocument> listDocument = null;//inicializo la lista
        List<TypeNameAtentionPoints> listNameAtentionPoints = null;//inicializo la lista
        
        private int buttonSelect = 1; //identifica el boton activo

        //page
        private static String PAGE_CONSULTATIONS = "/page/PageConsultations.xaml";
        private static String  NUM_DEPARTMENT_DEFECT = "11";

        //twitter
        private TweetSharp.TwitterService service;
        private OAuthRequestToken requestToken;
        private OAuthAccessToken accessToken;
        private Uri uri;
        private String message;

        public HomePage()
        {
            InitializeComponent();
            listDocument = new List<TypeDocument>();
            listNameAtentionPoints = new List<TypeNameAtentionPoints>();
            //map_ubication.Mode = new 
            map_ubication.ZoomLevel = 9;

            this.Loaded += (s, e) =>
           {
               openBackgroundProgressBar();
               Thread.Sleep(3000);
               closeBackgroundProgressBar();

               
           };
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (webView.Visibility == Visibility.Visible || dialogTwitter.Visibility == Visibility.Visible)
            {
                webView.Visibility = Visibility.Collapsed;
                dialogTwitter.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                //cierro la aplicacion eliminando todas las paginas abiertas
                while (NavigationService.RemoveBackEntry() != null)
                {
                    NavigationService.RemoveBackEntry();
                }
            }
        }

        public void openBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Visible;
        }

        public void closeBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Collapsed;
        }

        private void button_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_info.Visibility = Visibility.Visible;
        }

        private void button_close_popup_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_info.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void loadListDocument()
        {

            TypeDocument typeDocument1 = new TypeDocument();
            typeDocument1.NameDocument = resources.@string.StringResource.citizenship_card;
            listDocument.Add(typeDocument1);

            TypeDocument typeDocument2 = new TypeDocument();
            typeDocument2.NameDocument = resources.@string.StringResource.identity_card;
            listDocument.Add(typeDocument2);

            TypeDocument typeDocument3 = new TypeDocument();
            typeDocument3.NameDocument = resources.@string.StringResource.writ_of_estranjeria;
            listDocument.Add(typeDocument3);

            TypeDocument typeDocument4 = new TypeDocument();
            typeDocument4.NameDocument = resources.@string.StringResource.nit;
            listDocument.Add(typeDocument4);

            TypeDocument typeDocument5 = new TypeDocument();
            typeDocument5.NameDocument = resources.@string.StringResource.passport;
            listDocument.Add(typeDocument5);

            TypeDocument typeDocument6 = new TypeDocument();
            typeDocument6.NameDocument = resources.@string.StringResource.diplomatic_passport;
            listDocument.Add(typeDocument6);

            TypeDocument typeDocument7 = new TypeDocument();
            typeDocument7.NameDocument = resources.@string.StringResource.civil_registration;
            listDocument.Add(typeDocument7);

            TypeDocument typeDocument8 = new TypeDocument();
            typeDocument8.NameDocument = resources.@string.StringResource.card_venezuela;
            listDocument.Add(typeDocument8);
        }

        /* verifica que boton se 
         * encuentra activo y lo 
         * desacttiva
         * */
        public void collapsedStyleAllbuttonsMenu()
        {
           switch (buttonSelect)
            {
               case 1:
                   {
                //button consultations
                icon_consultions.Source = ImageLoader.getInstance().getBitmapImage(ICON_CONSULTATION_GREEN,null);//bitmapImage;
                text_consultions.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_GREEN);
                image_shadow_right_consultions.Visibility = Visibility.Collapsed;
                line_green_consultions.Visibility = Visibility.Collapsed;
                fragment_consultations.Visibility = Visibility.Collapsed;
                arrow_consultions.Visibility = Visibility.Collapsed;
                break;
                   }

               case 2:
                   {
                       //button atention
                       icon_atention.Source = ImageLoader.getInstance().getBitmapImage(ICON_ATENTION_GREEN, null);//bitmapImage;
                       text_atention.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_GREEN);
                       image_shadow_left_atention.Visibility = Visibility.Collapsed;
                       image_shadow_rigth_atention.Visibility = Visibility.Collapsed;
                       line_green_atention.Visibility = Visibility.Collapsed;
                       fragment_point_atention.Visibility = Visibility.Collapsed;
                       arrow_atention.Visibility = Visibility.Collapsed;
                       break;
                   }

               case 3:
                   {
                       //button news
                       icon_news.Source = ImageLoader.getInstance().getBitmapImage(ICON_NEWS_GREEN, null);
                       text_news.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_GREEN);
                       image_shadow_left_news.Visibility = Visibility.Collapsed;
                       image_shadow_rigth_news.Visibility = Visibility.Collapsed;
                       line_green_news.Visibility = Visibility.Collapsed;
                       fragment_news.Visibility = Visibility.Collapsed;
                       arrow_news.Visibility = Visibility.Collapsed;
                       break;
                   }

               case 4:
                   {
                       //button share
                       icon_share.Source = ImageLoader.getInstance().getBitmapImage(ICON_SHARE_GREEN, null);
                       text_share.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_GREEN);
                       image_shadow_left_share.Visibility = Visibility.Collapsed;
                       line_green_share.Visibility = Visibility.Collapsed;
                       fragment_share.Visibility = Visibility.Collapsed;
                       arrow_share.Visibility = Visibility.Collapsed;
                       break;
                   }
            }
        }

        /*Metodos que permiten activar el boton que se pulsa*/
        public void button_consultations_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStyleAllbuttonsMenu();
            icon_consultions.Source = ImageLoader.getInstance().getBitmapImage(ICON_CONSULTATION_WHITE, null);//bitmapImage;
            text_consultions.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_right_consultions.Visibility = Visibility.Visible;
            line_green_consultions.Visibility = Visibility.Visible;
            fragment_consultations.Visibility = Visibility.Visible;
            arrow_consultions.Visibility = Visibility.Visible;
            buttonSelect = 1;
        }

        private void button_atention_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStyleAllbuttonsMenu();
            icon_atention.Source = ImageLoader.getInstance().getBitmapImage(ICON_ATENTION_WHITE, null);//bitmapImage;
            text_atention.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_rigth_atention.Visibility = Visibility.Visible;
            image_shadow_left_atention.Visibility = Visibility.Visible;
            line_green_atention.Visibility = Visibility.Visible;
            fragment_point_atention.Visibility = Visibility.Visible;
            arrow_atention.Visibility = Visibility.Visible;
            buttonSelect = 2;

            //hago el llamado
            openBackgroundProgressBar();
            ManagerData.getIntance().getAtentionPoints(NUM_DEPARTMENT_DEFECT);
            ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
            {
                closeBackgroundProgressBar();
                List<PointsAtention> listPointArtention = new List<PointsAtention>();
                if (eventResponseData.getResponseData() != null)
                {
                    listPointArtention = (List<PointsAtention>)eventResponseData.getResponseData();
                    //paso una lista con todos los puntos de atension
                    markerUbicatioPoints(listPointArtention);
                }
                else
                {
                    MessageBox.Show(resources.@string.StringResource.not_get_data);
                }
            };
            
        }

        private void DoStuff(XDocument xml)
        {
            //parse the xml result here
        }

        private void button_news_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStyleAllbuttonsMenu();
            icon_news.Source = ImageLoader.getInstance().getBitmapImage(ICON_NEWS_WHITE, null);
            text_news.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_left_news.Visibility = Visibility.Visible;
            image_shadow_rigth_news.Visibility = Visibility.Visible;
            line_green_news.Visibility = Visibility.Visible;
            fragment_news.Visibility = Visibility.Visible;
            arrow_news.Visibility = Visibility.Visible;
            buttonSelect = 3;

        }

        private void button_share_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStyleAllbuttonsMenu();
            icon_share.Source = ImageLoader.getInstance().getBitmapImage(ICON_SHARE_WHITE, null);
            text_share.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_left_share.Visibility = Visibility.Visible;
            line_green_share.Visibility = Visibility.Visible; 
            fragment_share.Visibility = Visibility.Visible;
            arrow_share.Visibility = Visibility.Visible;
            buttonSelect = 4;
        }

        /*Carga la lista de los tipos 
         * de documentos a elegir y 
         * abre el popup
         */
        private void button_select_document_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            loadListDocument(); //cargo la lista manualmente
            list_select_document.ItemsSource = listDocument;
            popup_list_select_document.IsOpen = true; //abro el popup de lista
            grid_popup_list.Visibility = Visibility.Visible;
        }

        /*toma el item seleccionado
         * y cierra el popup
         */
        private void list_selec_document_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (list_select_document.SelectedItem != null)
            {
                text_select_document.Text = ((TypeDocument)list_select_document.SelectedValue).NameDocument;
            }
            popup_list_select_document.IsOpen = false; //cierro el popup de lista
            grid_popup_list.Visibility = Visibility.Collapsed;
        }

        //marcar los puntos de atension
        private void markerUbicatioPoints(List<PointsAtention> listPointAtention)
        {
            foreach (PointsAtention pointAtention in listPointAtention)
            {
                Pushpin pushpin = new Pushpin();//marcador en el mapa
                pushpin.Style = this.Resources["PushpinStyle"] as Style;
                Location location = new Location();
                pushpin.Background = new SolidColorBrush(Colors.Red);
                location.Latitude = Convert.ToDouble(pointAtention.LATITUDE);
                location.Longitude = Convert.ToDouble(pointAtention.LONGITUDE);
                pushpin.Location = location;
                map_ubication.SetView(location, 9);
                map_ubication.Children.Add(pushpin);
            }
        }

        private void image_push_pin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image item = (Image)sender;
            
        }


        private void button_select_point(object sender, System.Windows.Input.GestureEventArgs e)
        {
            loadListAtentionPoints(); //cargo la lista manualmente
            list_select_document.ItemsSource = listNameAtentionPoints;
            popup_list_select_document.IsOpen = true; //abro el popup de lista
            grid_popup_list.Visibility = Visibility.Visible;
        }

        private void loadListAtentionPoints()
        {
            //Cargo la lista con los nombres y su id 
            TypeNameAtentionPoints name1 = new TypeNameAtentionPoints();
            name1.NAME_ATENTION_POINTS = resources.@string.StringResource.antioquia;
            listNameAtentionPoints.Add(name1);

            /*
            TypeNameAtentionPoints name2 = new TypeNameAtentionPoints();
            name2.NAME_ATENTION_POINTS = resources.@string.StringResource.atlantic;
            listNameAtentionPoints.Add(name2);
            TypeNameAtentionPoints name3 = new TypeNameAtentionPoints();
            name3.NAME_ATENTION_POINTS = resources.@string.StringResource.boyaca;
            listNameAtentionPoints.Add(name3);
            TypeNameAtentionPoints name4 = new TypeNameAtentionPoints();
            name4.NAME_ATENTION_POINTS = resources.@string.StringResource.bogota_dc;
            listNameAtentionPoints.Add(name4);
            TypeNameAtentionPoints name5 = new TypeNameAtentionPoints();
            name5.NAME_ATENTION_POINTS = resources.@string.StringResource.bolivar;
            listNameAtentionPoints.Add(name5);
            TypeNameAtentionPoints name6 = new TypeNameAtentionPoints();
            name6.NAME_ATENTION_POINTS = resources.@string.StringResource.cordoba;
            listNameAtentionPoints.Add(name6);
            TypeNameAtentionPoints name7 = new TypeNameAtentionPoints();
            name7.NAME_ATENTION_POINTS = resources.@string.StringResource.cauca;
            listNameAtentionPoints.Add(name7);
            TypeNameAtentionPoints name8 = new TypeNameAtentionPoints();
            name8.NAME_ATENTION_POINTS = resources.@string.StringResource.caldas;
            listNameAtentionPoints.Add(name8);
            TypeNameAtentionPoints name = new TypeNameAtentionPoints();
            name1.NAME_ATENTION_POINTS = resources.@string.StringResource.antioquia;
            listNameAtentionPoints.Add(name1);
             * */
        }

       
        private void button_share_facebook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //realiza el comentario en facebook y comparte el enlace
            Facebook.Client.Session.ShowFeedDialog(null, resources.@string.StringResource.url_site_simit,resources.@string.StringResource.app_name
                            ,resources.@string.StringResource.dialog_share, null, null);
            
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
            if (textTwitterImput.Text.Length > 140)
            {
                MessageBox.Show(resources.@string.StringResource.text_dialog_twitter);
            }
            else
            {
                dialogTwitter.Visibility = Visibility.Collapsed;
                //realizo la publicacion
                try
                {
                    openBackgroundProgressBar();
                    TweetPost(textTwitterImput.Text);
                }
                catch (Exception exception)
                {
                    closeBackgroundProgressBar();
                    MessageBox.Show(resources.@string.StringResource.error_post_tweet);
                }
            }
        }

        //metodos para la publicacion con twitter
        /*-------------------------------------------------------------------------------------------------------------------------------*/
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
                string[] separators = { "?oauth_token=","&oauth_verifier=" };
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
            closeBackgroundProgressBar();
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        private void button_send_mail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Body = resources.@string.StringResource.body_email;//cuerpo del mensaje a enviar
            email.Show();
        }

        private void button_page_facebook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_facebook, UriKind.RelativeOrAbsolute));
        }

        private void button_page_twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_twitter, UriKind.RelativeOrAbsolute));
        }

        private void button_page_simit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            openBackgroundProgressBar();
            webView.Visibility = Visibility.Visible;
            Browser.Navigate(new Uri(resources.@string.StringResource.url_page_simit, UriKind.RelativeOrAbsolute));
        }

        private void Browser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            closeBackgroundProgressBar();
        }

        private void button_accept_consultations_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            openBackgroundProgressBar();
            //llamado a la api
            NavigationService.Navigate(new Uri(PAGE_CONSULTATIONS, UriKind.RelativeOrAbsolute));
        }

        private void image_push_pin_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        

    }
}