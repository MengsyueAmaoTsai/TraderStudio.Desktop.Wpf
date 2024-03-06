using System.Windows;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;

internal static class DependencyInjection
{
    internal static IServiceCollection AddDesektop(this IServiceCollection services)
    {
        services.AddMessenger();

        services.AddSingleton(_ => Application.Current.Dispatcher);

        services.AddMvvm();

        return services;
    }

    private static IServiceCollection AddMessenger(this IServiceCollection services)
    {
        services.AddSingleton<WeakReferenceMessenger>();
        services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
            provider.GetRequiredService<WeakReferenceMessenger>());

        return services;
    }

    private static IServiceCollection AddMvvm(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }
}
