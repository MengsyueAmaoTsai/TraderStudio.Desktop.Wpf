using System.Collections.ObjectModel;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ObservableCollection<SignalSourceModel> SignalSources { get; } = [];

    [ObservableProperty]
    private SignalSourceModel? _selectedSignalSource;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        SignalSources.Add(new SignalSourceModel
        {
            Id = "1",
            Name = "Signal Source 1",
            Description = "Signal Source 1 Description"
        });
    }

    [RelayCommand]
    private void OpenAbout()
    {
        var dialog = _serviceProvider.GetRequiredService<AboutDialog>();

        dialog.ShowDialog();
    }

    [RelayCommand]
    private void OpenCreateDialog()
    {
        MessageBox.Show($"Selected signal source: {SelectedSignalSource}");
    }
}

public sealed record SignalSourceModel
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }
}