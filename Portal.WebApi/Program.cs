using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Orleans;
using Orleans.Configuration;
using Portal.WebApi.Utilities;
using System.Security.Principal;
using MediatR;
using Portal.Domain.Extensions;
using Portal.Domain.Requests.Organizations;
using Portal.WebApi.RequestHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new ValueObjectModelBinderProvider());
}).AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverterFactory());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(GetOrganizationDomainInformationHandler));
builder.Services.AddSingleton(new Lazy<IClusterClient>(() =>
{
    var client = new ClientBuilder()
    .UseLocalhostClustering()
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

//app.MediateGet<GetOrganizationDomainInformationRequest>("api/Organizations/ShortName/{shortName}/DomainInformation");

//var clusterClient = app.Services.GetService(typeof(Lazy<IClusterClient>));
//clusterClient.Get


app.Run();

