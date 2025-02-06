
using FileManagment.StorageBroker;

namespace FileManagment.Service.Services;
public class StorageService : IStorageService
{
    private readonly IStorageBroker _storageBroker;
    public StorageService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }
    public async Task CreatFolder(string folderPath)
    {
        await _storageBroker.CreatFolder(folderPath);
    }

    public async Task DeleteFile(string filePath)
    {
        await _storageBroker.DeleteFile(filePath);
    }

    public async Task DeleteFolder(string folderPath)
    {
        await _storageBroker.DeleteFolder(folderPath);
    }

    public async Task<Stream> DownLoadFile(string filePath)
    {
        return await _storageBroker.DownLoadFile(filePath);
    }

    public async Task<Stream> DownLoadFolderAsZip(string filePath)
    {
        return await _storageBroker.DownLoadFolderAsZip(filePath);
    }

    public async Task<List<string>> GetAllInFolderPath(string folderPath)
    {
        return await _storageBroker.GetAllInFolderPath(folderPath);
    }

    public async Task<string> GetContentOfTxtFile(string filePath)
    {
        return await _storageBroker.GetContentOfTxtFile(filePath);
    }

    public async Task UpdateContentOfTxtFile(string filePath, string newContent)
    {
        await _storageBroker.UpdateContentOfTxtFile(filePath, newContent);
    }

    public async Task UploadFile(string folderPath, Stream stream)
    {
        await _storageBroker.UploadFile(folderPath, stream);
    }

    public async Task UploadFileWithChunks(string folderPath, Stream stream)
    {
        await _storageBroker.UploadFileWithChunks(folderPath, stream);  
    }
}
