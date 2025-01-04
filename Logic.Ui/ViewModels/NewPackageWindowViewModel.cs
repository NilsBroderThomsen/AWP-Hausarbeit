using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;
using System.Windows.Input;

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

        // Commands
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public NewPackageWindowViewModel(PackageCollectionViewModel packageCollection)
        {
            this.packageCollection = packageCollection;
            this.NewPackage = new PackageViewModel();

            ConfirmCommand = new RelayCommand(() => Confirm());
            CancelCommand = new RelayCommand(() => Cancel());
        }

        private void Confirm()
        {
            // Füge das neue Package in die Liste ein
            packageCollection.Add(NewPackage);

            // Evtl. Fenster schließen -> In "reinem" MVVM macht man das
            // per MessageBus/ Event. 
        }

        private void Cancel()
        {
            // Abbrechen -> Fenster schließen. 
            // Wieder: per MessageBus/ Event?
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}