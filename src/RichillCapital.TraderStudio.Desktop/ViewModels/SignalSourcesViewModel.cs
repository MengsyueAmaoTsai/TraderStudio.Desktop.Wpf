using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

using CommunityToolkit.Mvvm.Input;

using Microsoft.Win32;

using RichillCapital.TraderStudio.Desktop.Models;
using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Desktop.Views;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class SignalSourcesViewModel : ViewModel
{
    private static readonly List<SignalSourceItem> _inMemorySignalSources = [
        new()
        {
            Id = "TV-BINANCE:ETHUSDT.P-M15-PL-001",
            Name = "TV-BINANCE:ETHUSDT.P-M15-PL-001",
            Description = "ETHUSDT with donchian channel breakout",
            Visibility = "Private",
            CreatedTimeUtc = DateTimeOffset.UtcNow,
        },
    ];

    private readonly ITradingViewExportedFileService _tradingViewFileService;

    public SignalSourcesViewModel(
        IWindowService windowService,
        ITradingViewExportedFileService tradingViewFileService) 
        : base(windowService)
    {
        _tradingViewFileService = tradingViewFileService;

        BindingOperations.EnableCollectionSynchronization(SignalSources, new object());

        // Initialize 
        foreach (var source in _inMemorySignalSources)
        {
            SignalSources.Add(source);
        }
    }

    public ObservableCollection<SignalSourceItem> SignalSources { get; } = [];

    [RelayCommand]
    private void NewSignalSource()
    {
        _windowService.ShowDialog<NewSignalSourceDialog>();
    }

    [RelayCommand]
    private void UploadHistoricalData()
    {
        var fileDialog = new OpenFileDialog
        {
            Title = "Select file",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
        };

        if (fileDialog.ShowDialog() == false)
        {
            return;
        }

        var fileName = fileDialog.FileName;
        ProcessTradingViewBackTestFile(fileName);
    }

    private void ProcessTradingViewBackTestFile(string filePath)
    {
        var result = _tradingViewFileService.ReadListOfTrades(filePath);

        if (result.IsFailure)
        {
            MessageBox.Show($"{result.Error.Code}: {result.Error.Message}");
            return;
        }

        var display = $"Net profit: {result.Value.Sum(r => r.Profit)}";

        MessageBox.Show(display);
    }
}

