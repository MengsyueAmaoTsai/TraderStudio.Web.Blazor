using Microsoft.FluentUI.AspNetCore.Components;

using SciChartBlazor;

namespace RichillCapital.TraderStudio.Web.Components;

internal static class RazorComponentExtensions
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        services.AddFluentUIComponents();

        services.AddSciChart(options =>
        {
        });

        return services;
    }

    internal static WebApplication MapComponents<TRootComponent>(this WebApplication app)
    {
        app.MapRazorComponents<TRootComponent>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode();

        return app;
    }
}