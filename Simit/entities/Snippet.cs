using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Simit.entities
{
    [DataContract]
    public class Snippet
    {
        private String _title;
        private Thumbnails _thumbnails;
 
        [DataMember(Name="title")]
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

        [DataMember(Name="thumbnails")]
        public Thumbnails THUMBNAILS
        {
            get
            {
                return _thumbnails;
            }
            set
            {
                if (value != null)
                    _thumbnails = value;
            }
        }
    }
}
