using System.Windows;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.TraderStudio.Desktop;


public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public MainWindow(MainViewModel viewModel, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        DataContext = viewModel;

        InitializeComponent();

        CommandBindings.Add(new CommandBinding(
            ApplicationCommands.Close,
            (sender, e) => Close()));
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        Application.Current.Shutdown();
    }
}