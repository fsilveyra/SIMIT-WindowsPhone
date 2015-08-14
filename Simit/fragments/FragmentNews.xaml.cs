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
using Microsoft.Phone.Tasks;

namespace Simit.fragments
{
    public partial class FragmentNews : UserControl
    {
        HomePage context;//pagina de la aplicacion donde se agregara el control de usuario
        private static String URL_VIDEO = "https://www.youtube.com/watch?v=";

        public FragmentNews(HomePage context)
        {
            InitializeComponent();
            this.context = context;
            loadPage();
        }

        private void loadPage()
        {
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
                            //cargo una lista con los datos necesarios para el listBox
                            //ya que no admite tipos anidados
                            List<ItemListNews> listItemListNews = new List<ItemListNews>();
                            foreach (ItemNews item in listItemNews)
                            {
                                ItemListNews itemListNews = new ItemListNews();
                                itemListNews.TITLE = item.SNIPPET.TITLE;
                                itemListNews.URL_IMAGE = item.SNIPPET.THUMBNAILS.HIGH.URL;
                                itemListNews.ID_VIDEO = item.VIDEO_ID.VIDEO_ID;
                                listItemListNews.Add(itemListNews);
                            }
                            list_news.ItemsSource = null;
                            list_news.ItemsSource = listItemListNews;
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

        private void list_news_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (list_news.SelectedItem != null)
            {
                ItemListNews itemselected = new ItemListNews();
                itemselected = (ItemListNews)list_news.SelectedItem;
                //hago visible el web view para mostrar el video
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    webBrowserTask.Uri = new Uri(URL_VIDEO + itemselected.ID_VIDEO);
                    webBrowserTask.Show(); 
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
}
