using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;
using System.Threading;

namespace De.HsFlensburg.ClientApp112.Logic.Ui.ViewModels
{
    public class NewPackageWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly PackageCollectionViewModel packageCollection;
        private PackageViewModel newPackage;
        public PackageViewModel NewPackage
        {
            get => newPackage;
            set
            {
                newPackage = value;
                OnPropertyChanged(nameof(NewPackage));
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public NewPackageWindowViewModel(PackageCollectionViewModel packageCollection)
        {
            this.packageCollection = packageCollection;
            Reset();
            ConfirmCommand = new RelayCommand(() => Confirm());
            CancelCommand = new RelayCommand(() => Cancel());
        }

        private void Reset()
        {
            this.NewPackage = new PackageViewModel();
        }

        private void Confirm()
        {
            packageCollection.Add(NewPackage);
            ServiceBus.Instance.Send(new CloseNewPackageWindowMessage());
            Reset();
        }

        private void Cancel()
        {
            ServiceBus.Instance.Send(new CloseNewPackageWindowMessage());
            Reset();
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}