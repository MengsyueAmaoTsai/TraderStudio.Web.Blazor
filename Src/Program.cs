using RichillCapital.TraderStudio.Web.Components;

var builder = WebApplication.CreateBuilder(args);

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

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;


internal static class RazorComponentExtensions
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services.AddRazorComponents();

        return services;
    }

    internal static WebApplication MapComponents<TRootComponent>(this WebApplication app)
    {
        app.MapRazorComponents<TRootComponent>();

        return app;
    }
}