using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using RichillCapital.Extensions.Options;

namespace RichillCapital.Infrastructure.Resources;

public static class ResourceExtensions
{
    public static IServiceCollection AddResourceApiService(this IServiceCollection services)
    {
        services.AddResourceOptions();

        using var scope = services.BuildServiceProvider().CreateScope();
        var resourceOptions = scope.ServiceProvider.GetRequiredService<IOptions<ResourceOptions>>().Value;

        services.AddScoped<ITokenManager, TokenManager>();

        services.AddHttpClient<IResourceService, ResourceService>(client =>
        {
            client.BaseAddress = new Uri(resourceOptions.BaseAddress);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();
        });

        return services;
    }

    private static IServiceCollection AddResourceOptions(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(ResourceExtensions).Assembly,
            includeInternalTypes: true);

        services.AddOptionsWithFluentValidation<ResourceOptions>(ResourceOptions.SectionKey);

        return services;
    }
}