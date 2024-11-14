using CommunityToolkit.Mvvm.ComponentModel;

using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public abstract partial class ViewModel : 
    ObservableObject, 
    IViewModel
{
    protected readonly IWindowService _windowService;

    protected ViewModel(IWindowService windowService)
    {
        _windowService = windowService;
    }
}
