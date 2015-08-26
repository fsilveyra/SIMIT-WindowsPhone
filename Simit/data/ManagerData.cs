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
using Simit;
using System.Windows.Threading;
using Simit.classAux;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using Simit.parse;
using Simit.entities;



namespace Simit.data
{
    public class ManagerData //: NotificationEnabledObject
    {
        private static ManagerData INSTANCE = null;
        private ConnectionManager connectionManager;
        public event EventHandler<EventResponseData> getDataCompleted;//evento que se genera para ser capturado por la clase llamadora

        private ManagerData()
        {
            this.connectionManager = ConnectionManager.getIntance();
        }

        public static ManagerData getIntance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ManagerData();
            }
            return INSTANCE;
        }

        /// <summary>
        /// Returns a SolidColorBrush from a string hexagecimal format.
        /// </summary>
        /// <param name="hexaColor"></param>
        /// <returns></returns>
        public SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            String s = null;
            if (hexaColor.Length < 8)
            {
                s = "#FF" + hexaColor.Substring(1);
            }
            SolidColorBrush colorBrush = new SolidColorBrush(
            Color.FromArgb(
                Convert.ToByte(s.Substring(1, 2), 16),
                Convert.ToByte(s.Substring(3, 2), 16),
                Convert.ToByte(s.Substring(5, 2), 16),
                Convert.ToByte(s.Substring(7, 2), 16))
            );
            return colorBrush;
        }
        
        /*
        public void setEventDataCompleted()
        {
            getDataCompleted = null;
        }

        

        */
        //Metodos de ManagerData

        /// <summary>
        /// I performed the call to connectionManager.getFaq() 
        /// and parses the data and generates an event with the data.
        /// </summary>
        public void getAtentionPoints(String numDeparment)
        {
            //preguntar si hay internet
            ParsePointAtenion xmlParserPointAtention = new ParsePointAtenion();
            List<PointsAtention> listPointsAtention = new List<PointsAtention>();
            connectionManager.getAtentionPoints(numDeparment);
            //hago el llamado para obtener los datos
            connectionManager.getAtentionPointsCompleted += (s, eventResponse) =>
                {
                    //para eliminar la excepcion de hilos cruzados
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (eventResponse != null)//verifico si no es nula la respuesta
                            {
                                //parser los datos90
                                listPointsAtention = xmlParserPointAtention.XmlParserPointAtention(eventResponse.getResponseString());
                                if (getDataCompleted != null)
                                    getDataCompleted(this, new EventResponseData(listPointsAtention));//genero un evento de respuesta con los datos solicitados
                                 
                            }
                        });
                };
            getDataCompleted = null;
        }

        public void getResolutions(String document, String documentType)
        {
            ParseResolutions parseResolutions = new ParseResolutions();
            List<Resolution> resolutions = new List<Resolution>();
            connectionManager.getResolutions(document, documentType);
            connectionManager.getResolutionsCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos
                        resolutions = parseResolutions.XmlParserRsolutions(eventResponse.getResponseString());
                        if (getDataCompleted != null)
                            getDataCompleted(this, new EventResponseData(resolutions));//genero un evento de respuesta con los datos solicitados

                    }
                });
            };
            getDataCompleted = null;
        }


        public void getSubpoena(String document, String document_type)
        {
            ParseSubpoena xmlParserSubpona = new ParseSubpoena();
            List<Subpoena> listSubpoenas = new List<Subpoena>();
            connectionManager.getSubpoena(document, document_type);
            connectionManager.getSubpoenaCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos
                        listSubpoenas = xmlParserSubpona.XmlParserSubpoena(eventResponse.getResponseString());
                        if (getDataCompleted != null)
                            getDataCompleted(this, new EventResponseData(listSubpoenas));//genero un evento de respuesta con los datos solicitados

                    }
                });
            };
            getDataCompleted = null;
        }

        public void getPaymentArrangements(String document, String documentType)
        {
            ParsePaymentArrangements parsePayment = new ParsePaymentArrangements();
            List<PaymentsArrangement> payments = new List<PaymentsArrangement>();
            connectionManager.getPaymentArrangements(document, documentType);
            connectionManager.getPaymentArrangementsCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos
                        payments = parsePayment.XmlParsePaymentArrangement(eventResponse.getResponseString());
                        if (getDataCompleted != null)
                            getDataCompleted(this, new EventResponseData(payments));//genero un evento de respuesta con los datos solicitados

                    }
                });
            };
            getDataCompleted = null;
        }

        public void getSuspencionLicense(String document, String documentType)
        {
            ParseSuspencionLicense parseSuspencionLicense = new ParseSuspencionLicense();
            SuspencionLicense suspencionLicense = new SuspencionLicense();
            connectionManager.getSuspencionLicense(document, documentType);
            connectionManager.getsuspencionLicenseCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos
                        suspencionLicense = parseSuspencionLicense.XmlParsesuspencionLicense(eventResponse.getResponseString());
                        if (getDataCompleted != null)
                            getDataCompleted(this, new EventResponseData(suspencionLicense));//genero un evento de respuesta con los datos solicitados
                    }
                });
            };
            getDataCompleted = null;
        }

        public void getItemsNews()
        {
            List<ItemNews> listItemNews = new List<ItemNews>();
            ParseItemsNews parseItemNews = new ParseItemsNews();
            connectionManager.getItemsNews();
            connectionManager.getItemsNewsCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        listItemNews = (List<ItemNews>)parseItemNews.parseJsonItemNews(eventResponse.getResponseString());
                        //payments = parsePayment.XmlParsePaymentArrangement(eventResponse.getResponseString());
                        
                        if (getDataCompleted != null)
                            getDataCompleted(this, new EventResponseData(listItemNews));//genero un evento de respuesta con los datos solicitados
                    }
                });
            };
            getDataCompleted = null;
        }

        /*
        /// <summary>
        /// I performed the call to connectionManager.getAccessTypes()
        /// and parses the data and generates an event with the data.
        /// </summary>
        public void getAccessTypes()
        {
            //preguntar si hay internet
            RootAccessTypes rootAccessTypes;
            ParserAccessType parserAccessType = new ParserAccessType();
            connectionManager.getAccessTypes();
            //hago el llamado para obtener los datos
            connectionManager.getAccessTypesCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos
                        rootAccessTypes = parserAccessType.json_parser_AccessTypes(eventResponse.getResponse());

                        if (getDataCompleted != null)
                        {
                            List<AccessTypes> listAccessTypes = null;
                            if (rootAccessTypes != null)
                            {
                                listAccessTypes = new List<AccessTypes>();
                                foreach (AccessTypesResponse accessTypesResponse in rootAccessTypes.response)
                                {
                                    listAccessTypes.Add(accessTypesResponse.accesstypes);//array de objetos accessType
                                }
                            }
                            getDataCompleted(this, new EventResponseData(listAccessTypes));//genero un evento de respuesta con los datos solicitados
                        }
                    }
                });

            };

            getDataCompleted = null;
        }

        /// <summary>
        /// I performed the call to connectionManager.getCategories() 
        /// and parses the data and generates an event with the data.
        /// </summary>
        public void getCategories()
        {
            CategoriesResponse categoriesResponse = new CategoriesResponse();
            ParserCategory parserCategory = new ParserCategory();
            connectionManager.getCategories();
            //hago el llamado para obtener los datos
            connectionManager.getCategoriesCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        categoriesResponse = parserCategory.json_parser_Categories(eventResponse.getResponse());
                        if (getDataCompleted != null && categoriesResponse != null)
                        {
                            //genero un evento de respuesta con los datos solicitados
                            getDataCompleted(this, new EventResponseData(categoriesResponse.getResponse()));
                        }
                    }
                });

            };
            getDataCompleted = null;
        }

        /// <summary>
        /// I performed the call to connectionManager.getFilters() 
        /// and parses the data and generates an event with the data.
        /// </summary>
        public void getFilters()
        {

            Filter filter = null;
            ParserFilters parserFilters = new ParserFilters();
            connectionManager.getFilters();
            //hago el llamado para obtener los datos
            connectionManager.getFiltersCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        filter = parserFilters.json_parser_Filters(eventResponse.getResponseString());

                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(filter));
                });

            };
            getDataCompleted = null;
        }

        /// <summary>
        /// Make the call to connectionManager.getCouponsFeactured (page, highlighted) 
        /// and parses the data and generates an event with the data. 
        /// </summary>
        /// <param name="page">Page: parameter for paging contains a url or null.</param>
        public void getCuponsFeactured(String page)
        {
            CouponPageResponse couponFeactureResponse = new CouponPageResponse();
            ParsePageResponse parserCouponFeacture = new ParsePageResponse();
            //int page = 1;//inicializo el numero de pagina
            int destacado = 1;//inicializo
            connectionManager.getCouponsFeactured(page, destacado);
            //hago el llamado para obtener los datos
            connectionManager.getCouponsFeaturedCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        couponFeactureResponse = parserCouponFeacture.json_parser_CouponFeactured(eventResponse.getResponse());
                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(couponFeactureResponse));
                });
            };
            getDataCompleted = null;
        }

        /// <summary>
        /// Make the call to connectionManager.getCouponsByIds (coupons) 
        /// and parses the data and generates an event with the data. 
        /// </summary>
        /// <param name="coupons">Resive as parameter a list of id coupons...</param>
        public void getCuponsByIds(List<String> coupons)
        {
            List<Coupon> couponByIds = new List<Coupon>();
            ParcerCoupons parserCoupons = new ParcerCoupons();
            connectionManager.getCouponsByIds(coupons);
            //hago el llamado para obtener los datos
            connectionManager.getCouponsByIdsCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner 
                        //los atributos de las entidades como publicos 
                        couponByIds = parserCoupons.json_parser_CouponByIds(eventResponse.getResponse());
                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(couponByIds));
                });
            };
            getDataCompleted = null;
        }

        /// <summary>
        /// Make the call to connectionManager.getCouponsByCategory (pageWebRequest, 
        /// category) and parses the data and generates an event with the data.
        /// </summary>
        /// <param name="pageWebRequest"> Parameter used for paging contains a url or null.</param>
        /// <param name="category">Parameter containing the id of the category of coupons.</param>
        public void getCuponsByCategory(String pageWebRequest, String category)
        {
            CouponPageResponse couponPageResponse = new CouponPageResponse();
            ParsePageResponse parserCouponFeacture = new ParsePageResponse();
            //hago el llamado para obtener los datos
            if (pageWebRequest == null && category != null)
            {
                connectionManager.getCouponsByCategory(null, category);
            }
            else
            {
                connectionManager.getCouponsByCategory(pageWebRequest, null);
            }

            connectionManager.getCouponsByCategoryCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        couponPageResponse = parserCouponFeacture.json_parser_CouponFeactured(eventResponse.getResponse());

                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(couponPageResponse));
                });

            };
            getDataCompleted = null;
        }

        /// <summary>
        ///  Make the call to connectionManager.getCouponsByFilter 
        ///  (null, province, locality, distric, category, discount) 
        ///  and parses the data and generates an event with the data....
        /// </summary>
        /// <param name="pageWebRequest">Parameter used for paging contains a url or null.</param>
        /// <param name="province">Key with the name of the province.</param>
        /// <param name="locality">Key with the name of the town.</param>
        /// <param name="distric">Key with the name of the neighborhood.</param>
        /// <param name="category">Id of the corresponding category.</param>
        /// <param name="discount">>Key to the equivalent to the discount chain.</param>
        public void getCuponsByFilter(String pageWebRequest, String province,
            String locality, String distric, String category, String discount)
        {
            CouponPageResponse couponPageResponse = new CouponPageResponse();
            ParsePageResponse parserCouponFeacture = new ParsePageResponse();
            //hago el llamado para obtener los datos
            if (pageWebRequest == null)
            {
                connectionManager.getCouponsByFilter(null, province, locality, distric, category, discount);
            }
            else
            {
                connectionManager.getCouponsByFilter(pageWebRequest, null, null, null, null, null);
            }

            connectionManager.getCouponsByFilterCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        couponPageResponse = parserCouponFeacture.json_parser_CouponFeactured(eventResponse.getResponse());

                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(couponPageResponse));
                });

            };
            getDataCompleted = null;
        }

        /// <summary>
        /// Make the call to connectionManager.getOfficeByIdCoupon(couponId) 
        /// and parses the data and generates an event with the data.
        /// </summary>
        /// <param name="couponId">Parametro con id del cupon.</param>
        public void getOfficeByIdCoupon(String couponId)
        {
            OfficeResponse officeResponse = null;
            ParserOffice parserOffice = new ParserOffice();
            //hago el llamado para obtener los dato
            connectionManager.getOfficeByIdCoupon(couponId);
            connectionManager.getOfficeByIdCouponCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (eventResponse.getResponse() != null)//verifico si no es nula la respuesta
                    {
                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        officeResponse = parserOffice.json_parser_Office((eventResponse.getResponse()));

                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(officeResponse));
                });

            };
            getDataCompleted = null;
        }

        /// <summary>
        /// Make the call to connectionManager.getCouponsReceived(pageWebRequest) 
        /// and parses the data and generates an event with the data.
        /// </summary>
        /// <param name="pageWebRequest">Parameter used for paging contains a url or null.</param>
        public void getCouponsReceived(String pageWebRequest)
        {

            CouponPageResponse couponPageResponse = new CouponPageResponse();
            ParsePageResponse parserCouponFeacture = new ParsePageResponse();
            //hago el llamado para obtener los datos
            if (pageWebRequest != null)
            {
                connectionManager.getCouponsReceived(pageWebRequest);
            }
            else
            {
                connectionManager.getCouponsReceived(null);
            }

            connectionManager.getCouponsRecivedCompleted += (s, eventResponse) =>
            {
                //para eliminar la excepcion de hilos cruzados
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //connectionManager.setStateWebRequest();
                    if (eventResponse != null)//verifico si no es nula la respuesta
                    {

                        //parser los datos, cuidado para parsear hay que poner los atributos de las entidades como publicos 
                        couponPageResponse = parserCouponFeacture.json_parser_CouponFeactured(eventResponse.getResponse());

                    }
                    //genero un evento de respuesta con los datos solicitados
                    getDataCompleted(this, new EventResponseData(couponPageResponse));
                });

            };
            getDataCompleted = null;
        }

        /*metodos post

        /// <summary>
        ///  Make the call to connectionManager.postCheckCode (phone, code, gender) for sending data, 
        ///  if so generates an event with the response that can be true or false.
        /// </summary>
        /// <param name="phone"> Parameter phone of the user.</param>
        /// <param name="code">Dni of de user.</param>
        /// <param name="gender">Sex of the user.</param>
        public void postCheckCode(String phone,
            String code, String gender,String token)
        {
            connectionManager.postCheckCode(phone, code, gender,token);
            connectionManager.getCheckCodeCompleted += (s, eventResponse) =>
            {
                RootCheckCode rootCheckCode = null;
                ParserCheckCode parserCheckCode = new ParserCheckCode();
                Boolean check = false;

                if (eventResponse != null)
                {
                    //parseo de los datos
                    rootCheckCode = parserCheckCode.json_parser_CheckCode(eventResponse.getResponse());

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (rootCheckCode != null)
                    {
                        if (rootCheckCode.response != 2)//no se produjo error y respondio correctamente
                        {
                            loadUser(rootCheckCode, null);//cargo los datos del usuario y su compania
                            check = true;
                        }
                    }
                    getDataCompleted(this, new EventResponseData(check));
                });
                }
            };
            getDataCompleted = null;
        }

        /// <summary>
        ///  Make the call to connectionManager.postSendsms (phone, codeAreaPhoneNumber, operatorPhoneNumber) 
        ///  for sending data, parses the response and if so generates an event with the response that can be 
        ///  true or false.
        /// </summary>
        /// <param name="phone">Phone of the user.</param>
        /// <param name="codeAreaPhoneNumber">Code area phone number.</param>
        /// <param name="operatorPhoneNumber">Operator of phone.</param>
        /// <param name="gender">Sex of the user.</param>
        public void postSendSms(String phone, String codeAreaPhoneNumber, String operatorPhoneNumber, String gender)
        {
            connectionManager.postSendsms(phone, codeAreaPhoneNumber, operatorPhoneNumber);
            connectionManager.getSendSmsCompleted += (s, eventResponseSendSms) =>
           {
               JsonObjectSimple jsonObjectSimple = null;
               ParserJsonObjectSimple parserJosnObjectSimple = new ParserJsonObjectSimple();
               Boolean sendMansage = false;

               if (eventResponseSendSms != null)
               {
                   String result = new StreamReader(eventResponseSendSms.getResponse()).ReadToEnd();
                   //parseo de los datos
                   jsonObjectSimple = parserJosnObjectSimple.json_parser_ObjectSimple(eventResponseSendSms.getResponse());

                   Deployment.Current.Dispatcher.BeginInvoke(() =>
                   {
                       try
                       {
                           if (jsonObjectSimple.getValue().Equals("SMS enviado!"))//no se produjo error y respondio correctamente, guardo los datos del usuario
                           {
                               sendMansage = true;
                               Member member;
                               User user = ManagerUser.getInstance().getUser();//obtengo los datos del usuario actual
                               member = user.getMember();
                               //seteo los datos faltantes
                               member.phone = codeAreaPhoneNumber + "-" + phone;
                               //uso el guion como separador luego uso split con el separador "-" para obtener los dos
                               member.gender = gender;
                               member.phoneOperator = operatorPhoneNumber;
                               //seteo el member del usuario y cargo el usuario con los datos nuevos
                               user.setMember(member);
                               ManagerUser.getInstance().setUser(user);
                               getDataCompleted(this, new EventResponseData(sendMansage));//genero un evento de respuesta con los datos solicitados
                           }
                       }
                       catch (Exception e)
                       {
                           getDataCompleted(this, new EventResponseData(sendMansage));
                           //envio datos nulos ya que la conexion fue interrumpida y no hay datos para mostrar
                       }
                   });
               }
           };
        }

        /// <summary>
        /// Make the call to connectionManager.postRequestCoupon (couponId, phone, codeAreaPhoneNumber, operatorPhoneNumber)
        /// for sending data, parses the response and if so generates an event with the response that can be true or false.
        /// </summary>
        /// <param name="couponId"> Id of coupon.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="codeAreaPhoneNumber">Code area phone number.</param>
        /// <param name="operatorPhoneNumber">Operator phone.</param>
        public void postRequestCoupon(String couponId, String phone, String codeAreaPhoneNumber, String operatorPhoneNumber)
        {
            connectionManager.postRequestCoupon(couponId, phone, codeAreaPhoneNumber, operatorPhoneNumber);
            connectionManager.getSendRequestCouponCompleted += (s, eventResponseSendRequestCoupon) =>
           {
               JsonObjectSimple jsonObjectSimple = null;
               ParserJsonObjectSimple parserJosnObjectSimple = new ParserJsonObjectSimple();
               Boolean sendCoupon = false;

               if (eventResponseSendRequestCoupon != null)
               {
                   String result = new StreamReader(eventResponseSendRequestCoupon.getResponse()).ReadToEnd();
                   //parseo de los datos
                   jsonObjectSimple = parserJosnObjectSimple.json_parser_ObjectSimple(eventResponseSendRequestCoupon.getResponse());

                   Deployment.Current.Dispatcher.BeginInvoke(() =>
                   {

                       if (jsonObjectSimple.getValue().Equals("Cupon enviado con exito!"))//no se produjo error y respondio correctamente
                       {
                           sendCoupon = true;

                           getDataCompleted(this, new EventResponseData(sendCoupon));//genero un evento de respuesta con los datos solicitados
                       }
                       else
                       {
                           //ocurrio un error con el codigo en la respuesta
                           getDataCompleted(this, new EventResponseData(sendCoupon));//genero un evento de respuesta con los datos solicitados
                       }
                   });
               }

           };
            getDataCompleted = null;
        }

        public void postSaveToken(String os, String token)
        {
            connectionManager.postSaveToken(os, token);
            connectionManager.getSendRequestCouponCompleted += (s, eventResponseSaveToken) =>
            {
                JsonObjectStatusSaveToken jsonObjectStatusSaveToken = new JsonObjectStatusSaveToken();
                ParserJsonObjectSaveToken parserJosnObjectSaveToken = new ParserJsonObjectSaveToken();
                Boolean saveToken = false;

                if (eventResponseSaveToken != null)
                {
                    String result = new StreamReader(eventResponseSaveToken.getResponse()).ReadToEnd();
                    //parseo de los datos
                    jsonObjectStatusSaveToken = parserJosnObjectSaveToken.json_parser_ObjectSaveToken(eventResponseSaveToken.getResponse());

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (jsonObjectStatusSaveToken.getValue() != null)
                        {
                            if (jsonObjectStatusSaveToken.getValue().Equals(1))//no se produjo error y respondio correctamente
                            {
                                saveToken = true;
                            }
                        }
                        //no genero respuesta ya que no se debe realizar ninguna accion
                        //getDataCompleted(this, new EventResponseData(saveToken));//genero un evento de respuesta con los datos solicitados
                    });
                }

            };
            getDataCompleted = null;
        }

        /// <summary>
        /// carga los datos del usuario en caso de que la respuesta sea afirmativa.
        /// </summary>
        /// <param name="rootcheckCode">Datos del usuario para</param>
        /// <param name="dataAuxUser"></param>
        private void loadUser(RootCheckCode rootcheckCode, List<String> dataAuxUser)
        {
            User user = new User();
            if (rootcheckCode != null)
            {
                user.setCompany(rootcheckCode.data.company);
                user.setMember(rootcheckCode.data.member);
                user.getMember().phoneOperator = ManagerUser.getInstance().getUser().getMember().phoneOperator;
                user.setFilters(ManagerUser.getInstance().getUser().getFilter());
                user.getMember().nameMember = ManagerUser.getInstance().getUser().getMember().nameMember;
            }

            ManagerUser.getInstance().setUser(user);
        }

        /// <summary>
        /// Valida si el codigo ingresado por el usuario es el mismo que el enviado en el llamado. 
        /// Genera un evento con un valor que puede ser verdadero o falso.
        /// </summary>
        /// <param name="value"></param>
        public void getCheckNumberSms(String value)
        {
            Boolean checkNumberSms = false;
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (connectionManager.getNumberSms().Equals(value))
                {
                    checkNumberSms = true;
                }
                else
                {
                    //hubo un error en el numero telefonico o en el sms
                }
                getDataCompleted(this, new EventResponseData(checkNumberSms));
                //genero un evento de respuesta con los datos solicitados
            });
        }

        public String getUrlImageCompany(String image)
        {
            return connectionManager.getUrlImageCompany(image);
        }*/
    }
}
