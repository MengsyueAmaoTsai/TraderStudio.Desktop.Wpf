using FluentAssertions;

using NetArchTest.Rules;

using RichillCapital.TraderStudio.Desktop.ViewModels;

namespace RichillCapital.TraderStudio.Desktop.ArchitectureTests;

public sealed class DesignRuleTests
{
    [Fact]
    public void ViewModelTypes_Should_HaveViewModelSuffix()
    {
        var result = Types.InAssembly(typeof(App).Assembly)
            .That()
            .Inherit(typeof(ViewModel))
            .Should()
            .HaveNameEndingWith(nameof(ViewModel))
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}