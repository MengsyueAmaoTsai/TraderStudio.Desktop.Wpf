namespace RichillCapital.Domain.Common;

public interface ILocalStorageManager
{
    Task CreateAsync(string fileName, string location, Stream stream, CancellationToken cancellationToken = default);
    Task<byte[]> ReadAsync(string location, CancellationToken cancellationToken = default);
    Task DeleteAsync(string location, CancellationToken cancellationToken = default);
    Task ArchiveAsync(CancellationToken cancellationToken = default);
    Task UnArchiveAsync(CancellationToken cancellationToken = default);
}
