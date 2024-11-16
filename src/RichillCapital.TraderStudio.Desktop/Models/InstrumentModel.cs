namespace RichillCapital.TraderStudio.Desktop.Models;

public sealed record InstrumentModel
{
    public required string Symbol { get; init; }
    public required string Description { get; init; }
}
