using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects
{
    [Serializable]
    public class InstallOptions : INotifyPropertyChanged
    {
        private bool isSilent;
        public bool IsSilent
        {
            get => isSilent;
            set
            {
                isSilent = value;
                OnPropertyChanged(nameof(IsSilent));
            }
        }

        private bool force;
        public bool Force
        {
            get => force;
            set
            {
                force = value;
                OnPropertyChanged(nameof(Force));
            }
        }

        private string scope;
        public string Scope
        {
            get => scope;
            set
            {
                scope = value;
                OnPropertyChanged(nameof(Scope));
            }
        }

        private string location;
        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private string version;
        public string Version
        {
            get => version;
            set
            {
                version = value;
                OnPropertyChanged(nameof(Version));
            }
        }

        private string dependencySource;
        public string DependencySource
        {
            get => dependencySource;
            set
            {
                dependencySource = value;
                OnPropertyChanged(nameof(DependencySource));
            }
        }

        private string customArguments;
        public string CustomArguments
        {
            get => customArguments;
            set
            {
                customArguments = value;
                OnPropertyChanged(nameof(CustomArguments));
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