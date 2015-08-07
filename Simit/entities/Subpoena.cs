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
        private String _numSubpoena;
        private String _offender;
        private String _secretary;
        private Double _totalToPay;


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

        public String NUM_SUBPOENA
        {
            get
            {
                return _numSubpoena;
            }

            set
            {
                if (value != null)
                    _numSubpoena = value;
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

        public Double TOTAL
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
    }
}
