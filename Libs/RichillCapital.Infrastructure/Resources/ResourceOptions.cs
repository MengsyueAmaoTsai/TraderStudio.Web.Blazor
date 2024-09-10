namespace RichillCapital.Infrastructure.Resources;

public sealed record ResourceOptions
{
    internal const string SectionKey = "Resources";

    public required string BaseAddress { get; init; }
}
