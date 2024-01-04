using System.ComponentModel.DataAnnotations;

namespace FileStoreApi.Models
{
    public class UploadFileDto
    {
        [Required]
        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}
