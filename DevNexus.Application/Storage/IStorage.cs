namespace DevNexus.Application.Storage;

public interface IStorage
{
    /// <summary>
    /// Uploads a file to the storage and returns the file path and full path.
    /// </summary>
    /// <param name="group">
    /// Destination group for the uploaded file. 
    /// Equivalent to folder directory for local storage, 
    /// container (or bucket) for cloud storage.
    /// </param>
    /// <param name="fileName">Need for file extension and unique identifier for deletion process</param>
    /// <param name="stream">Opened file stream</param>
    /// <returns>Short path (group + fileName) of the file. This path will stored at database.</returns>
    Task<string> UploadAsync(string group, string fileName, Stream stream);

    /// <summary>
    /// Returns file data as byte array by its path.
    /// </summary>
    /// <param name="path">Short path (group + fileName) of the file.</param>
    /// <returns>A byte array that represents the file data.</returns>
    Task<byte[]> DownloadAsBytesAsync(string path);

    /// <summary>
    /// Deletes a file from the storage by its path.
    /// </summary>
    /// <param name="path">Short path (group + fileName) of the file.</param>
    Task DeleteAsync(string path);

    public static string GenerateUniqueFileName(string originalFileName)
    {
        // Example: 20230417234539-c21459efd42a78gf.png
        return $"{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N")[..16]}{Path.GetExtension(originalFileName).ToLower()}";
    }
}