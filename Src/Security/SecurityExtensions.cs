namespace RichillCapital.TraderStudio.Web.Security;

internal static class SecurityExtensions
{
    internal static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddForwardedHeaders();
        services.AddTraderStudioWebCookiePolicy();

        return services;
    }
}