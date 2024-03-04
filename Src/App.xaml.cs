using System.Windows;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RichillCapital.TraderStudio.Desktop;

public partial class App : Application
{
    [STAThread]
    private static void Main(string[] args)
    {
        RunAsync(args).GetAwaiter().GetResult();
    }

    private static async Task RunAsync(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        await host.StartAsync().ConfigureAwait(true);

        App app = new();
        app.InitializeComponent();
        app.MainWindow = host.Services.GetRequiredService<MainWindow>();
        app.MainWindow.Visibility = Visibility.Visible;
        app.Run();

        await host.StopAsync().ConfigureAwait(true);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configuration) =>
                configuration.AddUserSecrets(typeof(App).Assembly))
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<WeakReferenceMessenger>();
                services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider => provider.GetRequiredService<WeakReferenceMessenger>());

                services.AddSingleton(_ => Current.Dispatcher);

                services.AddSingleton<MainWindow>();
            });

        return builder;
    }
}
