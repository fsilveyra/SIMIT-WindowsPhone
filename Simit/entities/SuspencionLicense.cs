using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class SuspencionLicense
    {
        private String _message;

        public String MESSAGE
        {
            get
            {
                return _message;
            }

            set
            {
                if (value != null)
                    _message = value;
            }
        }
    }
}
