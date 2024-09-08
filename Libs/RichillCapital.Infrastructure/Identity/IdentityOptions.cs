namespace RichillCapital.Infrastructure.Identity;

internal sealed record IdentityOptions
{
    internal const string SectionKey = "Identity";

    public required string Authority { get; init; }
    public required string ClientId { get; init; }
    public required string ClientSecret { get; init; }
    public required bool RequireHttpsMetadata { get; init; }
}
