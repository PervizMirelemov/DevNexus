using Microsoft.AspNetCore.Http;
using System.Threading;

namespace DevNexus.Infrastructure.Storage;

public interface IFormFileStorage
{
    Task<string> UploadAsync(string folder, IFormFile file, CancellationToken cancellationToken = default);
}