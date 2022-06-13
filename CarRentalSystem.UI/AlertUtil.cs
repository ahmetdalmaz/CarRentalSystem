using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.UI
{
    public static class AlertUtil
    {
        public static void Show(string message, FormAlert.MessageType messageType) 
        {
            FormAlert alert = new FormAlert();
            alert.ShowAlert(message, messageType);
        }
    }
}
