using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simit.entities
{
    public class ListNameAtentionPoints
    {
        private static ListNameAtentionPoints INSTANCE = null;
        private List<NameAtentionPoints> listNameAtentionPints = null;

        private ListNameAtentionPoints()
        {
            listNameAtentionPints = new List<NameAtentionPoints>();
        }

        public static ListNameAtentionPoints getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ListNameAtentionPoints();
                
            }
            return INSTANCE;
        }

        public List<NameAtentionPoints> getListNameAtentionPoints()
        {
            NameAtentionPoints name1 = new NameAtentionPoints();
            name1.NAME_ATENTION_POINTS = resources.@string.StringResource.antioquia;
            name1.ID = "05";
            listNameAtentionPints.Add(name1);

            NameAtentionPoints name2 = new NameAtentionPoints();
            name2.NAME_ATENTION_POINTS = resources.@string.StringResource.atlantic;
            name2.ID = "08";
            listNameAtentionPints.Add(name2);

            NameAtentionPoints name3 = new NameAtentionPoints();
            name3.NAME_ATENTION_POINTS = resources.@string.StringResource.boyaca;
            name3.ID = "15";
            listNameAtentionPints.Add(name3);

            NameAtentionPoints name4 = new NameAtentionPoints();
            name4.NAME_ATENTION_POINTS = resources.@string.StringResource.bogota_dc;
            name4.ID = "11";
            listNameAtentionPints.Add(name4);

            NameAtentionPoints name5 = new NameAtentionPoints();
            name5.NAME_ATENTION_POINTS = resources.@string.StringResource.bolivar;
            name5.ID = "13";
            listNameAtentionPints.Add(name5);

            NameAtentionPoints name6 = new NameAtentionPoints();
            name6.NAME_ATENTION_POINTS = resources.@string.StringResource.cordoba;
            name6.ID = "23";
            listNameAtentionPints.Add(name6);

            NameAtentionPoints name7 = new NameAtentionPoints();
            name7.NAME_ATENTION_POINTS = resources.@string.StringResource.cauca;
            name7.ID = "19";
            listNameAtentionPints.Add(name7);

            NameAtentionPoints name8 = new NameAtentionPoints();
            name8.NAME_ATENTION_POINTS = resources.@string.StringResource.caldas;
            name6.ID = "17";
            listNameAtentionPints.Add(name8);

            NameAtentionPoints name9 = new NameAtentionPoints();
            name9.NAME_ATENTION_POINTS = resources.@string.StringResource.cesar;
            name9.ID = "20";
            listNameAtentionPints.Add(name9);

            NameAtentionPoints name10 = new NameAtentionPoints();
            name10.NAME_ATENTION_POINTS = resources.@string.StringResource.cundinamarca;
            name10.ID = "25";
            listNameAtentionPints.Add(name10);

            NameAtentionPoints name11 = new NameAtentionPoints();
            name11.NAME_ATENTION_POINTS = resources.@string.StringResource.choco;
            name11.ID = "27";
            listNameAtentionPints.Add(name11);

            NameAtentionPoints name12 = new NameAtentionPoints();
            name12.NAME_ATENTION_POINTS = resources.@string.StringResource.la_guajira;
            name12.ID = "44";
            listNameAtentionPints.Add(name12);

            NameAtentionPoints name13 = new NameAtentionPoints();
            name13.NAME_ATENTION_POINTS = resources.@string.StringResource.huila;
            name13.ID = "41";
            listNameAtentionPints.Add(name13);

            NameAtentionPoints name14 = new NameAtentionPoints();
            name14.NAME_ATENTION_POINTS = resources.@string.StringResource.magdalena;
            name14.ID = "47";
            listNameAtentionPints.Add(name14);

            NameAtentionPoints name15 = new NameAtentionPoints();
            name15.NAME_ATENTION_POINTS = resources.@string.StringResource.meta;
            name15.ID = "50";
            listNameAtentionPints.Add(name15);

            NameAtentionPoints name16 = new NameAtentionPoints();
            name16.NAME_ATENTION_POINTS = resources.@string.StringResource.north_of_santander;
            name16.ID = "54";
            listNameAtentionPints.Add(name16);

            NameAtentionPoints name17 = new NameAtentionPoints();
            name17.NAME_ATENTION_POINTS = resources.@string.StringResource.quindio;
            name17.ID = "63";
            listNameAtentionPints.Add(name17);

            NameAtentionPoints name18 = new NameAtentionPoints();
            name18.NAME_ATENTION_POINTS = resources.@string.StringResource.risalda;
            name18.ID = "66";
            listNameAtentionPints.Add(name18);

            NameAtentionPoints name19 = new NameAtentionPoints();
            name19.NAME_ATENTION_POINTS = resources.@string.StringResource.sucre;
            name19.ID = "70";
            listNameAtentionPints.Add(name19);

            NameAtentionPoints name20 = new NameAtentionPoints();
            name20.NAME_ATENTION_POINTS = resources.@string.StringResource.santander;
            name20.ID = "68";
            listNameAtentionPints.Add(name20);

            NameAtentionPoints name21 = new NameAtentionPoints();
            name21.NAME_ATENTION_POINTS = resources.@string.StringResource.tolina;
            name21.ID = "73";
            listNameAtentionPints.Add(name21);

            NameAtentionPoints name22 = new NameAtentionPoints();
            name22.NAME_ATENTION_POINTS = resources.@string.StringResource.valle_del_cauca;
            name22.ID = "76";
            listNameAtentionPints.Add(name22);

            NameAtentionPoints name23 = new NameAtentionPoints();
            name23.NAME_ATENTION_POINTS = resources.@string.StringResource.san_andres_providencia;
            name23.ID = "88";
            listNameAtentionPints.Add(name23);

            NameAtentionPoints name24 = new NameAtentionPoints();
            name24.NAME_ATENTION_POINTS = resources.@string.StringResource.caqueta;
            name24.ID = "18";
            listNameAtentionPints.Add(name24);

            NameAtentionPoints name25 = new NameAtentionPoints();
            name25.NAME_ATENTION_POINTS = resources.@string.StringResource.arauca;
            name25.ID = "81";
            listNameAtentionPints.Add(name25);

            NameAtentionPoints name26 = new NameAtentionPoints();
            name26.NAME_ATENTION_POINTS = resources.@string.StringResource.nariño;
            name26.ID = "52";
            listNameAtentionPints.Add(name26);

            NameAtentionPoints name27 = new NameAtentionPoints();
            name27.NAME_ATENTION_POINTS = resources.@string.StringResource.amazonas;
            name27.ID = "91";
            listNameAtentionPints.Add(name27);

            NameAtentionPoints name28 = new NameAtentionPoints();
            name28.NAME_ATENTION_POINTS = resources.@string.StringResource.putumayo;
            name28.ID = "86";
            listNameAtentionPints.Add(name28);

            NameAtentionPoints name29 = new NameAtentionPoints();
            name29.NAME_ATENTION_POINTS = resources.@string.StringResource.guainía;
            name29.ID = "94";
            listNameAtentionPints.Add(name29);

            NameAtentionPoints name30 = new NameAtentionPoints();
            name30.NAME_ATENTION_POINTS = resources.@string.StringResource.vaupes;
            name30.ID = "97";
            listNameAtentionPints.Add(name30);

            NameAtentionPoints name31 = new NameAtentionPoints();
            name31.NAME_ATENTION_POINTS = resources.@string.StringResource.vichada;
            name31.ID = "99";
            listNameAtentionPints.Add(name31);

            NameAtentionPoints name32 = new NameAtentionPoints();
            name32.NAME_ATENTION_POINTS = resources.@string.StringResource.casanare;
            name32.ID = "85";
            listNameAtentionPints.Add(name32);

            NameAtentionPoints name33 = new NameAtentionPoints();
            name33.NAME_ATENTION_POINTS = resources.@string.StringResource.guaviare;
            name33.ID = "95";
            listNameAtentionPints.Add(name33);

            return listNameAtentionPints;
        }
    }
}
