namespace RichillCapital.Identity;

internal sealed record IdentityOptions
{
    internal const string SectionKey = "Identity";

    public required OpenIdConnectOptions OpenIdConnect { get; init; }
}

internal sealed record OpenIdConnectOptions
{
    public required string Authority { get; init; }

    public required string ClientId { get; init; }

    public required string ClientSecret { get; init; }
}
