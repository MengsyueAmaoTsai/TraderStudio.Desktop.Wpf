using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop.Services;

internal static class ServiceExtensions
{
    private static readonly Uri BaseAddress = new("https://localhost:10000");

    internal static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services
            .AddHttpClient<IApiService, ApiService>(client =>
            {
                client.BaseAddress = BaseAddress;
                client.Timeout = TimeSpan.FromSeconds(10);
            });

        return services;
    }
}
