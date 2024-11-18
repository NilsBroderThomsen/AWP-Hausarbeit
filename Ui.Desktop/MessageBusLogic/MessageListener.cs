using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Ui.Desktop.MessageBusLogic
{
    class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }
        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>
                (this, OpenNewClientWindow
                );
        }
        private void OpenNewClientWindow()
        {
            NewClientWindow myWindow = new NewClientWindow();
            myWindow.ShowDialog();
        }
    }
}
