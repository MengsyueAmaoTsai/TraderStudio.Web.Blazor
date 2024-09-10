namespace RichillCapital.Infrastructure.Resources.Contracts.SignalSources;

public sealed record SignalSourceResponse
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset CreatedTimeUtc { get; init; }
}