using System.Reflection;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _displayName;

    [ObservableProperty]
    private string _assemblyVersion;

    [ObservableProperty]
    private string _packageVersion;

    [ObservableProperty]
    private string _appInstallerUri;

    [ObservableProperty]
    private string _installLocation;

    public MainViewModel()
    {
        _displayName = ApplicationInfo.GetDisplayName();
        _assemblyVersion = ApplicationInfo.GetAssemblyVersion();
        _packageVersion = ApplicationInfo.GetPackageVersion();
        _appInstallerUri = ApplicationInfo.GetAppInstallerUri();
        _installLocation = ApplicationInfo.GetInstallLocation();
    }

    [RelayCommand]
    private void ShowRuntimeInfo()
    {
        var message = ApplicationInfo.GetDotNetRuntimeInfo();

        MessageBox.Show(message, "Runtime Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}