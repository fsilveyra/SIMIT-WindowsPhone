using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    class TypeNameAtentionPoints
    {
        private String _nameAtentionPoints;

        private int _id;

        public String NAME_ATENTION_POINTS
        {
            get
            {
                return _nameAtentionPoints;
            }

            set
            {
                if (value != null)
                    _nameAtentionPoints = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}
