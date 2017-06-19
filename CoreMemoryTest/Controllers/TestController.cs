using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace CoreMemoryTest.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        /// <summary>
        /// Posts a file. Use like this: http://localhost:62774/api/test/UploadFile
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>A http request 200.</returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> PostFileAsync(IFormFile file)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("");

            // Retrieve reference to a blob named as the file.
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(file.FileName);

            using (Stream s = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(s);
            }

            return Ok("Fíle uploaded");
        }
    }
}
