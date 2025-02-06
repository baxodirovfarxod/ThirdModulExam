namespace FileManagment.StorageBroker;
public interface IStorageBroker
{
    Task CreatFolder(string folderPath);
    Task UploadFile(string folderPath, Stream stream);
    Task UploadFileWithChunks(string folderPath, Stream stream);
    Task DeleteFile(string filePath);
    Task DeleteFolder(string folderPath);
    Task<Stream> DownLoadFile(string filePath);
    Task<Stream> DownLoadFolderAsZip(string filePath);
    Task<string> GetContentOfTxtFile(string filePath);
    Task UpdateContentOfTxtFile(string filePath, string newContent);
    Task<List<string>> GetAllInFolderPath(string folderPath);
}
