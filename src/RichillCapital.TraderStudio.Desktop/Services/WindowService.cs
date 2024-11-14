using System.Windows;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop.Services;

internal sealed class WindowService(IServiceProvider _serviceProvider) : IWindowService
{
    public void ShowWindow<TWindow>() 
        where TWindow : Window
    {
        var window = (Window)_serviceProvider.GetRequiredService(typeof(TWindow));
        
        window.Show();
    }
}