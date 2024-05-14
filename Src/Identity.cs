namespace RichillCapital.Identity;

internal static class IdentityExtensions
{
    internal static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        return services;
    }
}

internal sealed record IdentityOptions
{
    internal const string SectionKey = "Identity";
}
