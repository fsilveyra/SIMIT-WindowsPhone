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
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Controls.Maps.Platform;
using System.Windows.Media;
using Simit.data;
using Simit.page;
using System.Net.NetworkInformation;
using Simit.classAux;

namespace Simit.fragments
{
    public partial class FragmentAtentionPoint : UserControl
    {
        private HomePage context;//contexto donde se va a montar el fragment
        private static String NUM_DEPARTMENT_DEFECT = "11";

        public FragmentAtentionPoint(HomePage context)
        {
            InitializeComponent();
            map_ubication.ZoomLevel = 9;
            this.context = context;

            //hago el llamado cuando se visualiza el fragment con la ubicacion por defecto
            context.openBackgroundProgressBar();
            ManagerData.getIntance().getAtentionPoints(NUM_DEPARTMENT_DEFECT);
            ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
            {
                context.closeBackgroundProgressBar();
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

        //marcar los puntos de atension
        private void markerUbicatioPoints(List<PointsAtention> listPointAtention)
        {
            //elimino los puntos anteriores si es que hay
            if (map_ubication.Children.Count > 0)
                /*
                for (int i = 0; i < map_ubication.Children.Count - 1; i++)
                  */
                map_ubication.Children.Clear();
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
            list_select_atention_point.ItemsSource = ListNameAtentionPoints.getInstance().getListNameAtentionPoints();
            grid_popup_list_atention_point.Visibility = Visibility.Visible;
            popup_list_select_atention_point.IsOpen = true;
        }

        private void list_select_atention_point_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (list_select_atention_point.SelectedItem != null)
            {
                NameAtentionPoints atentionPoint = (NameAtentionPoints)list_select_atention_point.SelectedItem;
                //cambio el texto del selector y hago el llamado
                text_select_point.Text = atentionPoint.NAME_ATENTION_POINTS;
                grid_popup_list_atention_point.Visibility = Visibility.Collapsed;
                popup_list_select_atention_point.IsOpen = false;
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    context.openBackgroundProgressBar();
                    ManagerData.getIntance().getAtentionPoints(atentionPoint.ID);
                    ManagerData.getIntance().getDataCompleted += (s, eventResponseData) =>
                    {
                        context.closeBackgroundProgressBar();
                        List<PointsAtention> listPointArtention = new List<PointsAtention>();
                        if (eventResponseData.getResponseData() != null)
                        {
                            List<PointsAtention> listPoint = (List<PointsAtention>)eventResponseData.getResponseData();
                            //paso una lista con todos los puntos de atension
                            markerUbicatioPoints(listPoint);
                        }
                        else
                        {
                            MessageBox.Show(resources.@string.StringResource.not_get_data);
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
