using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RichillCapital.TraderStudio.Desktop;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(IncrementCountCommand))]
    private int _count;

    public MainWindowViewModel()
    {
    }

    [RelayCommand(CanExecute = nameof(CanIncrementCount))]
    private void IncrementCount()
    {
        Count++;
    }

    private bool CanIncrementCount() => Count < 5;

    [RelayCommand]
    private void ClearCount()
    {
        Count = 0;
    }
}