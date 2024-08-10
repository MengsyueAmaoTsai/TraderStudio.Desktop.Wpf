using System.Collections.ObjectModel;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;

using RichillCapital.Domain.Common;
using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILocalStorageManager _localFileStorage;
    private readonly IApiService _apiService;

    public MainViewModel(
        IServiceProvider serviceProvider,
        ILocalStorageManager localFileStorage,
        IApiService apiService)
    {
        _serviceProvider = serviceProvider;
        _localFileStorage = localFileStorage;
        _apiService = apiService;
    }
}
