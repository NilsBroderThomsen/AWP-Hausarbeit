using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp112.Logic.Ui.Base;


namespace De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper
{
    public class PackageCollectionViewModel
        : ViewModelSyncCollection<PackageViewModel, Package, PackageCollection>,
          INotifyPropertyChanged
    {
        public PackageCollectionViewModel() : base() { }

        public PackageCollectionViewModel(PackageCollection modelCollection) : base(modelCollection) { }

        public override void NewModelAssigned() { }
    }
}