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

        //Urls
        //private static String URL_BASE = "http://www.cuponstar.com/api/";
        private static String URL_BASE_CUPON = "http://cms.bonda.us/";
        private static String URL_SAVE_TOKEN_PUSH_NOTIFICATION = "http://173.255.200.14/cupon/api/saveToken";
        private static String API = "api/";
        private static String FAQ = "faq";
        private static String KEY = "388zqNv2ZpHZ8syadeELDgEkP6srpgHy8QzTJeJfY9CZtWpq";
        private static String KEY_FULL = "key=" + KEY;
        private static String ACCESSTYPE = "accesstypes";
        private static String CHECKCODE = "checkcode";
        private static String CATEGORIES = "categorias?";
        private static String OS = "WindowsPhone";
        private static String SMS = "sms";
        private static String IMAGE = "files/uploads/";
        private static String FILTER = "filtros?";
        private static String COUPONS_ALL = "cupones?";
        private static String PARAMETER_PAGE = "&page=";
        private static String PARAMETER_FEACTURED = "&destacado=";
        private static String PARAMETER_COUPON_ID = "&cupon_id=";
        private static String SEND_COUPON = "solicitar_cupon";
        private static String COUPONS_RECEIVED = "cupones_recibidos?";

        //parametros
        private static String PARAMETER_MICRO_SIDE = "&micrositio_id=";
        private static String PARAMETER_CODE_JOINED = "&codigo_afiliado=";
        private static String PARAMETER_CATEGORY = "&categoria=";
        private static String PARAMETER_COUPONS = "&cupones[]=";
        private static String PARAMETER_PROVINCE = "&provincia=";
        private static String PARAMETER_LOCALITY = "&localidad=";
        private static String PARAMETER_DISTRICT = "&barrio=";
        private static String PARAMETER_DISCOUNT = "&descuento=";
        private static String COUPONS = "cupones/";
        private static String BRANCHES = "/sucursales?";
        private static String PARAMETER_OPERATOR = "&operadora=";
        private static String PARAMETER_PHONE = "&celular=";

        private WebRequest webRequest = null;
        private String resultPost = null;
        private IAsyncResult result = null;
        

        //string post
        String postDataCheckCode = null;
        String postDataSendSms = null;
        String postDataSendRequestCoupon = null;

        //Simit
        private static String URL_SERVEICE_GET_POINTS_ATENTION = "https://181.48.11.4/ServiciosSimit/WsPuntosAtencion?wsdl";
        private static String URL_BASE = "https://development.infinixsoft.com/simit/?department_id=11";

        //eventos de respuesta
        public event EventHandler<EventResponseConnection> getQuestionCompleted = null;
        public event EventHandler<EventResponseConnection> getAccessTypesCompleted = null;
        public event EventHandler<EventResponseConnection> getCheckCodeCompleted = null;
        public event EventHandler<EventResponseConnection> getSendSmsCompleted = null;
        public event EventHandler<EventResponseConnection> getCategoriesCompleted = null;
        public event EventHandler<EventResponseConnection> getFiltersCompleted = null;
        public event EventHandler<EventResponseConnection> getCouponsFeaturedCompleted = null;
        public event EventHandler<EventResponseConnection> getCouponsByIdsCompleted = null;
        public event EventHandler<EventResponseConnection> getCouponsByCategoryCompleted = null;
        public event EventHandler<EventResponseConnection> getCouponsByFilterCompleted = null;
        public event EventHandler<EventResponseConnection> getOfficeByIdCouponCompleted = null;
        public event EventHandler<EventResponseConnection> getSendRequestCouponCompleted = null;
        public event EventHandler<EventResponseConnection> getCouponsRecivedCompleted = null;

        //Simit
        public event EventHandler<GetPointsService.BuscarPuntosCompletedEventArgs> getPointsAtentionCompleted = null;

        //datos del numero que se 
        //genera aletoriamente
        private String numberSms;

        /*Metodos get*/

        public String getNumberSms()
        {
            return this.numberSms;
        }

        public String getUrlImageCompany(String image)
        {
            return URL_BASE_CUPON + IMAGE + image;
        }

        public void setNumberSms(String numberSms)
        {
            this.numberSms = numberSms;
        }

        /// <summary>
        /// I done called for the FAQ. On error, returns null
        /// </summary>
        public void getAtentionPoints()
        {
            webRequest = HttpWebRequest.Create(URL_BASE);//api
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
               {
                   try
                   {
                       var responseFaq = webRequest.EndGetResponse(result);
                       resultRequest = new StreamReader(responseFaq.GetResponseStream()).ReadToEnd();
                       XDocument document = XDocument.Parse(resultRequest);
                       var points = document.Descendants("return");
                       foreach (var Point in points.Descendants("puntos"))
                           {
                               string cel = (string)Point.Element("celular1");
                               string address = (string)Point.Element("direcciones");
                               string time = (string)Point.Element("horarios");
                               string latitude = (string)Point.Element("latitud");
                               string longitud = (string)Point.Element("longitud");
                               string muni = (string)Point.Element("municipios");
                           }

                       if (resultRequest != null)
                       {
                           if (getQuestionCompleted != null)
                           {
                               getQuestionCompleted(this, new EventResponseConnection(responseFaq.GetResponseStream()));
                           }
                       }
                   }
                   catch (Exception e)
                   {
                       getQuestionCompleted(this, new EventResponseConnection(new MemoryStream()));//envio datos nulos
                   }

               }, null);
            getQuestionCompleted = null;
        }

        /// <summary>
        /// I performed the call to obtain the types of access. On error, returns null
        /// </summary>
        public void getAccessTypes()
        {
            webRequest = HttpWebRequest.Create(URL_BASE_CUPON + API + ACCESSTYPE);//api
            String resultRequest = null;
            IAsyncResult result = null;
            //verificar si existe coneccion a internet
            result = webRequest.BeginGetResponse(state =>
            {
                //hay que controlar la exepcion not web exception con un try ctach
                try
                {
                    //si no response el servidor o se corta la comunicacion
                    var responseAccesType = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responseAccesType.GetResponseStream()).ReadToEnd();
                    if (resultRequest != null)
                    {
                        if (getAccessTypesCompleted != null)
                        {
                            //genero el evento cuando se completa la ejecucion del hilo
                            getAccessTypesCompleted(this, new EventResponseConnection(responseAccesType.GetResponseStream()));
                        }
                    }
                }
                catch (Exception e)
                {
                    getAccessTypesCompleted(this, new EventResponseConnection(new MemoryStream()));
                    //envio datos nulos ya que la conexion fue interrumpida y no hay datos para mostrar
                }

            }, null);
            getAccessTypesCompleted = null;
        }

        public void getDataPointsAtention(String code)
        {
            
            GetPointsService.WsPuntosAtencionClient getPointsService = new GetPointsService.WsPuntosAtencionClient();
            getPointsService.BuscarPuntosCompleted += getPointsService_BuscarPuntosCompleted;
            getPointsService.BuscarPuntosAsync(code);
             
            
            /*
            string oRequest = "";
            oRequest = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://Servicios/\">";
            oRequest = oRequest + "<soapenv:Header/>";
            oRequest = oRequest + "<soapenv:Body>";
            oRequest = oRequest + "<ser:BuscarPuntos>";
            oRequest = oRequest + "<CodDepartamento>" + code + "</CodDepartamento>";
            oRequest = oRequest + "/<ser:BuscarPuntos>";
            oRequest = oRequest + "</soapenv:Body>";
            oRequest = oRequest + "</soapenv:Envelope>";
            */
           

          
        }

        void getPointsService_BuscarPuntosCompleted(object sender, GetPointsService.BuscarPuntosCompletedEventArgs e)
        {
            int i = 0;
            
        }
         

        /*
        /// <summary>
        /// I done called for the featured coupons. On error, returns null
        /// </summary>
        /// <param name="parameterPage"></param>
        /// <param name="parameterFeactured"></param>
        public void getCouponsFeactured(String parameterPage, int parameterFeactured)
        {
            if (parameterPage != null)
            {
                webRequest = HttpWebRequest.Create(parameterPage);
            }
            else
            {
                parameterPage = "";
                webRequest = HttpWebRequest.Create(URL_BASE + COUPONS_ALL + KEY_FULL
                + PARAMETER_MICRO_SIDE + ManagerUser.getInstance().getUser().getCompany().microsite + PARAMETER_CODE_JOINED
                + ManagerUser.getInstance().getUser().getMember().code + PARAMETER_PAGE + parameterPage
                + PARAMETER_FEACTURED + parameterFeactured);//api para traer los cupones destacados
            }

            String resultRequest = null;
            IAsyncResult result = null;
            result = webRequest.BeginGetResponse(state =>
            {
                try
                {
                    var responseCouponFeactured = webRequest.EndGetResponse(result);
                    resultRequest = new StreamReader(responseCouponFeactured.GetResponseStream()).ReadToEnd();
                    //modifio el json obtenido para evitar el problema de cambio de objeto en las imagenes
                    Stream streamResult = getStreamJsonCorrect(resultRequest);
                    if (responseCouponFeactured.GetResponseStream() != null)
                    {
                        if (getCouponsFeaturedCompleted != null)
                        {
                            //genero el evento cuando se completa la ejecucion del hilo

                            getCouponsFeaturedCompleted(this, new EventResponseConnection(streamResult));
                        }
                    }
                }
                catch (Exception e)
                {
                    getCouponsFeaturedCompleted(this, new EventResponseConnection(new MemoryStream()));
                    //envio datos nulos ya que la conexion fue interrumpida y no hay datos para mostrar
                }
            }, null);
            getCouponsFeaturedCompleted = null;
        }

        private Stream getStreamJsonCorrect(String value)
        {
            String chage_foto_thumbnail = value.Replace("\"foto_thumbnail\":[]", "\"foto_thumbnail\":{}");
            String change_foto_foto_home = chage_foto_thumbnail.Replace("\"foto_principal\":[]", "\"foto_principal\":{}");
            String chage_foto_wide_screen = change_foto_foto_home.Replace("\"foto_apaisada\":[]", "\"foto_apaisada\":{}");
            byte[] byteArray = Encoding.UTF8.GetBytes(chage_foto_wide_screen);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
         * */
    }
}
