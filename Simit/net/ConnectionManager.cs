using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using Simit.classAux;
using System.Windows.Resources;
using Simit.data;
using System.Net.Sockets;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using Microsoft.Phone.Reactive;
using System.Net;
using Simit.entities;
using Simit.parse;

namespace Simit.data
{
    public class ConnectionManager
    {
        private static ConnectionManager INSTANCE = null;

        private ConnectionManager()
        {
             
        }

        public static ConnectionManager getIntance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ConnectionManager();
            }

            return INSTANCE;
        }


        private WebRequest webRequest = null;
        private String resultPost = null;
        private IAsyncResult result = null;

        //Simit
        private static String URL_SERVEICE_GET_POINTS_ATENTION = "https://181.48.11.4/ServiciosSimit/WsPuntosAtencion?wsdl";//deprecated
        private static String URL_BASE = "https://development.infinixsoft.com/simit/";
        private static String PARAMETER_CHANEL_ID = "&channelId=";
        private static String PARAMETER_API_KEY_APP_ANDROID = "&key=";
        private static String CHANEL_ID = resources.@string.StringResource.CHANELID_YOU_TUBE;
        private static String API_KEY_APP_ANDROID = resources.@string.StringResource.API_KEY_APP_ANDROID;
        private static String URL_NEWS = "https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=10&order=date";

        //parameters
        private static String PARAMETER_NUM_DEPARTMENT = "&department_id=";
        private static string PARAMETER_DOCUMENT = "&document=";
        private static String PARAMETER_DOCUMENT_TYPE = "&document_type=";

        //parameters de seriios
        private static String PARAMTER_SERVICE = "?service=";
        private static String PARAMETER_SERVICE_GET_POINTS = "puntos_atencion";
        private static String PARAMETER_SERVICE_GET_SUBPOENAS = "comparendos";
        private static String PARAMETER_SERVICE_GET_RESOLUTIONS = "resoluciones";//payment_arrangements
        private static String PARAMETER_SERVICE_GET_PAYMENT_ARRANGEMENTS = "acuerdos_pago";
        

        //eventos de respuesta
        public event EventHandler<EventResponseConnection> getAtentionPointsCompleted = null;
        public event EventHandler<EventResponseConnection> getSubpoenaCompleted = null;
        public event EventHandler<EventResponseConnection> getResolutionsCompleted = null;
        public event EventHandler<EventResponseConnection> getPaymentArrangementsCompleted = null;
        public event EventHandler<EventResponseConnection> getItemsNewsCompleted = null;
        
        //public event EventHandler<EventResponseConnection> getCategoriesCompleted = null;

        public void getItemsNews()
        {
            webRequest = HttpWebRequest.Create(URL_NEWS + PARAMETER_CHANEL_ID + CHANEL_ID + PARAMETER_API_KEY_APP_ANDROID + API_KEY_APP_ANDROID);
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
            {
                try
                {
                    var responseItemsNews = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responseItemsNews.GetResponseStream()).ReadToEnd();
                    
                    if (resultRequest != null)
                    {
                        if (getItemsNewsCompleted != null)
                        {
                            getItemsNewsCompleted(this, new EventResponseConnection(resultRequest));
                        }
                    }
                }
                catch (Exception e)
                {
                    getItemsNewsCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                }

            }, null);
            getItemsNewsCompleted = null;
        }

        public void getPaymentArrangements(String document,String documentType)
        {
            webRequest = HttpWebRequest.Create(URL_BASE + PARAMTER_SERVICE + PARAMETER_SERVICE_GET_PAYMENT_ARRANGEMENTS + PARAMETER_DOCUMENT + document + PARAMETER_DOCUMENT_TYPE + documentType);
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
            {
                try
                {
                    var responsePaymentArrangements = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responsePaymentArrangements.GetResponseStream()).ReadToEnd();

                    if (resultRequest != null)
                    {
                        if (getPaymentArrangementsCompleted != null)
                        {
                            getPaymentArrangementsCompleted(this, new EventResponseConnection(resultRequest));
                        }
                    }
                }
                catch (Exception e)
                {
                    getPaymentArrangementsCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                }

            }, null);
            getPaymentArrangementsCompleted = null;
        }

        public void getResolutions(String document, String documentType)
        {
            webRequest = HttpWebRequest.Create(URL_BASE + PARAMTER_SERVICE + PARAMETER_SERVICE_GET_RESOLUTIONS + PARAMETER_DOCUMENT + document + PARAMETER_DOCUMENT_TYPE + documentType);
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
            {
                try
                {
                    var responseResolutions = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responseResolutions.GetResponseStream()).ReadToEnd();

                    if (resultRequest != null)
                    {
                        if (getResolutionsCompleted != null)
                        {
                            getResolutionsCompleted(this, new EventResponseConnection(resultRequest));
                        }
                    }
                }
                catch (Exception e)
                {
                    getResolutionsCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                }

            }, null);
            getResolutionsCompleted = null;
        }

        public void getSubpoena(String document,String documentType)
        {
            webRequest = HttpWebRequest.Create(URL_BASE + PARAMTER_SERVICE + PARAMETER_SERVICE_GET_SUBPOENAS + PARAMETER_DOCUMENT + document + PARAMETER_DOCUMENT_TYPE + documentType);
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
            {
                try
                {
                    var responseSubpoena = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responseSubpoena.GetResponseStream()).ReadToEnd();

                    if (resultRequest != null)
                    {
                        if (getSubpoenaCompleted != null)
                        {
                            getSubpoenaCompleted(this, new EventResponseConnection(resultRequest));
                        }
                    }
                }
                catch (Exception e)
                {
                    getSubpoenaCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                }

            }, null);
            getSubpoenaCompleted = null;
        }

        /// <summary>
        /// I done called for the FAQ. On error, returns null
        /// </summary>
        public void getAtentionPoints(String numDepartment)
        {
            webRequest = HttpWebRequest.Create(URL_BASE + PARAMTER_SERVICE + PARAMETER_SERVICE_GET_POINTS + PARAMETER_NUM_DEPARTMENT + numDepartment);//api
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
               {
                   try
                   {
                       var responsePoints = webRequest.EndGetResponse(result);
                       resultRequest = new StreamReader(responsePoints.GetResponseStream()).ReadToEnd();
                       
                       if (resultRequest != null)
                       {
                           if (getAtentionPointsCompleted != null)
                           {
                               getAtentionPointsCompleted(this, new EventResponseConnection(resultRequest));
                           }
                       }
                   }
                   catch (Exception e)
                   {
                       getAtentionPointsCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                   }

               }, null);
            getAtentionPointsCompleted = null;
        }
    }
}
