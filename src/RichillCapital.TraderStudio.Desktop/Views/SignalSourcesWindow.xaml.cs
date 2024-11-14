using System.Windows;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class SignalSourcesWindow : Window
{
    public SignalSourcesWindow(SignalSourcesViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}
