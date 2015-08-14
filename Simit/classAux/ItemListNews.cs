using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.classAux
{
    public class ItemListNews
    {
        private String _title;
        private String _urlImage;
        private String _idVideo;

        public String TITLE
        {
            get
            {
                return _title;
            }

            set
            {
                if (value != null)
                    _title = value;
            }
        }

        public String URL_IMAGE
        {
            get
            {
                return _urlImage;
            }

            set
            {
                if (value != null)
                    _urlImage = value;
            }
        }

        public String ID_VIDEO
        {
            get
            {
                return _idVideo;
            }

            set
            {
                if (value != null)
                    _idVideo = value;
            }
        }
    }
}
