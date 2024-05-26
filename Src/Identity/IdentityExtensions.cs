using FluentValidation;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;

namespace RichillCapital.Identity;

internal static class IdentityExtensions
{
    internal static IServiceCollection AddCustomAuthenticationPolicy(this IServiceCollection services)
    {
        services.AddIdentityOptions();

        using var scope = services.BuildServiceProvider().CreateScope();

        var identityOptions = scope.ServiceProvider.GetRequiredService<IOptions<IdentityOptions>>().Value;

        var builder = services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        });

        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = identityOptions.OpenIdConnect.Authority;
                options.ClientId = identityOptions.OpenIdConnect.ClientId;
                options.ClientSecret = identityOptions.OpenIdConnect.ClientSecret;
                options.RequireHttpsMetadata = false;

                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("RichillCapital.Api.AspNetCore");
                options.Scope.Add("offline_access");
            });

        return services;
    }

    internal static WebApplication UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
    private static IServiceCollection AddIdentityOptions(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(IdentityOptions).Assembly,
            includeInternalTypes: true);

        services.AddOptionsWithFluentValidation<IdentityOptions>(IdentityOptions.SectionKey);

        return services;
    }
}
