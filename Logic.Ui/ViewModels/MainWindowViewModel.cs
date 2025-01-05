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
using De.HsFlensburg.ClientApp112.Services.SerializationService;
using Microsoft.Win32;
using De.HsFlensburg.ClientApp112.Services.ScriptExport;
using De.HsFlensburg.ClientApp112.Services.ValidationService;
using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp112.Services;
using System.IO;

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
                (OpenEditPackageWindowCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private readonly WingetValidationService validationService = new WingetValidationService();

        public ICommand OpenNewPackageWindowCommand { get; }
        public ICommand OpenEditPackageWindowCommand { get; }
        public ICommand ValidateCommand { get; }
        public ICommand ImportScriptCommand { get; }
        public ICommand ExportScriptCommand { get; }

        public MainWindowViewModel(PackageCollectionViewModel collectionVm)
        {
            Packages = collectionVm;
            OpenNewPackageWindowCommand = new RelayCommand(OpenNewPackageWindowMethode);
            OpenEditPackageWindowCommand = new RelayCommand(EditPackageMethode, CanEditPackage);
            ValidateCommand = new RelayCommand(ValidateMethode);
            ImportScriptCommand = new RelayCommand(ImportScriptMethode);
            ExportScriptCommand = new RelayCommand(ExportScriptMethode);
        }

        private void OpenNewPackageWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenNewPackageWindowMessage());
        }

        private void EditPackageMethode()
        {
            ServiceBus.Instance.Send(new OpenEditPackageWindowMessage(SelectedPackage));
        }

        private bool CanEditPackage()
        {
            return SelectedPackage != null;
        }
        private void ValidateMethode()
        {
            if (SelectedPackage == null || string.IsNullOrWhiteSpace(SelectedPackage.PackageId))
            {
                System.Windows.MessageBox.Show("Bitte ein Package auswählen oder eine gültige PackageId angeben.");
                return;
            }

            bool isValid = validationService.ValidatePackageId(
                SelectedPackage.PackageId,
                out string message);

            if (isValid)
            {
                SelectedPackage.ValidationState = PackageValidationState.Valid;
            }
            else
            {
                SelectedPackage.ValidationState = PackageValidationState.Invalid;
            }
            System.Windows.MessageBox.Show(message);
        }

        private void ImportScriptMethode()
        {
            string defaultDir = PathHelper.GetAwpAppDataDirectory();
            Directory.CreateDirectory(defaultDir);

            var dialog = new OpenFileDialog
            {
                Title = "XML-Datei impoSrtieren",
                Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*",
                InitialDirectory = defaultDir
            };

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filePath = dialog.FileName;
                var xmlService = new XmlImportExportService();
                var imported = xmlService.ImportXml(filePath);

                Packages.Model = imported;
            }
        }

        private void ExportScriptMethode()
        {
            string defaultDir = PathHelper.GetAwpAppDataDirectory();
            Directory.CreateDirectory(defaultDir);

            var dialog = new SaveFileDialog
            {
                Title = "Winget Script / XML exportieren",
                Filter = "Batch File (*.bat)|*.bat|Text File (*.txt)|*.txt|XML File (*.xml)|*.xml|All Files (*.*)|*.*",
                FileName = "winget-install.bat",
                InitialDirectory = defaultDir
            };

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filePath = dialog.FileName;
                string extension = System.IO.Path.GetExtension(filePath).ToLower();

                if (extension == ".bat" || extension == ".txt")
                {
                    var exportService = new ScriptExportService();
                    exportService.ExportAsWingetScript(Packages.Model, filePath);
                }
                else if (extension == ".xml")
                {
                    var xmlService = new XmlImportExportService();
                    xmlService.ExportXml(Packages.Model, filePath);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}