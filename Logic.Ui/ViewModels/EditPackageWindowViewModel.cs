using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;
using System.ComponentModel;
using System.Windows.Input;
using De.HsFlensburg.ClientApp112.Services.MessageBus;
using De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages;

namespace De.HsFlensburg.ClientApp112.Logic.Ui.ViewModels
{
    public class EditPackageWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PackageViewModel package;
        public PackageViewModel Package
        {
            get => package;
            set
            {
                package = value;
                OnPropertyChanged(nameof(Package));
            }
        }

        // Commands
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        // Konstruktor nimmt das zu bearbeitende PackageViewModel
        public EditPackageWindowViewModel(PackageViewModel packageToEdit)
        {
            this.Package = packageToEdit;

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            // Wir ändern das existierende Package direkt
            // (Kein Hinzufügen zur Liste, existiert ja schon)
            // Fenster schließen
            ServiceBus.Instance.Send(new CloseEditPackageWindowMessage());
        }

        private void Cancel()
        {
            // Fenster schließen, ohne die Änderungen rückgängig zu machen
            // (Die Änderungen wurden schon an das Objekt gebunden,
            //  bei Bedarf müsstest du manuell einen 'Refresh' oder 'Clone' machen)
            ServiceBus.Instance.Send(new CloseEditPackageWindowMessage());
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
