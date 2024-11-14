using System.Windows;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class SignalSourceDetailsDialog : Window
{
    public SignalSourceDetailsDialog(SignalSourceDetailsViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}
