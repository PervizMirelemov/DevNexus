// Add this using to reference the interface from Application layer
using DevNexus.Application.Storage;
using Microsoft.AspNetCore.Hosting;

namespace DevNexus.Infrastructure.Storage;

public class LocalFileStorage(IWebHostEnvironment environment) : IStorage
{
    private readonly string _webRootPath = environment.WebRootPath; // wwwroot path

    public Task<string> UploadAsync(string group, string fileName, Stream stream)
    {
        string folder = Path.Combine(_webRootPath, group);
        Directory.CreateDirectory(folder);

        fileName = IStorage.GenerateUniqueFileName(fileName);
        string path = Path.Combine(folder, fileName); // wwwroot/group/20230417234539-c21459efd42a78gf.ext
        using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write);
        stream.CopyTo(fileStream);

        string dbPath = Path.Combine(group, fileName).Replace("\\", "/"); // group/20230417234539-c21459efd42a78gf.ext
        return Task.FromResult(dbPath);
    }

    public Task<byte[]> DownloadAsBytesAsync(string path)
    {
        string filePath = Path.Combine(_webRootPath, path);
        if (File.Exists(filePath))
            return File.ReadAllBytesAsync(filePath);

        return Task.FromResult(Array.Empty<byte>());
    }

    public Task DeleteAsync(string path)
    {
        string filePath = Path.Combine(_webRootPath, path);
        if (File.Exists(filePath))
            File.Delete(filePath);
        return Task.CompletedTask;
    }
}
