using System.Windows;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;

internal static class DependencyInjection
{
    public static IServiceCollection AddDesektop(this IServiceCollection services)
    {
        services.AddSingleton<WeakReferenceMessenger>();
        services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider => provider.GetRequiredService<WeakReferenceMessenger>());

        services.AddSingleton(_ => Application.Current.Dispatcher);

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }
}
