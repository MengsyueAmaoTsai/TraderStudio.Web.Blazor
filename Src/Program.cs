using RichillCapital.TraderStudio.Web.Extensions;

var app = WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .Build();

await app
    .ConfigurePipelines()
    .RunAsync();
