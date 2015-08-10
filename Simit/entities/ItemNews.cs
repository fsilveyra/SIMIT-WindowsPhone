using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Simit.entities
{
    public class ItemNews
    {
        
        private String _title;
        private String _url_image_video;
        private String _id_video;

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

        public String URL_IMAGE_VIDEO
        {
            get
            {
                return _url_image_video;
            }

            set
            {
                if (value != null)
                    _url_image_video = value;
            }
        }

        public String ID_VIDEO
        {
            get
            {
                return _id_video;
            }
            set
            {
                if (value != null)
                    _id_video = value;
            }
        }
    }
}
