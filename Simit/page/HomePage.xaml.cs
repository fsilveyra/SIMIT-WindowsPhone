﻿using System;
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

        //list document prueba
        List<TypeDocument> listDocument = null;//inicializo la lista
        
        private int buttonSelect = 1; //identifica el boton activo

        public HomePage()
        {
            InitializeComponent();
            listDocument = new List<TypeDocument>();
            this.Loaded += (s, e) =>
           {
               Thread.Sleep(3000);
               closeBackgroundProgressBar();
           };
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            //cierro la aplicacion eliminando todas las paginas abiertas
            while (NavigationService.RemoveBackEntry() != null)
            {
                NavigationService.RemoveBackEntry();
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
            popup_info.IsOpen = true;
        }

        private void button_close_popup_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_info.IsOpen = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void loadListDocument()
        {

            TypeDocument typeDocument1 = new TypeDocument();
            typeDocument1.NameDocument = "CÉDULA DE CIUDADANÍA";
            listDocument.Add(typeDocument1);

            TypeDocument typeDocument2 = new TypeDocument();
            typeDocument2.NameDocument = "TARJETA DE IDENTIDAD";
            listDocument.Add(typeDocument2);

            TypeDocument typeDocument3 = new TypeDocument();
            typeDocument3.NameDocument = "CÉDULA DE EXTRANJERÍA";
            listDocument.Add(typeDocument3);

            TypeDocument typeDocument4 = new TypeDocument();
            typeDocument4.NameDocument = "NIT";
            listDocument.Add(typeDocument4);

            TypeDocument typeDocument5 = new TypeDocument();
            typeDocument5.NameDocument = "PASAPORTE";
            listDocument.Add(typeDocument5);

            TypeDocument typeDocument6 = new TypeDocument();
            typeDocument6.NameDocument = "CARNET DIPLOMATÍCO";
            listDocument.Add(typeDocument6);

            TypeDocument typeDocument7 = new TypeDocument();
            typeDocument7.NameDocument = "REGISTRO CIVIL";
            listDocument.Add(typeDocument7);

            TypeDocument typeDocument8 = new TypeDocument();
            typeDocument8.NameDocument = "CÉDULA VENEZOLANA";
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
        }

        
    }
}