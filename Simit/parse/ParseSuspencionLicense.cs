using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simit.entities;

namespace Simit.parse
{
    public class ParseSuspencionLicense
    {
        private SuspencionLicense suspencionLicense;

        public SuspencionLicense XmlParsesuspencionLicense(String resultRequest)
        {
            
            if (resultRequest != null)
            {
                XDocument document = XDocument.Parse(resultRequest);
                var textMessage = document.Descendants("return");
                suspencionLicense = new SuspencionLicense();
                suspencionLicense.MESSAGE = (String)textMessage.ElementAt(0).ToString().Replace("<return>","").Replace("</return>","");
            }
            return suspencionLicense;
        }
    }

}
