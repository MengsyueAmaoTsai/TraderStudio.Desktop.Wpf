using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class SignalSourceDetailsViewModel : ViewModel
{
    public SignalSourceDetailsViewModel(
        IWindowService windowService) 
        : base(windowService)
    {
    }
}
