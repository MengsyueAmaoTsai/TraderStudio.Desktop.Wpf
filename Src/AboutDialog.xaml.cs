using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;

namespace RichillCapital.TraderStudio.Desktop;

public sealed partial class AboutDialog : Window
{
    public AboutDialog(AboutViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}

public sealed partial class AboutViewModel : ObservableObject
{
    public string PackageName { get; } = ApplicationInfo.GetDisplayName();
    public string PackageVersion { get; } = ApplicationInfo.GetPackageVersion();
    public string PackageUri { get; } = ApplicationInfo.GetPackageUri();
    public string AssemblyVersion { get; } = ApplicationInfo.GetAssemblyVersion();
    public string InstallLocation { get; } = ApplicationInfo.GetInstallLocation();
    public string DotNetRuntimeVersion { get; } = ApplicationInfo.GetDotNetRuntimeVersion();
}