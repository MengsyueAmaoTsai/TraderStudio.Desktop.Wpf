using FluentAssertions;

namespace RichillCapital.TraderStudio.Desktop.AcceptanceTests;

public partial class MainViewModelTests
{
    [Fact]
    public void IncrementCounterCommand_Should_AddCount()
    {
        // Arrange
        MainWindowViewModel viewModel = new MainWindowViewModel();
        int initialCount = viewModel.Count;

        // Act
        viewModel.IncrementCountCommand.Execute(null);

        // Assert
        viewModel.Count.Should().Be(1);
    }
}