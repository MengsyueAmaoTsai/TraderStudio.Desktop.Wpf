using CommunityToolkit.Mvvm.Input;

using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Desktop.Views;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    private readonly IWindowService _windowService;

    public MainViewModel(
        IWindowService windowService)
        : base(windowService)
    {
        _windowService = windowService;
    }

    [RelayCommand]
    private void ShowInstrumentsWindow() => _windowService.ShowWindow<InstrumentsWindow>();

    [RelayCommand]
    private void ShowSignalSourcesWindow() => _windowService.ShowWindow<SignalSourcesWindow>();
}
