using RichillCapital.Logging;
using RichillCapital.Identity;
using RichillCapital.TraderStudio.Web.Components;
using RichillCapital.TraderStudio.Web.Security;
using RichillCapital.TraderStudio.Web.Services;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure - Logging
builder.Services.AddSerilog();
builder.WebHost.UseTraderStudioWebLogger();

// Infrastructure - Identity
builder.Services.AddTraderStudioWebAuthentication();

// Infrastructure - API Service
builder.Services.AddApiService();

// Presentation - Blazor Components
builder.Services.AddSecurity();
builder.Services.AddComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

// UseRouting
app.UseAntiforgery();

app.UseTraderStudioWebIdentity();

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;
