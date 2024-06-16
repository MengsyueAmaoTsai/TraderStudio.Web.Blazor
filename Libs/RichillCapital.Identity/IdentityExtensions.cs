using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;
using RichillCapital.UseCases.Common;

namespace RichillCapital.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddTraderStudioWebIdentity(this IServiceCollection services)
    {
        // Register options validator
        services.AddValidatorsFromAssembly(
            typeof(IdentityExtensions).Assembly,
            includeInternalTypes: true);

        // Register identity options
        services.AddOptionsWithFluentValidation<IdentityOptions>(IdentityOptions.SectionKey);

        // Get options and configure Identity
        using var scope = services.BuildServiceProvider().CreateScope();
        var identityOptions = scope.ServiceProvider.GetRequiredService<IOptions<IdentityOptions>>().Value;

        // Authentication
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = RichillCapitalAuthenticationSchemes.DefaultCookieScheme;
                options.DefaultChallengeScheme = RichillCapitalAuthenticationSchemes.DefaultOpenIdConnectScheme;
            })
            .AddCookie(RichillCapitalAuthenticationSchemes.DefaultCookieScheme)
            .AddOpenIdConnect(RichillCapitalAuthenticationSchemes.DefaultOpenIdConnectScheme, options =>
            {
                options.SignInScheme = RichillCapitalAuthenticationSchemes.DefaultCookieScheme;
                options.Authority = identityOptions.Authority;
                options.ClientId = identityOptions.ClientId;
                options.ClientSecret = identityOptions.ClientSecret;
                options.ResponseType = "code";
                options.Scope.Add("openid");
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = identityOptions.RequireHttpsMetadata;
            });

        // Current user context
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUser, CurrentWebUser>();

        return services;
    }
}
