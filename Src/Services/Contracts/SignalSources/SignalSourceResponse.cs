﻿namespace RichillCapital.TraderStudio.Desktop.Services.Contracts.SignalSources;

public record SignalSourceResponse
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
