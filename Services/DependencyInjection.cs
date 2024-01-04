using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileStoreApi.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddByteStoreClient(this IServiceCollection service, ConfigurationManager configuration)
        {

            var useManagedIdentity = Boolean.Parse(configuration.GetSection("UseManagedIdentity").Value);
                                        

            return service
                .AddSingleton<IByteStoreClient, ByteStoreClient>()
                .AddSingleton(ctx =>
                {
                    if (useManagedIdentity)

                    {
                        return
                        new BlobServiceClient(
                        new Uri(@"https://safordotnetintegration.blob.core.windows.net/"),
                        new DefaultAzureCredential()
                        );
                    }
                    else
                    {
                        return
                        new BlobServiceClient(
                        "DefaultEndpointsProtocol=https;AccountName=safordotnetintegration;AccountKey=oRpO/zG1wXyh+JEUTdl+VDq5X2ZxLJfNmFZHSGByxjzkzfYotEMJ9XVxmzpOAiXr5O/yhMhSzqrH+AStXa3l7w==;EndpointSuffix=core.windows.net"
                        );
                    }
                });
        }
    }
}
