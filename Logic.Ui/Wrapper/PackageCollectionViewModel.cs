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
        public PackageCollectionViewModel() : base()
        {
            // Basiskonstruktor legt eine neue leere 
            // PackageCollection (Model) an und synchronisiert.
        }

        public PackageCollectionViewModel(PackageCollection modelCollection)
            : base(modelCollection)
        {
            // Falls wir eine vorhandene PackageCollection übergeben
            // wollen, z.B. beim Laden aus Datei.
        }

        public override void NewModelAssigned()
        {
            // Wird gerufen, wenn das Model (PackageCollection) 
            // komplett neu gesetzt wird. 
            // Hier könntest du z.B. was initialisieren oder 
            // sortieren. Standard: Nichts tun.
        }
    }
}