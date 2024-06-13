using System.Net.Http;
using System.Net.Http.Json;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Desktop.Services.Contracts;
using RichillCapital.TraderStudio.Desktop.Services.Contracts.SignalSources;

namespace RichillCapital.TraderStudio.Desktop.Services;

internal sealed class ApiService(
    HttpClient _httpClient) : 
    IApiService
{
    public async Task<Result<Paged<SignalSourceResponse>>> ListSignalSourcesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("api/v1/signal-sources", cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            return Error
                .Invalid("Failed to list signal sources")
                .ToResult<Paged<SignalSourceResponse>>();
        }

        var result = await response.Content.ReadFromJsonAsync<Paged<SignalSourceResponse>>(cancellationToken);
        
        return result.ToResult()!;
    }
}