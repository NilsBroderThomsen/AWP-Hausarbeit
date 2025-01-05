using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using De.HsFlensburg.ClientApp112.Logic.Ui.ViewModels;

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
            ServiceBus.Instance.Register<OpenNewPackageWindowMessage>(this, OpenNewPackageWindow);
            ServiceBus.Instance.Register<CloseNewPackageWindowMessage>(this, CloseNewPackageWindow);
            ServiceBus.Instance.Register<OpenEditPackageWindowMessage>(this, OpenEditPackageWindow);
            ServiceBus.Instance.Register<CloseEditPackageWindowMessage>(this, CloseEditPackageWindow);
        }

        private void OpenNewPackageWindow()
        {
            myWindow = new NewPackageWindow();
            myWindow.Owner = Application.Current.MainWindow;
            myWindow.ShowDialog();
        }
        private void CloseNewPackageWindow()
        {
            myWindow.Close();
        }

        private void OpenEditPackageWindow()
        {
            var packageVm = OpenEditPackageWindowMessage.PackageToEdit;

            myWindow = new EditPackageWindow();
            myWindow.Owner = Application.Current.MainWindow;
            myWindow.DataContext = new EditPackageWindowViewModel(packageVm);
            myWindow.ShowDialog();
        }
        private void CloseEditPackageWindow()
        {
            myWindow.Close();
        }
    }
}