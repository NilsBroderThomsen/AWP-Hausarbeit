using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp112.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Logic.Ui
{
    public class ViewModelLocator
    {
        public PackageCollectionViewModel ThePackageCollectionViewModel { get; set; }
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
        public NewPackageWindowViewModel TheNewPackageWindowViewModel { get; set; }

        public ViewModelLocator()
        {
            var packageCollection = new PackageCollection();

            ThePackageCollectionViewModel =
                new PackageCollectionViewModel(packageCollection);

            TheMainWindowViewModel =
                new MainWindowViewModel(ThePackageCollectionViewModel);

            TheNewPackageWindowViewModel =
                new NewPackageWindowViewModel(ThePackageCollectionViewModel);
        }
    }
}
