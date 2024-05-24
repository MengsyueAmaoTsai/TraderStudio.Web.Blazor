namespace RichillCapital.TraderStudio.Web.Services;

internal static class ServiceExtensions
{
    internal static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddScoped<IApiService, ApiService>();

        return services;
    }
}