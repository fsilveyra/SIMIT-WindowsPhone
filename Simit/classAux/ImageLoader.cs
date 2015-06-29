using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Simit.classAux
{
    public class ImageLoader
    {
       
        private String urlImage = null;
        private BitmapImage bmp = null;
        private static ImageLoader INSTANCE = null;

        private  ImageLoader()
        {
        }

        public static ImageLoader getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ImageLoader();
            return INSTANCE;
        }

        /// <summary>
        /// Permite obtener un bitMapImage a partir de una url que puede ser web o local
        /// en caso de que la url sea nula o vacia, devuelve una imagen por defecto que 
        /// debe setearse.
        /// </summary>
        /// <param name="urlImage"></param>
        /// <param name="urlImageDefect"></param>
        /// <returns></returns>
        public BitmapImage getBitmapImage(String urlImage, String urlImageDefect)
        {
            if (urlImage != null && !urlImage.Equals(""))
            {
                this.urlImage = urlImage;
                bmp = new BitmapImage(new Uri(this.urlImage, UriKind.RelativeOrAbsolute));
            }
            else
            {
                //cargo la imagen por defecto
                bmp = new BitmapImage(new Uri(urlImageDefect, UriKind.RelativeOrAbsolute));
            }

            return bmp;
        }

    }
}
