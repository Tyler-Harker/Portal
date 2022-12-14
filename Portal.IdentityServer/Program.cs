using Microsoft.AspNetCore.Authentication.Cookies;
using Orleans.Configuration;
using Orleans;
using Portal.IdentityServer.Security;
using Portal.IdentityServer;
using Orleans.Hosting;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
    .AddEnvironmentVariables()
    .Build()
    .Get<IdentityServerConfiguration>();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentityServer()
    .AddClientStore<OrganizationClientStore>()
    .AddResourceStore<ResourceStore>()
    .AddDeveloperSigningCredential()
    .AddResourceOwnerValidator<UserValidator>()
    .AddProfileService<UserProfileService>()
    .AddExtensionGrantValidator<AzureAdGrantValidator>()
    .AddJwtBearerClientAuthentication();

builder.Services.AddSingleton(new Lazy<IClusterClient>(() =>
{
    var client = new ClientBuilder()
    //.UseLocalhostClustering()
    .UseAzureStorageClustering(options =>
    {
        options.ConfigureTableServiceClient(configuration.ConnectionStrings.AzureStorage);
    })
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "dev";
        options.ServiceId = "portal";
    })

    .ConfigureLogging(logging => logging.AddConsole())
    .Build();
    client.Connect(eh => Task.FromResult(true)).Wait();
    return client;
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();
app.UseIdentityServer();

app.Run();
