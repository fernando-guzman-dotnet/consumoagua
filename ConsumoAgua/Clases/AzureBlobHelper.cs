using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public class azureBlobHelper
{

    private const string accountName = "jdstoragesb";
    private const string accountKey = "mfEe4XfGiFryAMk133srD5snOKmz3xYca43KK1h3WKXyikzagPWdztUJgzNmT8tI1S6dwe2iFuNEFF0OVt67yA==";
    private const string containerName = "consumoagua-storage";

    #region inicializacion de objetos y configuracion
    private static CloudBlobContainer container
    {
        get
        {

            if (_container != null)
                return _container;

            StringBuilder dtrB = new StringBuilder();
            dtrB.Append("DefaultEndpointsProtocol=https;");
            dtrB.Append("AccountName=" + accountName + ";");
            dtrB.Append("AccountKey=" + accountKey + ";");
            dtrB.Append("EndpointSuffix=core.windows.net");
            string strorageconn = dtrB.ToString();

            storageacc = CloudStorageAccount.Parse(strorageconn);
            blobClient = storageacc.CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return _container;

        }
    }
    private static CloudStorageAccount storageacc { get; set; }
    private static CloudBlobClient blobClient { get; set; }
    private static CloudBlobContainer _container { get; set; }
    #endregion

    /// <summary>
    /// NOMBRE DE CARPETAS DENTRO DE EL BLOB
    /// </summary>
    public enum BlobFolders
    {
        ArchivosContratos,
    }

    public static bool deleteFile(string guidArchivo, BlobFolders folder, string subFolder = null)
    {
        string _folder = folder.ToString();

        CloudBlockBlob blockBlob;

        if (string.IsNullOrWhiteSpace(subFolder))
            blockBlob = container.GetBlockBlobReference($"{_folder}/{guidArchivo}");
        else
            blockBlob = container.GetBlockBlobReference($"{_folder}/{subFolder}/{guidArchivo}");

        blockBlob.Delete();

        return !blockBlob.Exists();
    }

    public static string uploadFile(string filePath, BlobFolders folder, string subFolder = null)
    {
        string _folder = folder.ToString();
        string name = Guid.NewGuid().ToString();

        CloudBlockBlob blockBlob;

        if (string.IsNullOrWhiteSpace(subFolder))
            blockBlob = container.GetBlockBlobReference($"{_folder}/{name}");
        else
            blockBlob = container.GetBlockBlobReference($"{_folder}/{subFolder}/{name}");

        using (var filestream = File.OpenRead(filePath))
            blockBlob.UploadFromStream(filestream);

        if (blockBlob.Exists())
            return name;

        return null;
    }

    public static bool downloadFile(string guidArchivo, string targetPath, BlobFolders folder, string subFolder = null)
    {
        bool descargado = false;

        try
        {
            string directory = Path.GetDirectoryName(targetPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);


            string _folder = folder.ToString();

            CloudBlockBlob blockBlob;

            if (string.IsNullOrWhiteSpace(subFolder))
                blockBlob = container.GetBlockBlobReference($"{_folder}/{guidArchivo}");
            else
                blockBlob = container.GetBlockBlobReference($"{_folder}/{subFolder}/{guidArchivo}");


            using (var filestream = File.OpenWrite(targetPath)) 
                blockBlob.DownloadToStream(filestream);

            descargado = File.Exists(targetPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"downloadFile - {ex.Message}","Clase AzureBlobHelper");
        }

        return descargado;
    }
}
