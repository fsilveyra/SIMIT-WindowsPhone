using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simit.entities;
using System.Xml.Linq;
namespace Simit.parse
{
    public class ParsePaymentArrangements
    {
        public List<PaymentsArrangement> XmlParsePaymentArrangement(String resultRequest)
        {
            List<PaymentsArrangement> listPayment = new List<PaymentsArrangement>();
            if (resultRequest != null)
            {
                XDocument document = XDocument.Parse(resultRequest);
                var resolutions = document.Descendants("return");
                foreach (var res in resolutions.Descendants("acuerdosPagos"))
                {
                    if (res.Element("total") != null)
                    {
                        PaymentsArrangement payment = new PaymentsArrangement();
                        payment.ESTADOS_RESOLUCIONES = (String)res.Element("estadosResoluciones");
                        payment.FECHA_COMPARENDO = (String)res.Element("fechaComparendo");
                        payment.FECHA_RESOLUCION = (String)res.Element("fechaResolucion");
                        payment.NOMBRES_INFRACTORES = (String)res.Element("nombresInfractores");
                        payment.NUM = (String)res.Element("noComparendo");
                        payment.RESOLUCIONES = (String)res.Element("resoluciones");
                        payment.SECRETARIAS = (String)res.Element("secretarias");
                        payment.PERMITE_PAGO = (String)res.Element("permitePago");
                        payment.TOTAL = (String)res.Element("total");
                        listPayment.Add(payment);
                    }
                }
            }
            return listPayment;
        }
    }
}
