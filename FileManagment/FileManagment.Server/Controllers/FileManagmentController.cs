using FileManagment.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileManagment.Server.Controllers
{
    [Route("api/fileManagment")]
    [ApiController]
    public class FileManagmentController : ControllerBase
    {
        private IStorageService _storageService;
        public FileManagmentController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("creatFolder")]
        public async Task CreatFolder(string folderPath)
        {
            await _storageService.CreatFolder(folderPath);
        }

        [HttpPost("uploadFile")]
        public async Task UploadFile(IFormFile file, string? folderPath)
        {
            folderPath = folderPath ?? string.Empty;
            var filePath = file.FileName;

            using(var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                await _storageService.UploadFile(folderPath, stream);
            }
        }

        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageService.DeleteFile(filePath);
        }

        [HttpDelete("deleteFolder")]
        public async Task DeleteFolder(string folderPath)
        {
            await _storageService.DeleteFolder(folderPath);
        }

        [HttpGet("downLoadFile")]
        public async Task<FileStreamResult> DownLoadFile(string filePath)
        {
            var stream = await _storageService.DownLoadFile(filePath);

            var res = new FileStreamResult(stream, "aplication/octant-file") 
            {
                FileDownloadName = filePath
            };

            return res;
        }

        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadFolderAsZip(string folderPath)
        {
            var stream = await _storageService.DownLoadFolderAsZip(folderPath);

            var res = new FileStreamResult(stream, "aplication/octant-file")
            {
                FileDownloadName = folderPath + ".zip"
            };

            return res;
        }

        [HttpGet("getContentOfTxtFile")]
        public async Task<string> GetContextOfTxtFile(string path)
        {
            return await _storageService.GetContentOfTxtFile(path);
        }

        [HttpPut("updateContentOfTxtFile")]
        public async Task UpdateContentOfTxtFile(string filePath, string newContent)
        {
            await _storageService.UpdateContentOfTxtFile(filePath, newContent);
        }

        [HttpGet("getAllInFolderPath")]
        public async Task<List<string>> GetAllInFolderPath(string? folderPath)
        {
            folderPath = folderPath ?? string.Empty;
            return await _storageService.GetAllInFolderPath(folderPath);
        }

        [HttpPost("uploadFileWithChunks")]
        public async Task UploadFileWithChunks(IFormFile file, string? folderPath)
        {
            folderPath = folderPath ?? string.Empty;
            using (var stream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
            {
                await _storageService.UploadFileWithChunks(folderPath, stream);
            }
        }
    }
}
