using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;
using RichillCapital.TraderStudio.Desktop.Services;
using RichillCapital.TraderStudio.Domain;

namespace RichillCapital.TraderStudio.Desktop.ViewModels;

public sealed partial class NewSignalSourceViewModel : ViewModel
{
    public NewSignalSourceViewModel(
        IWindowService windowService)
        : base(windowService)
    {
        Visibility = VisibilityOptions[0];
    }

    [ObservableProperty]
    private string _id = string.Empty;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private SignalSourceVisibility _visibility;

    public SignalSourceVisibility[] VisibilityOptions { get; } = [.. SignalSourceVisibility.Members.OrderBy(v => v.Value)];

    [RelayCommand]
    private void Submit()
    {
        var maybeError = ValidateForm();

        if (maybeError.HasValue)
        {
            MessageBox.Show($"{maybeError.Value.Code} - {maybeError.Value.Message}");
            return;
        }

        // Create new signal source with some service
        MessageBox.Show($"Signal source '{Id}' created successfully.");
    }

    [RelayCommand]
    private void Cancel()
    {
    }

    private Maybe<Error> ValidateForm()
    {
        if (string.IsNullOrEmpty(Id))
        {
            return Maybe<Error>.With(Error.Invalid("Id is required"));
        }

        if (string.IsNullOrEmpty(Name))
        {
            return Maybe<Error>.With(Error.Invalid("Name is required"));
        }

        return Maybe<Error>.Null;
    }
}
