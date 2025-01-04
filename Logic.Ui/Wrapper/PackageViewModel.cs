using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp112.Logic.Ui.Base;

namespace De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper
{
    public class PackageViewModel
        : ViewModelBase<Package>, INotifyPropertyChanged
    {
        private InstallOptionsViewModel installOptionsViewModel;

        public PackageViewModel() : base()
        {
            // Da der parameterlose Basiskonstruktor 'Model = new Package()' auslöst,
            // können wir in NewModelAssigned() die Zuweisung an installOptionsViewModel machen.
        }

        public PackageViewModel(Package package) : base(package)
        {
            // Hier legen wir das Model fest, dann 
            // wird auch NewModelAssigned() aufgerufen.
        }

        public override void NewModelAssigned()
        {
            // Wenn Model zugewiesen wird, legen wir 
            // das InstallOptionsViewModel neu an:
            installOptionsViewModel = new InstallOptionsViewModel(Model.InstallOptions);
        }

        // Beispiel-Properties
        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string PackageId
        {
            get => Model.PackageId;
            set
            {
                Model.PackageId = value;
                OnPropertyChanged(nameof(PackageId));
            }
        }

        public string Category
        {
            get => Model.Category;
            set
            {
                Model.Category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        // Zugriff auf das InstallOptionsViewModel 
        public InstallOptionsViewModel InstallOptionsViewModel
        {
            get => installOptionsViewModel;
            set
            {
                installOptionsViewModel = value;
                OnPropertyChanged(nameof(InstallOptionsViewModel));
            }
        }
    }
}