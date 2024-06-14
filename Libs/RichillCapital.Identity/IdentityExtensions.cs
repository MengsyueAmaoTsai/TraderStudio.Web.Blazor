using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;

namespace RichillCapital.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddTraderStudioWebIdentity(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(IdentityExtensions).Assembly, 
            includeInternalTypes: true);

        services.AddOptionsWithFluentValidation<IdentityOptions>(IdentityOptions.SectionKey);

        using var scope = services.BuildServiceProvider().CreateScope();
        var identityOptions = scope.ServiceProvider.GetRequiredService<IOptions<IdentityOptions>>().Value;

        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = RichillCapitalAuthenticationSchemes.Cookie;
                options.DefaultChallengeScheme = RichillCapitalAuthenticationSchemes.Default;
            })
            .AddCookie(RichillCapitalAuthenticationSchemes.Cookie)
            .AddOpenIdConnect(RichillCapitalAuthenticationSchemes.Default, options =>
            {
                options.SignInScheme = RichillCapitalAuthenticationSchemes.Cookie;
                options.Authority = identityOptions.Authority;
                options.ClientId = identityOptions.ClientId;
                options.ClientSecret = identityOptions.ClientSecret;
                options.ResponseType = "code";
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("offline_access");
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.TokenValidationParameters.NameClaimType = "name";
                options.RequireHttpsMetadata = identityOptions.RequireHttpsMetadata;
            });

        return services;
    }
}
