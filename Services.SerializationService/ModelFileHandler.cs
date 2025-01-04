using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace De.HsFlensburg.ClientApp112.Services.SerializationService
{
    public class ModelFileHandler
    {
        public PackageCollection ReadModelFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream streamLoad = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                PackageCollection loadedCollection =
                    (PackageCollection)formatter.Deserialize(streamLoad);
                return loadedCollection;
            }
        }

        public void WriteModelToFile(string path, PackageCollection model)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(
                path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                formatter.Serialize(stream, model);
            }
        }
    }
}
