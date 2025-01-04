using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects
{
    [Serializable]
    public class PackageCollection : ObservableCollection<Package>
    {
        public PackageCollection() { }
    }
}