using Blazored.LocalStorage;
using Fluxor.Persist.Storage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Portal.Msal;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.StorageProviders;
using Portal.Web.Domain;
using Portal.Web.Domain.Stores.UserUseCase;
using Fluxor.Persist.Middleware;
using Portal.Web.App.Shared.Stores.OrganizationsUseCase;

var config = new ConfigurationManager()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build()
    .Get<AppSettings>();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AppSettings>(config);
builder.Services.AddHttpClient<WebApiHttpClient>(x => x.BaseAddress = new Uri("https://localhost:7107/"));
builder.Services.AddHttpClient<IdentityServerHttpClient>();
builder.Services.AddMudServices();
builder.Services.AddScoped<MsalJsInterop>();
builder.Services.AddScoped<MsalService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

builder.Services.AddFluxor(fluxorOptions =>

{
    fluxorOptions.ScanAssemblies(typeof(UserState).Assembly, typeof(OrganizationsState).Assembly);
    fluxorOptions.UsePersist(persistOptions =>
    {
        persistOptions.UseInclusionApproach();
        persistOptions.SetWhiteList(UserFeature.FeatureKey);
    });
    fluxorOptions.UseReduxDevTools();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
