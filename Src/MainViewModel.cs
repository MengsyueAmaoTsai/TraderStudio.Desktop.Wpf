using System.Collections.ObjectModel;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

using RichillCapital.Domain.Common;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILocalStorageManager _localFileStorage;

    public ObservableCollection<SignalSourceModel> SignalSources { get; } = [];

    [ObservableProperty]
    private SignalSourceModel? _selectedSignalSource;

    public MainViewModel(
        IServiceProvider serviceProvider,
        ILocalStorageManager localFileStorage)
    {
        _serviceProvider = serviceProvider;
        _localFileStorage = localFileStorage;   

        SignalSources.Add(new SignalSourceModel
        {
            Id = "1",
            Name = "Signal Source 1",
            Description = "Signal Source 1 Description"
        });
    }

    [RelayCommand]
    private async Task TestAsync()
    {
        await Task.Delay(500);
        MessageBox.Show("Test");
    }

    [RelayCommand]
    private void OpenAbout()
    {
        var dialog = _serviceProvider.GetRequiredService<AboutDialog>();

        dialog.ShowDialog();
    }
}

public sealed record SignalSourceModel
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }
}