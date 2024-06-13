using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Desktop.Services.Contracts;
using RichillCapital.TraderStudio.Desktop.Services.Contracts.SignalSources;

namespace RichillCapital.TraderStudio.Desktop.Services;

public interface IApiService
{
    Task<Result<Paged<SignalSourceResponse>>> ListSignalSourcesAsync(CancellationToken cancellationToken = default);   
}
