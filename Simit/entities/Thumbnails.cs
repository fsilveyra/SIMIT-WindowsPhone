using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Simit.entities
{
    [DataContract]
    public class Thumbnails
    {
        private High _high;

        [DataMember(Name="high")]
        public High HIGH
        {
            get
            {
                return _high;
            }

            set
            {
                if (value != null)
                    _high = value;
            }
        }
    }
}
