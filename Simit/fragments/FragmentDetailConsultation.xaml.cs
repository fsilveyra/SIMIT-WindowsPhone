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
namespace Simit.fragments
{
    public partial class FragmentDetailConsultation : UserControl
    {
        HomePage context;
        public FragmentDetailConsultation(HomePage context)
        {
            InitializeComponent();
            this.context = context;
        }

        public void loadPageSubpoena(List<Subpoena> liStsubpoena)
        {
            list_detail.ItemsSource = null;
            if (liStsubpoena != null)
                list_detail.ItemsSource = liStsubpoena;
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
            fragment_detail_consultation.Visibility = Visibility.Collapsed;
            e.Cancel = true;
        }
    }
}
