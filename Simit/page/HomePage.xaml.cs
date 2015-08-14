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
using System.Net.NetworkInformation;
using Simit.fragments;

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

        //para las lista de los detalles
        private int buttonSelect = 1; //identifica el boton activo

        //page
        private static String PAGE_CONSULTATIONS = "/page/PageConsultations.xaml";
        
        //fragments
        FragmentConsultation fragmentConsultation;
        FragmentAtentionPoint fragmentAtentionPoint;
        FragmentNews fragmentNews;
        FragmentShare fragmentShare;
        

        public HomePage()
        {
            InitializeComponent();
            //agrego el fragment por defecto de consultas
            fragmentConsultation = new FragmentConsultation(this);
            fragment_consultations.Children.Add(fragmentConsultation);
            fragment_consultations.Visibility = Visibility.Visible;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (popup_info.Visibility == Visibility.Visible)
            {
                popup_info.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            else
            {
                switch (buttonSelect)
                {
                    case 1:
                        {
                            checkCase1(e);
                            break;
                        }
                    case 2:
                        {
                            checkCase3(e);
                            break;
                        }
                    case 3:
                        {
                            backTrue(e);
                            break;
                        }
                    case 4:
                        {
                            checkCase4(e);
                            break;
                        }

                }
            }
            /*
            if (webView.Visibility == Visibility.Visible || dialogTwitter.Visibility == Visibility.Visible)
            {
                webView.Visibility = Visibility.Collapsed;
                dialogTwitter.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            else if (fragment_info_consultation.Visibility == Visibility.Visible)
            {
                fragment_info_consultation.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            else if (fragment_detail_consultation.Visibility == Visibility.Visible)
            {
                fragment_detail_consultation.Visibility = Visibility.Collapsed;
                fragment_info_consultation.Visibility = Visibility.Visible;
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
             */
        }

        private void checkCase1(System.ComponentModel.CancelEventArgs e)
        {
            if (fragmentConsultation != null)
                fragmentConsultation.backPress(e);
        }

        /*---------------------------------------------------------------------------------*/
        //manejo del boton atras en los fragments
        private void checkCase4(System.ComponentModel.CancelEventArgs e)
        {
            if(fragmentShare != null)
                fragmentShare.onBackPress(e);
        }

        public void checkCase3(System.ComponentModel.CancelEventArgs e)
        {
            if (fragmentAtentionPoint != null)
            {
                fragmentAtentionPoint.backPress(e);
            }
            
        }

        public void backTrue(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            //cierro la aplicacion eliminando todas las paginas abiertas
            while (NavigationService.RemoveBackEntry() != null)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        /*--------------------------------------------------------------------------------*/
        public void openBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Visible;
        }

        public void closeBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Collapsed;
        }

        public void openBackground()
        {
            background_progress_bar.Visibility = Visibility.Visible;
            progress.Visibility = Visibility.Collapsed;
        }

        public void closeBackground()
        {
            background_progress_bar.Visibility = Visibility.Collapsed;
            progress.Visibility = Visibility.Visible;
        }

        private void button_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_info.Visibility = Visibility.Visible;
             
        }

        private void button_close_popup_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_info.Visibility = Visibility.Collapsed;
        }
       
        /* verifica que boton se 
         * encuentra activo y lo 
         * desacttiva
         * */
        public void collapsedStylebuttonsMenu()
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
                //oculto el resto de los fragment en caso de que esten visibles
                fragment_info_consultation.Visibility = Visibility.Collapsed;
                fragment_detail_consultation.Visibility = Visibility.Collapsed;
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
            collapsedStylebuttonsMenu();
            icon_consultions.Source = ImageLoader.getInstance().getBitmapImage(ICON_CONSULTATION_WHITE, null);//bitmapImage;
            text_consultions.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_right_consultions.Visibility = Visibility.Visible;
            line_green_consultions.Visibility = Visibility.Visible;
            arrow_consultions.Visibility = Visibility.Visible;
            buttonSelect = 1;
            //agrego el fragment si no es nulo
            if (fragmentConsultation == null)
            {
                fragmentConsultation = new FragmentConsultation(this);
                fragment_consultations.Children.Add(fragmentConsultation);
            }
            fragment_consultations.Visibility = Visibility.Visible;
        }

        private void button_atention_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStylebuttonsMenu();
            icon_atention.Source = ImageLoader.getInstance().getBitmapImage(ICON_ATENTION_WHITE, null);//bitmapImage;
            text_atention.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_rigth_atention.Visibility = Visibility.Visible;
            image_shadow_left_atention.Visibility = Visibility.Visible;
            line_green_atention.Visibility = Visibility.Visible;
            fragment_point_atention.Visibility = Visibility.Visible;
            arrow_atention.Visibility = Visibility.Visible;
            buttonSelect = 2;
            //agrego el fragment si no es nulo
            if (fragmentAtentionPoint == null)
            {
                fragmentAtentionPoint = new FragmentAtentionPoint(this);
                fragment_point_atention.Children.Add(fragmentAtentionPoint);
            }
            fragment_point_atention.Visibility = Visibility.Visible;
           // fragment_info_consultation.Visibility = Visibility.Collapsed;
        }

        private void button_news_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStylebuttonsMenu();
            icon_news.Source = ImageLoader.getInstance().getBitmapImage(ICON_NEWS_WHITE, null);
            text_news.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_left_news.Visibility = Visibility.Visible;
            image_shadow_rigth_news.Visibility = Visibility.Visible;
            line_green_news.Visibility = Visibility.Visible;
            fragment_news.Visibility = Visibility.Visible;
            arrow_news.Visibility = Visibility.Visible;
            buttonSelect = 3;
            //agrego el fragment
            if (fragmentNews == null)
            {
                fragmentNews = new FragmentNews(this);
                fragment_news.Children.Add(fragmentNews);
            }
            fragment_news.Visibility = Visibility.Visible;
            //fragment_info_consultation.Visibility = Visibility.Collapsed;

        }

        private void button_share_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            collapsedStylebuttonsMenu();
            icon_share.Source = ImageLoader.getInstance().getBitmapImage(ICON_SHARE_WHITE, null);
            text_share.Foreground = ManagerData.getIntance().GetColorFromHexa(COLOR_WHITE);
            image_shadow_left_share.Visibility = Visibility.Visible;
            line_green_share.Visibility = Visibility.Visible; 
            fragment_share.Visibility = Visibility.Visible;
            arrow_share.Visibility = Visibility.Visible;
            buttonSelect = 4;
            //agrego el fragment
            if (fragmentShare == null)
            {
                fragmentShare = new FragmentShare(this);
                fragment_share.Children.Add(fragmentShare);
            }
            fragment_share.Visibility = Visibility.Visible;
        }

        

       

       
    }
}