using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp112.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PackageCollectionViewModel packages;
        public PackageCollectionViewModel Packages
        {
            get => packages;
            set
            {
                packages = value;
                OnPropertyChanged(nameof(Packages));
            }
        }
        private PackageViewModel selectedPackage;
        public PackageViewModel SelectedPackage
        {
            get => selectedPackage;
            set
            {
                selectedPackage = value;
                OnPropertyChanged(nameof(SelectedPackage));
            }
        }

        // Commands
        public ICommand OpenNewPackageWindowCommand { get; }
        public ICommand ImportScriptCommand { get; }
        public ICommand ExportScriptCommand { get; }

        public MainWindowViewModel(PackageCollectionViewModel collectionVm)
        {
            Packages = collectionVm;

            OpenNewPackageWindowCommand = new RelayCommand(OpenNewPackageWindowMethode);
            ImportScriptCommand = new RelayCommand(() => ImportScript());
            ExportScriptCommand = new RelayCommand(() => ExportScript());
        }

        private void OpenNewPackageWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenNewPackageWindowMessage());
        }

        private void ImportScript()
        {
        }

        private void ExportScript()
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}