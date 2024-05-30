namespace RichillCapital.TraderStudio.Web.Security;

internal static class CookiePolicyExtensions
{
    internal static IServiceCollection AddTraderStudioWebCookiePolicy(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
            options.Secure = CookieSecurePolicy.Always;
        });

        return services;
    }
}