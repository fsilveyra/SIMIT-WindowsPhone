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
using Simit.entities;
using Microsoft.Phone.Info;
using System.Globalization;
using System.Threading;
namespace Simit.fragments
{
    public partial class FragmentDetailConsultation : UserControl
    {
        HomePage context;
        Size resolution;
        public FragmentDetailConsultation(HomePage context)
        {
            InitializeComponent();
            this.context = context;
            /*
            double whith;
            double height;
            resolution = (Size)DeviceExtendedProperties.GetValue("PhysicalScreenResolution");
            whith = resolution.Width;
            height = resolution.Height;
            if (resolution.Width > resolution.Height)
            {
                resolution.Width = height;
                resolution.Height = whith;
            }
             * */
        }

        public void loadPageSubpoena(List<Subpoena> liStSubpoena,String titlePage)
        {
            text_title_page_detail_consultations.Text = titlePage;
            foreach (Subpoena element in liStSubpoena)
            {
                element.SIZE = resolution.Width;
                //String.Format("{0.00}", element.TOTAL);
                element.TOTAL_WITH_FORMAT = String.Format("{0:$#,##0.00;($#,##0.00);Zero}",
                                Convert.ToDecimal(element.TOTAL)/10);
                element.NUM_VISUALIZE = element.NUM;
            }
            text_title_type_list.Text = resources.@string.StringResource.subpoenas.ToUpper();
            list_detail.ItemsSource = null;
            if (liStSubpoena != null)
                list_detail.ItemsSource = liStSubpoena;
        }

        public void loadPageResolution(List<Resolution> listResolution,String titlePage)
        {
            text_title_type_list.Text = resources.@string.StringResource.resolutions.ToUpper();
            text_title_page_detail_consultations.Text = titlePage;
            foreach (Resolution element in listResolution)
            {
                element.SIZE = resolution.Width;
                element.TOTAL_WITH_FORMAT = String.Format("{0:$#,##0.00;($#,##0.00);Zero}",
                                Convert.ToDecimal(element.TOTAL) / 10);
                element.NUM_VISUALIZE = element.RESOLUCIONES;
            }
            list_detail.ItemsSource = null;
            if (listResolution != null)
                list_detail.ItemsSource = listResolution;
        }

        public void loadPagePaymentArrangements(List<PaymentsArrangement> listPaimentsArraments,String titlePage)
        {
            text_title_type_list.Text = resources.@string.StringResource.payment_arrangements.ToUpper();
            text_title_page_detail_consultations.Text = titlePage;
            foreach (PaymentsArrangement element in listPaimentsArraments)
            {
                element.SIZE = resolution.Width;
                element.TOTAL_WITH_FORMAT = String.Format("{0:$#,##0.00;($#,##0.00);Zero}",
                                Convert.ToDecimal(element.TOTAL) / 10);
                element.NUM_VISUALIZE = element.RESOLUCIONES;
            }
            list_detail.ItemsSource = null;
            if (listPaimentsArraments != null)
                list_detail.ItemsSource = listPaimentsArraments;
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
            //modificar esto cuando agregue el ultimo fragment que contiene el popup
            if (pop_up_detail.Visibility == Visibility.Visible)
            {
                pop_up_detail.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            else
            {
                context.fragment_detail_consultation.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
        }

        public void openPopupDetailItemSubpoena(Subpoena item)
        {
            //seteo el popup
            title_pop_up.Text = resources.@string.StringResource.text_num_subpoena;
            text_num.Text = item.NUM;

            text_title_state.Text = resources.@string.StringResource.text_state_subpoena;
            text_value_state.Text = item.STATE;

            text_title_date.Text = resources.@string.StringResource.text_date_subpoena;
            text_value_date.Text = item.DATE;

            text_title_infractor.Text = resources.@string.StringResource.text_infractor_sunpoena;
            text_value_infractor.Text = item.OFFENDER;

            text_title_secretaries.Text = resources.@string.StringResource.text_secretaries_subpoena;
            text_value_secretaries.Text = item.SECRETARY;

            text_title_total.Text = resources.@string.StringResource.text_total_payment;
            text_value_total.Text = item.TOTAL_WITH_FORMAT;

            grid_num.Visibility = Visibility.Collapsed;
            pop_up_detail.Visibility = Visibility.Visible;
        }

        public void openPopupDetailItemResolution(Resolution item)
        {
            //seteo el popup
            title_pop_up.Text = resources.@string.StringResource.text_num_resolution;
            text_num.Text = item.RESOLUCIONES.ToString();

            text_title_state.Text = resources.@string.StringResource.text_state_resolution;
            text_value_state.Text = item.ESTADOS_RESOLUCIONES;

            text_title_date.Text = resources.@string.StringResource.text_date_resolution;
            text_value_date.Text = item.FECHA_RESOLUCION;

            text_title_num.Text = resources.@string.StringResource.text_num_subpoena;
            text_value_num.Text = item.NUM;

            text_title_infractor.Text = resources.@string.StringResource.text_infractor_sunpoena;
            text_value_infractor.Text = item.NOMBRES_INFRACTORES;

            text_title_secretaries.Text = resources.@string.StringResource.text_secretaries_arragment;
            text_value_secretaries.Text = item.SECRETARIAS;

            text_title_total.Text = resources.@string.StringResource.text_total_payment;
            text_value_total.Text = item.TOTAL_WITH_FORMAT;

            grid_num.Visibility = Visibility.Visible;
            pop_up_detail.Visibility = Visibility.Visible;
        }

        public void openPopupdetailItemPaymentArragment(PaymentsArrangement item)
        {
            //seteo el popup
            title_pop_up.Text = resources.@string.StringResource.text_num_resolution;
            text_num.Text = item.RESOLUCIONES.ToString();

            text_title_state.Text = resources.@string.StringResource.text_state_resolution;
            text_value_state.Text = item.ESTADOS_RESOLUCIONES;

            text_title_date.Text = resources.@string.StringResource.text_date_resolution;
            text_value_date.Text = item.FECHA_RESOLUCION;

            text_title_num.Text = resources.@string.StringResource.text_num_subpoena;
            text_value_num.Text = item.NUM;

            text_title_infractor.Text = resources.@string.StringResource.text_infractor_sunpoena;
            text_value_infractor.Text = item.NOMBRES_INFRACTORES;

            text_title_secretaries.Text = resources.@string.StringResource.text_secretaries_arragment;
            text_value_secretaries.Text = item.SECRETARIAS;

            text_title_total.Text = resources.@string.StringResource.text_total_payment;
            text_value_total.Text = item.TOTAL_WITH_FORMAT;

            grid_num.Visibility = Visibility.Visible;
            pop_up_detail.Visibility = Visibility.Visible;
        }

        private void list_detail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (list_detail.SelectedItem != null)
            {
                if (list_detail.SelectedItem.GetType() == typeof(Subpoena))
                {
                    Subpoena item = new Subpoena();
                    item = (Subpoena)list_detail.SelectedItem;
                    openPopupDetailItemSubpoena(item);
                }
                else if(list_detail.SelectedItem.GetType() == typeof(Resolution))
                {
                    Resolution item = new Resolution();
                    item = (Resolution)list_detail.SelectedItem;
                    openPopupDetailItemResolution(item);
                }else
                {
                    PaymentsArrangement item = new PaymentsArrangement();
                    item = (PaymentsArrangement)list_detail.SelectedItem;
                    openPopupdetailItemPaymentArragment(item);
                }
            }
        }

    }
}
