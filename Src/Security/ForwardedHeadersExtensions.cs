using Microsoft.AspNetCore.HttpOverrides;

namespace RichillCapital.TraderStudio.Web.Security;

internal static class ForwardedHeadersExtensions
{
    internal static IServiceCollection AddForwardedHeaders(this IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });

        return services;
    }
}