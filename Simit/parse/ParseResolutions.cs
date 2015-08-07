using Simit.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simit.parse
{
    public class ParseResolutions
    {
        public List<Resolution> XmlParserRsolutions(String resultRequest) 
        {
            List<Resolution> listResolutions = new List<Resolution>();
            if (resultRequest != null)
            {
                XDocument document = XDocument.Parse(resultRequest);
                var resolutions = document.Descendants("return");
                foreach (var res in resolutions.Descendants("resoluciones"))
                {
                    if (res.Element("total") != null)
                    {
                        Resolution resolution = new Resolution();
                        resolution.ESTADOS_RESOLUCIONES = (String)res.Element("estadosResoluciones");
                        resolution.FECHA_COMPARENDO = (String)res.Element("fechaComparendo");
                        resolution.FECHA_RESOLUCION = (String)res.Element("fechaResolution");
                        resolution.NOMBRES_INFRACTORES = (String)res.Element("nombresInfractores");
                        resolution.NUM_SUBPOENA = (String)res.Element("numeroComparendo");
                        resolution.RESOLUCIONES = (String)res.Element("resoluciones");
                        resolution.SECRETARIAS = (String)res.Element("secretarias");
                        resolution.TOTAL = (Double)res.Element("total");
                        listResolutions.Add(resolution);
                    }
                }
            }
            return listResolutions;
        }
    }
}
