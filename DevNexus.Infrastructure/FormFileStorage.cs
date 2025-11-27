using DevNexus.Application.Storage;
using Microsoft.AspNetCore.Http;

namespace BakuCityKarting.Infrastructure.Storage;

public class FormFileStorage(IStorage _storage) : IFormFileStorage
{
    public Task DeleteAsync(string path) => _storage.DeleteAsync(path);

    public Task<byte[]> DownloadAsBytesAsync(string path) => _storage.DownloadAsBytesAsync(path);

    public Task<string> UploadAsync(string group, string fileName, Stream stream) => _storage.UploadAsync(group, fileName, stream);

    public Task<string> UploadAsync(string group, IFormFile formFile) => _storage.UploadAsync(group, formFile.FileName, formFile.OpenReadStream());

    public Task<string[]> UploadAsync(string group, IEnumerable<IFormFile> formFiles)
    {
        var uploadTasks = formFiles.Select(file => UploadAsync(group, file));
        return Task.WhenAll(uploadTasks);
    }
}
