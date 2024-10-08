﻿using System.Windows;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using RichillCapital.Logging;
using RichillCapital.Storage;
using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop;

public partial class App : Application
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
        .UseTraderStudioDesktopLogger()
        .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            configurationBuilder.AddUserSecrets(typeof(App).Assembly))
        .ConfigureServices((hostContext, services) =>
        {
            // Infrastructure - File Storage
            services.AddLocalFileStorageManager();

            // Infrastructure - API Service
            services.AddApiService();

            // Presentation - MVVM
            services.AddScoped<MainWindow>();

            services.AddScoped<MainViewModel>();

            services.AddSingleton<WeakReferenceMessenger>();
            services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
                provider.GetRequiredService<WeakReferenceMessenger>());

            services.AddSingleton(_ => Current.Dispatcher);
        });
}

