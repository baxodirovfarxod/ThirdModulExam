
using System.IO.Compression;
using System.Security.Cryptography;

namespace FileManagment.StorageBroker;
public class LocalStorageBroker : IStorageBroker
{
    private readonly string _basePath;
    public LocalStorageBroker()
    {
        _basePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
    }
    public async Task CreatFolder(string folderPath)
    {
        folderPath = Path.Combine(_basePath, folderPath);
        if (Directory.Exists(folderPath))
        {
            throw new Exception("This folder already created");
        }

        Directory.CreateDirectory(folderPath);
    }

    public async Task DeleteFile(string filePath)
    {
        filePath = Path.Combine(_basePath, filePath);

        if (!File.Exists(filePath))
            throw new Exception("File not found !");

        File.Delete(filePath);
    }

    public async Task DeleteFolder(string folderPath)
    {
        folderPath = Path.Combine(_basePath, folderPath);

        if (!Directory.Exists(folderPath))
            throw new Exception("Folder not found");

        Directory.Delete(folderPath, true);
    }

    public async Task<Stream> DownLoadFile(string filePath)
    {
        filePath = Path.Combine(_basePath, filePath);

        if (!File.Exists(filePath))
            throw new Exception("File not found");

        var parent = Directory.GetParent(filePath);
        if (!Directory.Exists(parent.FullName))
            throw new Exception("Parent folder not found");

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return stream;
    }

    public async Task<Stream> DownLoadFolderAsZip(string folderPath)
    {
        if (Path.GetExtension(folderPath) != string.Empty)
            throw new Exception("This not folder");

        folderPath = Path.Combine(_basePath, folderPath);
        if (!Directory.Exists(folderPath))
            throw new Exception("This folder not found");

        var zipPath = folderPath + ".zip";
        ZipFile.CreateFromDirectory(folderPath, zipPath);

        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);

        return stream;
    }

    public async Task<List<string>> GetAllInFolderPath(string folderPath)
    {
        folderPath = Path.Combine(_basePath, folderPath);

        if (!Directory.Exists(folderPath))
            throw new Exception("This folder not found");

        var parent = Directory.GetParent(folderPath);
        if (!Directory.Exists(parent.FullName))
            throw new Exception("Parent not found");

        var allFoldersAndFile = Directory.GetFileSystemEntries(folderPath);

        return allFoldersAndFile.Select(file => file.Remove(0, folderPath.Length + 1)).ToList();
    }

    public async Task<string> GetContentOfTxtFile(string filePath)
    {
        filePath = Path.Combine(_basePath, filePath);
        if (!File.Exists(filePath))
            throw new Exception("This file not found");

        var content = File.ReadAllText(filePath);

        return content;
    }

    public async Task UpdateContentOfTxtFile(string filePath, string newContent)
    {
        filePath = Path.Combine(_basePath, filePath);
        if (!File.Exists(filePath))
            throw new Exception("This file not found");

        File.WriteAllText(filePath, newContent);
    }

    public async Task UploadFile(string folderPath, Stream stream)
    {
        folderPath = Path.Combine(_basePath, folderPath);
        if (!Directory.Exists(folderPath))
            throw new Exception("Folder not found");

        using (var fileStream = new FileStream(folderPath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
    }

    public async Task UploadFileWithChunks(string folderPath, Stream stream)
    {
        folderPath = Path.Combine(_basePath, folderPath);

        var bytes = new byte[1024 * 1024 * 2];

        using (var folderStream = new FileStream(folderPath, FileMode.Create, FileAccess.Write))
        {
            while (true)
            {

            }
        }
    }
}
