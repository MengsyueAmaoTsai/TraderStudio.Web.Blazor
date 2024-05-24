namespace RichillCapital.TraderStudio.Web.Contracts;

public sealed record SignalSourceResponse
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal WinRate { get; init; }
    public required decimal Returns { get; init; }
}