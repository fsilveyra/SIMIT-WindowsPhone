using Simit.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Simit.parse
{
    public class ParseSubpoena
    {
        public List<Subpoena> XmlParserSubpoena(String resultRequest)
        {
             List<Subpoena> listSubpoenas = new List<Subpoena>();
            if (resultRequest != null)
            {
                XDocument document = XDocument.Parse(resultRequest);
                var subpoenas = document.Descendants("return");
                foreach (var subpoena in subpoenas.Descendants("comparendos"))
                {
                    Subpoena newSubpoena = new Subpoena();
                    newSubpoena.STATE = (String)subpoena.Element("estadoComparendo");
                    newSubpoena.DATE = (String)subpoena.Element("fechaComparendo");
                    newSubpoena.OFFENDER = (String)subpoena.Element("infractorComparendo");
                    newSubpoena.NUM_SUBPOENA = (String)subpoena.Element("numeroComparendo");
                    newSubpoena.SECRETARY = (String)subpoena.Element("secretariaComparendo");
                    newSubpoena.TOTAL = (Double)subpoena.Element("total");
                    listSubpoenas.Add(newSubpoena);
                }
            }
            return listSubpoenas;
        
        }
    }
}
