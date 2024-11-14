using System.Windows;

namespace RichillCapital.TraderStudio.Desktop.Services;

public interface IWindowService
{
    void ShowWindow<TWindow>() where TWindow : Window;
}
