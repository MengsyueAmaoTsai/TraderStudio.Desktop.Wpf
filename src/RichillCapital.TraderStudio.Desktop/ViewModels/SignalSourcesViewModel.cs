using System.Collections.ObjectModel;
using System.Windows.Data;

using RichillCapital.TraderStudio.Desktop.Models;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class SignalSourcesViewModel : ViewModel
{
    private static readonly List<SignalSourceItem> _inMemorySignalSources = [
        new()
        {
            Id = "TV-Long-Task",
            Name = "TradingView Long Task",
            Description = "This signal source is used to execute long running tasks.",
            Visibility = "Public",
            CreatedTimeUtc = DateTimeOffset.UtcNow,
        },
        new()
        {
            Id = "TV-Short-Task",
            Name = "TradingView Short Task",
            Description = "This signal source is used to execute short running tasks.",
            Visibility = "Public",
            CreatedTimeUtc = DateTimeOffset.UtcNow,
        },
    ];

    public SignalSourcesViewModel()
    {
        BindingOperations.EnableCollectionSynchronization(SignalSources, new object());

        // Initialize 
        foreach (var source in _inMemorySignalSources)
        {
            SignalSources.Add(source);
        }
    }

    public ObservableCollection<SignalSourceItem> SignalSources { get; } = [];
}
