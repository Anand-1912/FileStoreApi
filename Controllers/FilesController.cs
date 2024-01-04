using FileStoreApi.Models;
using FileStoreApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FileStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IByteStoreClient _byteStoreClient;
        public FilesController(IByteStoreClient byteStoreClient)
        {
            _byteStoreClient = byteStoreClient;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([Required][FromBody] UploadFileDto dto)
        {
            try
            {
                var blobName = $"testFile{Guid.NewGuid().ToString()}.txt";

                var containerName = $"testcontainer";

                await _byteStoreClient.UploadBytes(dto.Data, blobName, containerName);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
