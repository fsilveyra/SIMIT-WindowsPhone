using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simit.entities;

namespace Simit.parse
{
    class ParsePointAtenion
    {
        public List<PointsAtention> XmlParserPointAtention(String resultRequest)
        {
            List<PointsAtention> listPointAtention = new List<PointsAtention>();
            if (resultRequest != null)
            {
                XDocument document = XDocument.Parse(resultRequest);
                var points = document.Descendants("return");
                foreach (var Point in points.Descendants("puntos"))
                {
                    PointsAtention pointAtention = new PointsAtention();
                    pointAtention.CELL = (string)Point.Element("celular1");
                    pointAtention.ADDRESS = (string)Point.Element("direcciones");
                    pointAtention.TIME = (string)Point.Element("horarios");
                    pointAtention.LATITUDE = (string)Point.Element("latitud");
                    pointAtention.LONGITUDE = (string)Point.Element("longitud");
                    pointAtention.MUNISIPALITIES = (string)Point.Element("municipios");
                    //cargo el pointAtention a la lista
                    listPointAtention.Add(pointAtention);
                }
            }
            return listPointAtention;
        }
    }
}
