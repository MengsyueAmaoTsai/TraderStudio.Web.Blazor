using FluentValidation;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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

        services
            .AddOptionsWithFluentValidation<IdentityOptions>(IdentityOptions.SectionKey);

        var identityOptions = services
            .BuildServiceProvider()
            .GetRequiredService<IOptions<IdentityOptions>>()
            .Value;

        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AccessDeniedPath;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = identityOptions.Authority;
                options.ClientId = identityOptions.ClientId;
                options.ClientSecret = identityOptions.ClientSecret;
                options.ResponseType = "code";
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("RichillCapital.Api.AspNetCore");
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.TokenValidationParameters.NameClaimType = "name";
                options.RequireHttpsMetadata = identityOptions.RequireHttpsMetadata;
            });

        return services;
    }
}
