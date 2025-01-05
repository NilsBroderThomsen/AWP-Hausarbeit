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

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditPackageWindowViewModel(PackageViewModel packageToEdit)
        {
            this.Package = packageToEdit;
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            ServiceBus.Instance.Send(new CloseEditPackageWindowMessage());
        }

        private void Cancel()
        {
            ServiceBus.Instance.Send(new CloseEditPackageWindowMessage());
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
