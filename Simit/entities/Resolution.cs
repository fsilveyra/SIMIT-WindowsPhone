using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class Resolution
    {
        private String _estadosResoluciones;
        private String _fechaComparendo;
        private String _fechaResolucion;
        private String _nombresInfractores;
        private String _numeroComparendo;
        private String _resoluciones;
        private String _secretarias;
        private String _total;
        private Double _size;
        //para la vista en la lista
        private String _totalwithFormat;
        private String _numVisualize;

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
                return _numeroComparendo;
            }

            set
            {
                if (value != null)
                 _numeroComparendo = value;
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
                 _total = value;
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
                return _totalwithFormat;
            }

            set
            {
                if (value != null)
                    _totalwithFormat = value;
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
