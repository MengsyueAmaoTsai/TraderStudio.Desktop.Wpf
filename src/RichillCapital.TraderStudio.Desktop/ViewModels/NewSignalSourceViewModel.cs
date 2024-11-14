using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class NewSignalSourceViewModel : ViewModel
{
    public NewSignalSourceViewModel(
        IWindowService windowService)
        : base(windowService)
    {
    }
}
