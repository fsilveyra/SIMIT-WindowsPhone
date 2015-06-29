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

namespace Simit.page
{
    public partial class SplashScreen : PhoneApplicationPage
    {
        private static String URL_HOME_PAGE = "/page/HomePage.xaml";
        public SplashScreen()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                Thread.Sleep(2000);//aca se realiza el llamado y se pasan los datos paraa la siguiente pantalla
                NavigationService.Navigate(new Uri(URL_HOME_PAGE, UriKind.RelativeOrAbsolute));
            };
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            
        }

        public void openBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Visible;
        }

        public void closeBackgroundProgressBar()
        {
            background_progress_bar.Visibility = Visibility.Collapsed;
        }
    }
}