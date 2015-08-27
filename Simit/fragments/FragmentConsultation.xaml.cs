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
using System.Windows.Input;

namespace Simit.fragments
{
    public partial class FragmentConsultation : UserControl
    {
        //list document prueba
        List<TypeDocument> listDocument = null;//inicializo la lista
        TypeDocument typeDocument = new TypeDocument();//para almasenar el tipo de documento elegido
        HomePage context;
        List<Subpoena> listSubpoena;
        FragmentDesciptionConsultation fragmentDescriptionConsultation;

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
            context.openBackground();
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
                //cambio el tipo de teclado segun la opcion elegida, 
                //por defecto siempre es numerico
                //solo para le pasaporte el alfanumerico
                InputScope scope = new InputScope();
                InputScopeName name = new InputScopeName();
                if (text_select_document.Text.ToString().Equals(resources.@string.StringResource.passport))
                    name.NameValue = InputScopeNameValue.AlphanumericFullWidth;
                else
                    name.NameValue = InputScopeNameValue.Number;
                scope.Names.Add(name);
                text_imput_document.InputScope = scope;
            }
            popup_list_select_document.IsOpen = false; //cierro el popup de lista
            grid_popup_list.Visibility = Visibility.Collapsed;
            context.closeBackground();
        }

        private void button_accept_consultations_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!text_imput_document.Text.Equals(String.Empty) && text_imput_document.Text.Length >= 4)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    fragmentDescriptionConsultation = new FragmentDesciptionConsultation(context);
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

        public void backPress(System.ComponentModel.CancelEventArgs e)
        {
            if (grid_popup_list.Visibility == Visibility.Visible)
            {
                grid_popup_list.Visibility = Visibility.Collapsed;
                popup_list_select_document.IsOpen = false;
                context.closeBackground();
                e.Cancel = true;
            }
            else
            if (context.fragment_info_consultation.Visibility == Visibility.Visible)
            {
                
                if (fragmentDescriptionConsultation != null)
                {
                    fragmentDescriptionConsultation.backPress(e);
                }

            }
            else
            {
                //sale de la aplicacion
                context.backTrue(e);
            }
        }

        private void popup_list_select_document_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            grid_popup_list.Visibility = Visibility.Collapsed;
            popup_list_select_document.IsOpen = false; 
        }

        private void text_imput_document_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Unknown)//evita que se escriba el punto Key.Unknown representa la tecla punto
                e.Handled = true;
        }
    }
}
