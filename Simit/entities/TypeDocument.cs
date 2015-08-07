using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class TypeDocument
    {
        private String _nameDocument;

        private String _id;

        public String NameDocument
        {
            get
            {
                return _nameDocument;
            }

            set
            {
                if (value != null)
                {
                    _nameDocument = value;
                }
            }
        }

        public String ID
        {
            get
            {
                return _id;
            }

            set
            {
                if (value != null)
                    _id = value;
            }
        }
    }
}
