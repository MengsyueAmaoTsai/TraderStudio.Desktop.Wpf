using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
    }

    [RelayCommand]
    private void OpenAbout()
    {
        var dialog = new AboutDialog(new AboutViewModel());
        dialog.ShowDialog();
    }
}