namespace FileStoreApi.Services
{
    public interface IByteStoreClient
    {
        Task UploadBytes(byte[] bytes, string blobName, string containerName);
    }
}