using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects
{
    [Serializable]
    public class Package : INotifyPropertyChanged
    {
        private PackageValidationState validationState = PackageValidationState.NotChecked;
        public PackageValidationState ValidationState
        {
            get => validationState;
            set
            {
                validationState = value;
                OnPropertyChanged(nameof(ValidationState));
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string packageId;
        public string PackageId
        {
            get => packageId;
            set
            {
                packageId = value;
                OnPropertyChanged(nameof(PackageId));
            }
        }

        private InstallOptions installOptions = new InstallOptions();
        public InstallOptions InstallOptions
        {
            get => installOptions;
            set
            {
                installOptions = value;
                OnPropertyChanged(nameof(InstallOptions));
            }
        }

        private string category;
        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}