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
using System.IO;

namespace Simit.data
{

    public class EventResponseConnection : EventArgs
    {

        public Stream responseConnection = null;
        public String responseConectionString = null;

        //constructor que utiliza un stream
        public EventResponseConnection(Stream response)
        {
            this.responseConnection = response;
        }

        //constructor que utiliza un string
        public EventResponseConnection(String response)
        {
            this.responseConectionString = response;
        }

        public Stream getResponse()
        {
            
            return this.responseConnection;
        }

        public String getResponseString()
        {
            return this.responseConectionString;
        }

    }
}
