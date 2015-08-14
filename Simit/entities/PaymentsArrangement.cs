using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class PaymentsArrangement
    {
        private String _estadosResoluciones;
        private String _fechaComparendo;
        private String _fechaResolucion;
        private String _nombresInfractores;
        private String _num;
        private String _resoluciones;
        private String _secretarias;
        private String _total;
        private String _permitePago;
        private Double _size;
        //para la representacion de los valores
        private String _numVisualize;
        private String _totalWithFormat;

        public String ESTADOS_RESOLUCIONES
        {
            get
            {
                return _estadosResoluciones;
            }

            set
            {
                if (value != null)
                    _estadosResoluciones = value;
            }
        }

        public String FECHA_COMPARENDO
        {
            get
            {
                return _fechaComparendo;
            }

            set
            {
                if (value != null)
                    _fechaComparendo = value;
            }
        }

        public String FECHA_RESOLUCION
        {
            get
            {
                return _fechaResolucion;
            }

            set
            {
                if (value != null)
                    _fechaResolucion = value;
            }
        }

        public String NOMBRES_INFRACTORES
        {
            get
            {
                return _nombresInfractores;
            }

            set
            {
                if (value != null)
                    _nombresInfractores = value;
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

        public String RESOLUCIONES
        {
            get
            {
                return _resoluciones;
            }

            set
            {
                if (value != null)
                    _resoluciones = value;
            }
        }

        public String SECRETARIAS
        {
            get
            {
                return _secretarias;
            }

            set
            {
                if (value != null)
                    _secretarias = value;
            }
        }

        public String TOTAL
        {
            get
            {
                return _total;
            }

            set
            {
                if (value != null)
                    _total = value;
            }
        }

        public String PERMITE_PAGO
        {
            get
            {
                return _permitePago;
            }

            set
            {
                if (value != null)
                    _permitePago = value;
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
