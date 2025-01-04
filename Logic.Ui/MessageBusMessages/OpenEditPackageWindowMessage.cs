using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp112.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp112.Logic.Ui.MessageBusMessages
{
    public class OpenEditPackageWindowMessage
    {
        public static PackageViewModel PackageToEdit { get; private set; }
        public OpenEditPackageWindowMessage(PackageViewModel package)
        {
            PackageToEdit = package;
        }
    }
}

