using System.Windows;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class InstrumentsWindow : Window
{
    public InstrumentsWindow(InstrumentsViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        Height = SystemParameters.PrimaryScreenHeight * 0.8;
        Width = SystemParameters.PrimaryScreenWidth * 0.8;
    }
}
