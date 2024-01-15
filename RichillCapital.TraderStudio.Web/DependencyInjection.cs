namespace RichillCapital.TraderStudio.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services
            .AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        return services;
    }
}