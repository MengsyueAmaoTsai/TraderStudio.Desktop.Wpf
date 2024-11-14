using System.Windows;
using System.Windows.Input;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.Views;

public sealed partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    private void OnClose(object sender, ExecutedRoutedEventArgs e)
    {
        Close();
    }
}