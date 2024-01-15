using RichillCapital.TraderStudio.Web.Components;

namespace RichillCapital.TraderStudio.Web.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        var environment = builder.Environment.EnvironmentName;

        builder.Configuration
            .AddJsonFile(
                $"appsettings.{environment}.json",
                optional: false,
                reloadOnChange: true);

        builder.Services.AddComponents();

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode();

        return app;
    }
}