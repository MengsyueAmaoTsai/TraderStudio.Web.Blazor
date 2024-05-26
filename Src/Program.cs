using Microsoft.FluentUI.AspNetCore.Components;

using RichillCapital.Identity;
using RichillCapital.TraderStudio.Web.Components;
using RichillCapital.TraderStudio.Web.Services;

using SciChartBlazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiService();

builder.Services.AddCustomAuthenticationPolicy();

builder.Services.AddComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.UseIdentity();

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;


internal static class RazorComponentExtensions
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        services.AddFluentUIComponents();

        services.AddSciChart(options =>
        {
        });

        return services;
    }

    internal static WebApplication MapComponents<TRootComponent>(this WebApplication app)
    {
        app.MapRazorComponents<TRootComponent>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}