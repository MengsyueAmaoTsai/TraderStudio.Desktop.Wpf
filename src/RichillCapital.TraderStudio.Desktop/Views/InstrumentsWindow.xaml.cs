using System.Windows;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class InstrumentsWindow : Window
{
    public InstrumentsWindow(InstrumentsViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}
