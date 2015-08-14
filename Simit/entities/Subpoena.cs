using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class Subpoena
    {

        private String _state;
        private String _date;
        private String _num;
        private String _offender;
        private String _secretary;
        private String _totalToPay;
        private Double _size;
        private String _totalWithFormat;
        private String _numVisualize;


        public String STATE
        {
            get
            {
                return _state;
            }

            set
            {
                if (value != null)
                    _state = value;
            }
        }

        public String DATE
        {
            get
            {
                return _date;
            }

            set
            {
                if (value != null)
                    _date = value;
            }
        }

        public String NUM
        {
            get
            {
                return _num;
            }

            set
            {
                if (value != null)
                    _num = value;
            }
        }

        public String OFFENDER
        {
            get
            {
                return _offender;
            }

            set
            {
                if (value != null)
                    _offender = value;
            }
        }

        public String SECRETARY
        {
            get
            {
                return _secretary;
            }

            set
            {
                if (value != null)
                    _secretary = value;
            }
        }

        public String TOTAL
        {
            get
            {
                return _totalToPay;
            }

            set
            {
                if (value != null)
                    _totalToPay = value;
            }
        }

        public Double SIZE
        {
            get
            {
                return _size;
            }

            set
            {
                if(value != null)
                    _size = value;
            }
        }

        public String TOTAL_WITH_FORMAT
        {
            get
            {
                return _totalWithFormat;
            }

            set
            {
                if (value != null)
                    _totalWithFormat = value;
            }
        }

        public String NUM_VISUALIZE
        {
            get
            {
                return _numVisualize;
            }

            set
            {
                if (value != null)
                    _numVisualize = value;
            }
        }
    }
}
