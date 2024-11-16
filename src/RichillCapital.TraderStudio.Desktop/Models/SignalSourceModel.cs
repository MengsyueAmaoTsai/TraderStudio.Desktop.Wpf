namespace RichillCapital.TraderStudio.Desktop.Models;

public sealed record SignalSourceModel
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string Visibility { get; init; }
    public required DateTimeOffset CreatedTimeUtc { get; init; }
}
