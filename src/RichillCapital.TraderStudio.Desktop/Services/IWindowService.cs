using System.Windows;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop.Services;

public interface IWindowService
{
    void ShowWindow<TWindow>() where TWindow : Window;
    void ShowDialog<TDialog>() where TDialog : Window;
}

internal sealed class WindowService(
    IServiceProvider _serviceProvider) :
    IWindowService
{
    public void ShowDialog<TDialog>()
        where TDialog : Window
    {
        var dialog = (Window)_serviceProvider.GetRequiredService(typeof(TDialog));

        var _ = dialog.ShowDialog();
    }

    public void ShowWindow<TWindow>()
        where TWindow : Window
    {
        var window = (Window)_serviceProvider.GetRequiredService(typeof(TWindow));

        window.Show();
    }
}