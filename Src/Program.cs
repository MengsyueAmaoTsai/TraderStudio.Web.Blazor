using RichillCapital.Contracts;
using RichillCapital.Identity;
using RichillCapital.Logging;
using RichillCapital.TraderStudio.Web.Components;
using RichillCapital.TraderStudio.Web.Middlewares;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure - Logging
builder.WebHost.UseTraderStudioWebLogger();
builder.Services.AddSerilog();

// Infrastructure - Identity
builder.Services.AddTraderStudioWebIdentity();

// Presentation - Razor Components
builder.Services.AddComponents();
builder.Services.AddMiddlewares();

var app = builder.Build();

app.UseDebuggingRequestMiddleware();

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
