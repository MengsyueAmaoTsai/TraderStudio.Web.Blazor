using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;

namespace RichillCapital.Infrastructure.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
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
                options.DefaultScheme = CustomAuthenticationSchemes.CookieDefault;
                options.DefaultChallengeScheme = CustomAuthenticationSchemes.OpenIdConnectDefault;
            })
            .AddCookie(CustomAuthenticationSchemes.CookieDefault)
            .AddOpenIdConnect(CustomAuthenticationSchemes.OpenIdConnectDefault, options =>
            {
                options.SignInScheme = CustomAuthenticationSchemes.CookieDefault;
                options.Authority = identityOptions.Authority;
                options.ClientId = identityOptions.ClientId;
                options.ClientSecret = identityOptions.ClientSecret;
                options.ResponseType = "code";
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = identityOptions.RequireHttpsMetadata;
            });

        services.AddHttpContextAccessor();

        return services;
    }
}