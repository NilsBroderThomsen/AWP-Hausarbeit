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
    public class InstallOptionsViewModel
        : ViewModelBase<InstallOptions>, INotifyPropertyChanged
    {
        public InstallOptionsViewModel() : base() { }
        public InstallOptionsViewModel(InstallOptions model) : base(model) { }
        public override void NewModelAssigned() { }

        public bool IsSilent
        {
            get => Model.IsSilent;
            set
            {
                Model.IsSilent = value;
                OnPropertyChanged(nameof(IsSilent));
            }
        }

        public bool Force
        {
            get => Model.Force;
            set
            {
                Model.Force = value;
                OnPropertyChanged(nameof(Force));
            }
        }

        public string Scope
        {
            get => Model.Scope;
            set
            {
                Model.Scope = value;
                OnPropertyChanged(nameof(Scope));
            }
        }

        public string Location
        {
            get => Model.Location;
            set
            {
                Model.Location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public string Version
        {
            get => Model.Version;
            set
            {
                Model.Version = value;
                OnPropertyChanged(nameof(Version));
            }
        }

        public string DependencySource
        {
            get => Model.DependencySource;
            set
            {
                Model.DependencySource = value;
                OnPropertyChanged(nameof(DependencySource));
            }
        }

        public string CustomArguments
        {
            get => Model.CustomArguments;
            set
            {
                Model.CustomArguments = value;
                OnPropertyChanged(nameof(CustomArguments));
            }
        }
    }
}