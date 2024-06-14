using RichillCapital.Contracts;
using RichillCapital.Identity;
using RichillCapital.Logging;
using RichillCapital.TraderStudio.Web.Components;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure - Logging
builder.WebHost.UseTraderStudioWebLogger();
builder.Services.AddSerilog();

// Infrastructure - Identity
builder.Services.AddTraderStudioWebIdentity();

// Presentation - Razor Components
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

app.UseAuthentication();
app.UseAuthorization();

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;
