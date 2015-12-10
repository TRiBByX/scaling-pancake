using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace scaling_pancake
{
    class PersistenceFacade
    {
        public static async void SerializeObjectsFileAsync(string objectsString, string fileName)
        {       
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, objectsString);
        }

        public static async Task<string> DeSerializeObjectsFileAsync(string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);           
        }
    }
}
