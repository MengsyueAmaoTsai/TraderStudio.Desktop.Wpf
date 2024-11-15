using System.Windows;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Desktop.ViewModels;
using RichillCapital.TraderStudio.Desktop.Views;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class App : Application
{
    [STAThread]
    private static void Main(string[] args) => StartAsync(args).GetAwaiter().GetResult();

    private static async Task StartAsync(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();

        await host.StartAsync().ConfigureAwait(true);

        var app = new App();

        app.InitializeComponent();

        app.MainWindow = host.Services.GetRequiredService<MainWindow>();
        app.MainWindow.Show();

        app.Run();

        await host
            .StopAsync()
            .ConfigureAwait(true);
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            configurationBuilder.AddUserSecrets(typeof(App).Assembly))
        .ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<IWindowService, WindowService>();

            services.AddTransient<ITradingViewExportedFileService, TradingViewExportedFileService>();

            services.AddViews();
            services.AddViewModels();
            
            services.AddCommunityToolkitMvvm();

            services.AddSingleton(_ => Current.Dispatcher);
        });
}

internal static class ServiceExtensions
{
    internal static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        services.AddTransient<SignalSourcesWindow>();
        services.AddTransient<NewSignalSourceDialog>();
        services.AddTransient<SignalSourceDetailsDialog>();

        return services;
    }

    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
     
        services.AddTransient<SignalSourcesViewModel>();
        services.AddTransient<NewSignalSourceViewModel>();
        services.AddSingleton<SignalSourceDetailsViewModel>();

        return services;
    }

    internal static IServiceCollection AddCommunityToolkitMvvm(this IServiceCollection services)
    {
        services.AddSingleton<WeakReferenceMessenger>();
        services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
            provider.GetRequiredService<WeakReferenceMessenger>());

        return services;
    }
}
