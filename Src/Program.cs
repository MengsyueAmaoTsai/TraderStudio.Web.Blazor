using RichillCapital.Identity;
using RichillCapital.TraderStudio.Web.Components;
using RichillCapital.TraderStudio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure - Identity
builder.Services.AddTraderStudioWebAuthentication();

// Infrastructure - API Service
builder.Services.AddApiService();

// Presentation - Blazor Components
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

app.UseTraderStudioWebIdentity();

app.MapComponents<App>();

await app.RunAsync();


public partial class Program;
