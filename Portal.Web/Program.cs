using Blazored.LocalStorage;
using Des.Blazor.Authorization.Msal;
using Fluxor;
using Fluxor.Persist.Middleware;
using Fluxor.Persist.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Portal.Web.Domain.HttpClients;
using Portal.Msal;
using Portal.Web;
using Portal.Web.Data;
using Portal.Web.Domain;
using Portal.Web.Domain.StorageProviders;
using Portal.Web.Domain.Stores.UserOrganizationUseCase;
using Portal.Web.Domain.Stores.UserUseCase;
using Portal.Web.Routing.Store.RoutingUseCase;


var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build()
    .Get<AppSettings>();




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();

builder.Services.AddScoped<MsalJsInterop>();
builder.Services.AddScoped<MsalService>();
builder.Services.AddHttpClient<WebApiHttpClient>(x => x.BaseAddress = new Uri("https://localhost:7107/"));
builder.Services.AddHttpClient<IdentityServerHttpClient>();
builder.Services.AddSingleton<AppSettings>(config);
builder.Services.AddFluxor(fluxorOptions => {
    fluxorOptions.ScanAssemblies(typeof(App).Assembly, typeof(UserState).Assembly, typeof(RoutingState).Assembly);
    fluxorOptions.UsePersist(persistOptions => {
        persistOptions.UseInclusionApproach();
        persistOptions.SetWhiteList(UserFeature.FeatureKey);
    });
    fluxorOptions.UseReduxDevTools();
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


class ClientConfig : IMsalConfig
{
    public ClientConfig(string authority, string clientId, LoginModes mode)
    {
        Authority = authority;
        ClientId = clientId;
        LoginMode = mode;
    }
    public string ClientId { get; }

    public string Authority { get; }

    public LoginModes LoginMode { get; }
}