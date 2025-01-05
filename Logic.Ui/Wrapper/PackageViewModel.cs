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

        public PackageViewModel() : base() {  }

        public PackageViewModel(Package package) : base(package) { }

        public override void NewModelAssigned()
        {
            installOptionsViewModel = new InstallOptionsViewModel(Model.InstallOptions);
        }

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

        public InstallOptionsViewModel InstallOptionsViewModel
        {
            get => installOptionsViewModel;
            set
            {
                installOptionsViewModel = value;
                OnPropertyChanged(nameof(InstallOptionsViewModel));
            }
        }

        public PackageValidationState ValidationState
        {
            get => Model.ValidationState;
            set
            {
                Model.ValidationState = value;
                OnPropertyChanged(nameof(ValidationState));
                OnPropertyChanged(nameof(ValidationStateText));
            }
        }
        public string ValidationStateText
        {
            get
            {
                switch (ValidationState)
                {
                    case PackageValidationState.NotChecked:
                        return "Noch nicht geprüft";
                    case PackageValidationState.Valid:
                        return "Valide";
                    case PackageValidationState.Invalid:
                        return "Ungültig";
                    default:
                        return "Unbekannt";
                }
            }
        }
    }
}