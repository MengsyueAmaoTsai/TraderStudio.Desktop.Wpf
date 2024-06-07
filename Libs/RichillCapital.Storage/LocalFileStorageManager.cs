using Microsoft.Extensions.Logging;

using RichillCapital.Domain.Common;

namespace RichillCapital.Storage;

internal sealed class LocalFileStorageManager(
    ILogger<ILocalStorageManager> _logger) :
    ILocalStorageManager
{
    private const string RootDirectory = @"C:\Users\mengs";

    public Task ArchiveAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("ArchiveAsync is not implemented.");

        return Task.CompletedTask;
    }

    public async Task CreateAsync(string fileName, string location, Stream stream, CancellationToken cancellationToken = default)
    {
        var filePath = Path.Combine(RootDirectory, location);

        var folder = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        using var fileStream = File.Create(filePath);

        await stream.CopyToAsync(fileStream, cancellationToken);
    }

    public async Task DeleteAsync(string location, CancellationToken cancellationToken = default)
    {
        await Task.Run(
            () =>
            {
                var path = Path.Combine(RootDirectory, location);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }, 
            cancellationToken);
    }

    public Task<byte[]> ReadAsync(string location, CancellationToken cancellationToken = default) =>
        File.ReadAllBytesAsync(Path.Combine(RootDirectory, location), cancellationToken);

    public Task UnArchiveAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("UnArchiveAsync is not implemented.");
        return Task.CompletedTask;
    }
}
