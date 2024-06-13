using System.Collections.ObjectModel;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

using RichillCapital.Domain.Common;
using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Desktop.Services.Contracts.SignalSources;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILocalStorageManager _localFileStorage;
    private readonly IApiService _apiService;

    public ObservableCollection<SignalSourceModel> SignalSources { get; } = [];

    [ObservableProperty]
    private SignalSourceModel? _selectedSignalSource;

    public MainViewModel(
        IServiceProvider serviceProvider,
        ILocalStorageManager localFileStorage,
        IApiService apiService)
    {
        _serviceProvider = serviceProvider;
        _localFileStorage = localFileStorage;   
        _apiService = apiService;
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

    [RelayCommand]
    private async Task RefreshAsync()
    {
        SignalSources.Clear();

        var result = await _apiService.ListSignalSourcesAsync(CancellationToken.None);

        if (result.IsFailure)
        {
            MessageBox.Show($"{result.Error}");
            return;
        }

        var models = result.Value.Items.ToModels();

        foreach (var model in models)
        {
            SignalSources.Add(model);
        }
    }
}

public sealed record SignalSourceModel
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }
}

internal static class SignalSourceModelMapping
{
    internal static SignalSourceModel ToModel(
        this SignalSourceResponse response) =>
        new()
        {
            Id = response.Id,
            Name = response.Name,
            Description = response.Description
        };

    internal static IEnumerable<SignalSourceModel> ToModels(
        this IEnumerable<SignalSourceResponse> responses) =>
        responses.Select(ToModel);
}