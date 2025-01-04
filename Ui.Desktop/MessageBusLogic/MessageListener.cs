using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp112.Ui.Desktop.MessageBusLogic
{
    class MessageListener
    {
        private Window myWindow;
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }
        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenNewPackageWindowMessage>
                (this, OpenNewPackageWindow);
        }

        private void OpenNewPackageWindow()
        {
            myWindow = new NewPackageWindow();
            myWindow.ShowDialog();
        }
    }
}