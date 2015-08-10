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
using Simit.data;
using Simit.classAux;
using Simit.entities;
using System.Net.NetworkInformation;
namespace Simit.fragments
{
    public partial class FragmentDesciptionConsultation : UserControl
    {
        HomePage context;
        List<Subpoena> listSubpoena;
        public FragmentDesciptionConsultation(HomePage context)
        {
            InitializeComponent();
            this.context = context;
            listSubpoena = new List<Subpoena>();
        }

        public void loadPage(String document,TypeDocument typeDocument)
        {
            context.openBackgroundProgressBar();
            //hago los llamados
            ManagerData.getIntance().getSubpoena(document,typeDocument.ID);
            ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
            {
                context.closeBackgroundProgressBar();
                listSubpoena = new List<Subpoena>();
                if (eventResponseData.getResponseData() != null)
                {
                    
                     listSubpoena = (List<Subpoena>)eventResponseData.getResponseData();
                     //paso una lista con todos los puntos de atension
                     //fragment_info_consultation.Visibility = Visibility.Visible;
                     text_title_page_consultations.Text = typeDocument.NameDocument + ": " + document;
                     if (listSubpoena.Count > 0)
                         text_value_count_subpoenas.Text = listSubpoena.Count.ToString();
                     //hago el siguiente llamado, para las resoluciones
                     getResolutions(document, typeDocument.ID);
                     
                }
                else
                {
                    Dialog dialog = new Dialog();
                    dialog.setDialog(resources.@string.StringResource.MENSAGE_ERROR_LOAD_DATA);
                    dialog.showDialog();
                }
            };
        }

        private void button_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.popup_info.Visibility = Visibility.Visible;
        }

        private void button_close_popup_info_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            context.popup_info.Visibility = Visibility.Collapsed;
        }

        private void button_subpoenas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (listSubpoena != null && listSubpoena.Count > 0)
            {
                FragmentDetailConsultation fragmentDetailConsultation = new FragmentDetailConsultation(context);
                context.fragment_detail_consultation.Children.Add(fragmentDetailConsultation);
                fragmentDetailConsultation.loadPageSubpoena(listSubpoena);
                context.fragment_detail_consultation.Visibility = Visibility.Visible;
            }
        }

        private void button_resolutions_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void button_payment_arrangements_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        /************ fragment de consultas*********************/
        public void getResolutions(String document, String typeDocument)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                context.openBackgroundProgressBar();
                ManagerData.getIntance().getResolutions(document, typeDocument);
                ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
                {
                    context.closeBackgroundProgressBar();
                    List<Resolution> listResolution = new List<Resolution>();
                    if (eventResponseData.getResponseData() != null)
                    {
                        listResolution = (List<Resolution>)eventResponseData.getResponseData();
                        //paso una lista con todos los puntos de atension
                        if(listResolution.Count > 0)
                         text_value_count_resolutions.Text = listResolution.Count.ToString();
                        //hago el siguiente llamado, para los acuerdos de pago
                        //getPaymentArrangements(document, typeDocument);
                    }
                    else
                    {
                        Dialog dialog = new Dialog();
                        dialog.setDialog(resources.@string.StringResource.MENSAGE_ERROR_LOAD_DATA);
                        dialog.showDialog();
                    }
                };
            }
            else
            {
                Dialog dialog = new Dialog();
                dialog.setDialog(resources.@string.StringResource.MENSAGE_NOT_CONECTION_INTERNET);
                dialog.showDialog();
            }
        }

        public void getPaymentArrangements(String document, String typeDocument)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                context.openBackgroundProgressBar();
                ManagerData.getIntance().getPaymentArrangements(document, typeDocument);
                ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
                {
                    context.closeBackgroundProgressBar();
                    List<PaymentsArrangement> listPayment = new List<PaymentsArrangement>();
                    if (eventResponseData.getResponseData() != null)
                    {
                        listPayment = (List<PaymentsArrangement>)eventResponseData.getResponseData();
                        //paso una lista con todos los puntos de atension
                        if(listPayment.Count > 0)
                            text_value_count_resolutions.Text = listPayment.Count.ToString();
                        //se generaron las llamadas correctamente
                    }
                    else
                    {
                        Dialog dialog = new Dialog();
                        dialog.setDialog(resources.@string.StringResource.MENSAGE_ERROR_LOAD_DATA);
                        dialog.showDialog();
                    }
                };
            }
            else
            {
                Dialog dialog = new Dialog();
                dialog.setDialog(resources.@string.StringResource.MENSAGE_NOT_CONECTION_INTERNET);
                dialog.showDialog();
            }
        }
    }
}
