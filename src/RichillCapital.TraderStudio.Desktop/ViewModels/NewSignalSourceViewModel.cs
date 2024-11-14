using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Domain;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class NewSignalSourceViewModel : ViewModel
{
    public NewSignalSourceViewModel(
        IWindowService windowService)
        : base(windowService)
    {
        Visibility = VisibilityOptions[0];
    }

    [ObservableProperty]
    private string _id = string.Empty;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private SignalSourceVisibility _visibility;

    public SignalSourceVisibility[] VisibilityOptions { get; } = [.. SignalSourceVisibility.Members.OrderBy(v => v.Value)];

    [RelayCommand]
    private void Submit()
    {
    }

    [RelayCommand]
    private void Cancel()
    {
    }
}
