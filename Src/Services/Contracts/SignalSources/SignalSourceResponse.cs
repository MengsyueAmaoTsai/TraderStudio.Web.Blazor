namespace RichillCapital.TraderStudio.Web.Services.Contracts.SignalSources;

public sealed class SignalSourceResponse
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }
}