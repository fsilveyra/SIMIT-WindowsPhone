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

namespace Simit.classAux
{
    public class Dialog 
    {

        String message = null;

        public Dialog()
        {
            this.message = "";
        }

        public void setDialog(String menssage)
        {
            this.message = menssage;
        }

        public String getDialog()
        {
            return this.message;
        }

        public void showDialog()
        {
            MessageBox.Show(message, "Simit",MessageBoxButton.OK);
        }

        public MessageBoxResult showDialogOkCancel()
        {
            return MessageBox.Show(message, "Simit", MessageBoxButton.OKCancel);
        }

    }
}
