using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class InstrumentsViewModel : ViewModel
{
    public InstrumentsViewModel(
        IWindowService windowService) 
        : base(windowService)
    {
    }
}
