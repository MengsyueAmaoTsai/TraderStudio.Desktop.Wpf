using FluentAssertions;

using NSubstitute;

using RichillCapital.Domain.Common;
using RichillCapital.TraderStudio.Desktop.Services;

namespace RichillCapital.TraderStudio.Desktop.UnitTests;

public sealed class MainViewModelTests
{
    [Fact]
    public void Should()
    {
        IServiceProvider serviceProvider = Substitute.For<IServiceProvider>();
        ILocalStorageManager localStorageManager = Substitute.For<ILocalStorageManager>();
        IApiService apiService = Substitute.For<IApiService>();

        var viewModel = new MainViewModel(serviceProvider, localStorageManager, apiService);

        viewModel.SignalSources.Should().BeEmpty();
    }
}
