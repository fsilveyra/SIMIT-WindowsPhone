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
using System.Net.NetworkInformation;
using Simit.classAux;
using Simit.data;
using Simit.entities;

namespace Simit.fragments
{
    public partial class FragmentNews : UserControl
    {
        HomePage context;//pagina de la aplicacion donde se agregara el control de usuario

        public FragmentNews(HomePage context)
        {
            InitializeComponent();
            this.context = context;
        }

        protected override void OnManipulationStarted(System.Windows.Input.ManipulationStartedEventArgs e)
        {
            base.OnManipulationStarted(e);
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                context.openBackgroundProgressBar();
                ManagerData.getIntance().getItemsNews();
                ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
                {
                    context.closeBackgroundProgressBar();
                    List<ItemNews> listItemNews = new List<ItemNews>();
                    if (eventResponseData.getResponseData() != null)
                    {
                        listItemNews = (List<ItemNews>)eventResponseData.getResponseData();

                        //paso una lista con todos los puntos de atension
                        if (listItemNews.Count > 0)
                        {
                            list_news.ItemsSource = null;
                            list_news.ItemsSource = listItemNews;
                        }
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
