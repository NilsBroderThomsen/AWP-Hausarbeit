using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using System.IO;
using System.Xml.Serialization;

namespace De.HsFlensburg.ClientApp112.Services.SerializationService
{
    public class XmlImportExportService
    {
        public void ExportXml(PackageCollection packages, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PackageCollection));
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, packages);
            }
        }

        public PackageCollection ImportXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PackageCollection));
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                return (PackageCollection)serializer.Deserialize(fs);
            }
        }
    }
}
