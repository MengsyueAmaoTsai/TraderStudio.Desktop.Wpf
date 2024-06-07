using Microsoft.Extensions.DependencyInjection;

using RichillCapital.Domain.Common;

namespace RichillCapital.Storage;

public static class LocalFileStorageExtensions
{
    public static IServiceCollection AddLocalFileStorageManager(this IServiceCollection services)
    {
        services.AddSingleton<ILocalStorageManager, LocalFileStorageManager>();

        return services;
    }
}