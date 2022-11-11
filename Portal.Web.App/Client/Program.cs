using Blazored.LocalStorage;
using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;
using Fluxor.Persist.Middleware;
using Fluxor.Persist.Storage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Portal.Web.Domain.HttpClients;
using Portal.Msal;
using Portal.Web.App.Client;
using Portal.Web.Domain;
using Portal.Web.Domain.StorageProviders;
using Portal.Web.Domain.Stores.UserUseCase;

var config = new AppSettings();
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
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
    fluxorOptions.ScanAssemblies(typeof(App).Assembly, typeof(UserState).Assembly);
    fluxorOptions.UsePersist(persistOptions =>
    {
        persistOptions.UseInclusionApproach();
        persistOptions.SetWhiteList(UserFeature.FeatureKey);
    });
    fluxorOptions.UseReduxDevTools();
});

builder.Services.AddHttpClient("Portal.Web.App.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Portal.Web.App.ServerAPI"));

await builder.Build().RunAsync();
