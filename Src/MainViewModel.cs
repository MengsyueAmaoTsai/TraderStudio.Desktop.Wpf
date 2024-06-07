using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    private void OpenAbout()
    {
        var dialog = _serviceProvider.GetRequiredService<AboutDialog>();

        dialog.ShowDialog();
    }
}