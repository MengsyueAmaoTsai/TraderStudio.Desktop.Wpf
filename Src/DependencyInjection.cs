using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;

internal static class DependencyInjection
{
    public static IServiceCollection AddDesktop(this IServiceCollection services)
    {
        services.AddWindows();

        services.AddViewModels();

        services.AddMessengers();

        services.AddSingleton(_ => Application.Current.Dispatcher);

        return services;
    }

    private static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        services.AddScoped<LoginWindow>();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }

    private static IServiceCollection AddMessengers(this IServiceCollection services)
    {
        services.AddSingleton<WeakReferenceMessenger>();
        services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
            provider.GetRequiredService<WeakReferenceMessenger>());

        return services;
    }
}