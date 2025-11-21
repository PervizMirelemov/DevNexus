using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace DevNexus.Infrastructure.Storage;

public class LocalFileStorage : IFormFileStorage
{
    private readonly IWebHostEnvironment _env;

    public LocalFileStorage(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> UploadAsync(string folder, IFormFile file, CancellationToken cancellationToken = default)
    {
        var wwwRoot = Path.Combine(_env.ContentRootPath, "wwwroot");
        var targetDir = Path.Combine(wwwRoot, folder);

        if (!Directory.Exists(targetDir))
            Directory.CreateDirectory(targetDir);

        var fileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(targetDir, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var relativePath = Path.Combine(folder, fileName).Replace("\\", "/");
        return "/" + relativePath;
    }
}