using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Simit.entities
{
    [DataContract]
    public class ItemNews
    {
        
        private VideoId _videoId;
        private Snippet _snippet;

        [DataMember(Name="id")]
        public VideoId VIDEO_ID
        {
            get
            {
                return _videoId;
            }

            set
            {
                if (value != null)
                    _videoId = value;
            }

        }

        [DataMember(Name="snippet")]
        public Snippet SNIPPET
        {
            get
            {
                return _snippet;
            }

            set
            {
                if (value != null)
                    _snippet = value;
            }
        }

    }
}
