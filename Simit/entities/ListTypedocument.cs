using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class ListTypedocument
    {
        private static ListTypedocument INSTANCE = null;
        private List<TypeDocument> listTypedocument = null;

        private ListTypedocument()
        {
            listTypedocument = new List<TypeDocument>();
        }

        public static ListTypedocument getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListTypedocument();
            return INSTANCE;
        }

        public List<TypeDocument> getListTypeDocument()
        {
            TypeDocument typeDocument1 = new TypeDocument();
            typeDocument1.NameDocument = resources.@string.StringResource.citizenship_card;
            typeDocument1.ID = "1";
            listTypedocument.Add(typeDocument1);

            TypeDocument typeDocument2 = new TypeDocument();
            typeDocument2.NameDocument = resources.@string.StringResource.identity_card;
            typeDocument2.ID = "2";
            listTypedocument.Add(typeDocument2);

            TypeDocument typeDocument3 = new TypeDocument();
            typeDocument3.NameDocument = resources.@string.StringResource.writ_of_estranjeria;
            typeDocument3.ID = "3";
            listTypedocument.Add(typeDocument3);

            TypeDocument typeDocument4 = new TypeDocument();
            typeDocument4.NameDocument = resources.@string.StringResource.nit;
            typeDocument4.ID = "4";
            listTypedocument.Add(typeDocument4);

            TypeDocument typeDocument5 = new TypeDocument();
            typeDocument5.NameDocument = resources.@string.StringResource.passport;
            typeDocument5.ID = "6";
            listTypedocument.Add(typeDocument5);

            TypeDocument typeDocument6 = new TypeDocument();
            typeDocument6.NameDocument = resources.@string.StringResource.diplomatic_passport;
            typeDocument6.ID = "7";
            listTypedocument.Add(typeDocument6);

            TypeDocument typeDocument7 = new TypeDocument();
            typeDocument7.NameDocument = resources.@string.StringResource.civil_registration;
            typeDocument7.ID = "8";
            listTypedocument.Add(typeDocument7);

            TypeDocument typeDocument8 = new TypeDocument();
            typeDocument8.NameDocument = resources.@string.StringResource.card_venezuela;
            typeDocument8.ID = "9";
            listTypedocument.Add(typeDocument8);

            return listTypedocument;
        }
    }
}
