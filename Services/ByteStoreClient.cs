using Azure.Storage.Blobs;

namespace FileStoreApi.Services
{
    public class ByteStoreClient : IByteStoreClient
    {
        private readonly BlobServiceClient _blobServiceClient;
        public ByteStoreClient(BlobServiceClient blobServiceClient)
        {
            this._blobServiceClient = blobServiceClient;
        }
        public async Task UploadBytes(byte[] bytes, string blobName, string containerName)
        {

            try
            {

                BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

                using (var stream = new MemoryStream(bytes))
                {
                    await blobClient.UploadAsync(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
