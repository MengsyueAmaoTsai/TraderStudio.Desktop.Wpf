using System.Collections.ObjectModel;
using System.Windows.Data;

using RichillCapital.TraderStudio.Desktop.Models;
using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class InstrumentsViewModel : ViewModel
{
    public InstrumentsViewModel(
        IWindowService windowService) 
        : base(windowService)
    {
        BindingOperations.EnableCollectionSynchronization(Instruments, new object());
    }

    public ObservableCollection<InstrumentModel> Instruments { get; } = [];
}
