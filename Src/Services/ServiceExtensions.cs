using FluentValidation;

using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;

namespace RichillCapital.TraderStudio.Web.Services;


internal static class ServiceExtensions
{
    internal static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(ServiceExtensions).Assembly,
            includeInternalTypes: true);

        services.AddOptionsWithFluentValidation<ApiServerOptions>(ApiServerOptions.SectionKey);

        using var scope = services
            .BuildServiceProvider()
            .CreateScope();

        var apiServerOptions = scope.ServiceProvider
            .GetRequiredService<IOptions<ApiServerOptions>>()
            .Value;

        services.AddHttpClient<IApiService, ApiService>(client =>
        {
            client.BaseAddress = new Uri(apiServerOptions.BaseAddress);
            client.Timeout = new TimeSpan(0, 0, 30);
            client.DefaultRequestHeaders.Clear();
        });

        return services;
    }
}