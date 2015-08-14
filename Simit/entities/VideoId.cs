using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    [DataContract]
    public class VideoId
    {
        private String _videoId;

        [DataMember(Name="videoId")]
        public String VIDEO_ID
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
    }
}
