using System.Windows;

namespace RichillCapital.TraderStudio.Desktop;

public partial class LoginWindow : Window
{
    public LoginWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        Application.Current.Shutdown();
    }
}
