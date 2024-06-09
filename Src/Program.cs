using RichillCapital.Contracts;
using RichillCapital.Logging;
using RichillCapital.TraderStudio.Web.Components;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseTraderStudioWebLogger();
builder.Services.AddSerilog();

builder.Services.AddComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        PageRoutes.Error, 
        createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAntiforgery();

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;
