using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Simit.entities
{
    [DataContract]
    public class High
    {
        private String _url;

        [DataMember(Name="url")]
        public String URL
        {
            get
            {
                return _url;
            }

            set
            {
                if (value != null)
                    _url = value;
            }
        }
    }
}
