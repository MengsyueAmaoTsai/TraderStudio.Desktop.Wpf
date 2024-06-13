namespace RichillCapital.TraderStudio.Desktop.Services.Contracts;

public sealed record Paged<T> 
{
    public required IEnumerable<T> Items { get; init; }
}
