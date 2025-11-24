using Microsoft.AspNetCore.Http;

namespace DevNexus.Application.Storage;

public interface IFormFileStorage : IStorage
{
    /// <param name="group">
    /// Destination group for the uploaded file. 
    /// Equivalent to folder directory for local storage,
    /// container (or bucket) for cloud storage.
    /// </param>
    Task<string> UploadAsync(string group, IFormFile formFile);

    /// <param name="group">
    /// Destination group for the uploaded file. 
    /// Equivalent to folder directory for local storage, 
    /// container (or bucket) for cloud storage.
    /// </param>
    Task<string[]> UploadAsync(string group, IEnumerable<IFormFile> formFiles);
}
