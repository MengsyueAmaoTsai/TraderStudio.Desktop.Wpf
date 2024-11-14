using System.Windows;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class NewSignalSourceDialog : Window
{
    public NewSignalSourceDialog(NewSignalSourceViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        Height = SystemParameters.PrimaryScreenHeight * 0.4;
        Width = SystemParameters.PrimaryScreenWidth * 0.4;
    }
}
