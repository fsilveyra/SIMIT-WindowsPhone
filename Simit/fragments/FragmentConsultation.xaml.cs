using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Simit.entities;
using System.Net.NetworkInformation;
using Simit.page;
using Simit.data;
using Simit.classAux;

namespace Simit.fragments
{
    public partial class FragmentConsultation : UserControl
    {
        //list document prueba
        List<TypeDocument> listDocument = null;//inicializo la lista
        TypeDocument typeDocument = new TypeDocument();//para almasenar el tipo de documento elegido
        HomePage context;
        List<Subpoena> listSubpoena;

        public FragmentConsultation(HomePage context)
        {
            InitializeComponent();
            listDocument = new List<TypeDocument>();
            typeDocument.ID = "1";
            typeDocument.NameDocument = resources.@string.StringResource.citizenship_card;//nombre por defecto
            this.context = context;
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
            //fragment_info_consultation.Visibility = Visibility.Collapsed;
        }

        public void loadListDocument()
        {
            listDocument = ListTypedocument.getInstance().getListTypeDocument();
        }

        /*toma el item seleccionado
         * y cierra el popup
         */
        private void list_selec_document_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (list_select_document.SelectedItem != null)
            {
                text_select_document.Text = ((TypeDocument)list_select_document.SelectedValue).NameDocument;
                typeDocument = (TypeDocument)list_select_document.SelectedValue;
            }
            popup_list_select_document.IsOpen = false; //cierro el popup de lista
            grid_popup_list.Visibility = Visibility.Collapsed;
        }

        private void button_accept_consultations_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!text_imput_document.Text.Equals(String.Empty) && text_imput_document.Text.Length >= 4)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    FragmentDesciptionConsultation fragmentDescriptionConsultation = new FragmentDesciptionConsultation(context);
                    context.fragment_info_consultation.Children.Add(fragmentDescriptionConsultation);
                    fragmentDescriptionConsultation.loadPage(text_imput_document.Text.ToString(),typeDocument);//cargo la pagina
                    context.fragment_info_consultation.Visibility = Visibility.Visible;
                }
                else
                {
                    Dialog dialog = new Dialog();
                    dialog.setDialog(resources.@string.StringResource.MENSAGE_NOT_CONECTION_INTERNET);
                    dialog.showDialog();
                }
            }
            else
            {
                Dialog dialog = new Dialog();
                dialog.setDialog(resources.@string.StringResource.MESSAGE_NOT_IMPUT_DATA);
                dialog.showDialog();
            }
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
