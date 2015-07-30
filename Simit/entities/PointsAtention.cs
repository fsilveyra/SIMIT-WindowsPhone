using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    class PointsAtention
    {
        private string _cell;
        private string _address;
        private string _time;
        private string _latitude;
        private string _longitude;
        private string _municipalities;

        public string CELL
        {
            get
            {
                return _cell;
            }

            set
            {
                if (value != null)
                    _cell = value;
            }
        }

        public string ADDRESS
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != null)
                    _address = value;
            }
        }

        public string TIME
        {
            get
            {
                return _time;
            }

            set
            {
                if (value != null)
                    _time = value;
            }
        }

        public string LATITUDE
        {
            get
            {
                return _latitude;
            }

            set
            {
                if (value != null)
                    _latitude = value;
            }
        }

        public string LONGITUDE
        {
            get
            {
                return _longitude;
            }

            set
            {
                if (value != null)
                    _longitude = value;
            }
        }

        public string MUNISIPALITIES
        {
            get
            {
                return _municipalities;
            }

            set
            {
                if (value != null)
                    _municipalities = value;
            }
        }
    }
}
