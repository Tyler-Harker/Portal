using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Portal.Domain.ValueObjects.Migrations;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Grains;
using Portal.Grains.Interfaces.Public.Extensions;
using Portal.Grains.Interfaces.Internal.Extensions;
using Portal.Silo.Migrations;
using Portal.Domain.ValueObjects;
using Portal.Domain.NewtonsoftJsonConverters;
using Microsoft.Extensions.Configuration;
using Portal.Silo;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
            .AddEnvironmentVariables()
            .Build()
            .Get<SiloConfiguration>();
        try
        {
            var host = await StartSiloAsync(configuration);
            await RunMigrationAsync(configuration);
            Console.WriteLine("\n\n Press Enter to terminate... \n\n");
            Console.ReadLine();
            await host.StopAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        static async Task<IHost> StartSiloAsync(SiloConfiguration configuration)
        {
            var builder = new HostBuilder()
                .UseOrleans(c =>
                {
                    c.AddAzureBlobGrainStorageAsDefault(options =>
                    {
                        options.ConfigureJsonSerializerSettings = (jsonOptions) =>
                        {
                            jsonOptions.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
                            jsonOptions.Converters.Add(new CustomDictionaryConverter());
                        };
                        options.UseJson = true;
                        options.ConfigureBlobServiceClient(configuration.ConnectionStrings.AzureStorage);
                    })
                    //.UseLocalhostClustering()
                    .UseAzureStorageClustering(options =>
                    {
                        options.ConfigureTableServiceClient(configuration.ConnectionStrings.AzureStorage);
                    })
                    .ConfigureEndpoints(siloPort: configuration.SiloPort, gatewayPort: configuration.GatewayPort)
                    .Configure<ClusterOptions>(options =>
                    {
                        options.ClusterId = "dev";
                        options.ServiceId = "portal";
                    })
                    .ConfigureApplicationParts(parts =>
                    {
                        parts.AddApplicationPart(typeof(OrganizationGrain).Assembly).WithReferences();
                        parts.AddApplicationPart(typeof(Portal.Grains.Interfaces.Internal.IOrganizationGrain).Assembly).WithReferences();
                        parts.AddApplicationPart(typeof(Portal.Grains.Interfaces.Public.IOrganizationGrain).Assembly);
                    })
                    .ConfigureLogging(logging => logging.AddConsole());


                });
            var host = builder.Build();
            await host.StartAsync();
            return host;
        }

        static async Task RunMigrationAsync(SiloConfiguration configuration)
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


            var migrationGrain = client.GetInternalGrain(new MigrationGrainId());

            await migrationGrain.Apply(new CreateInitialMigration());

            client.Dispose();
        }
    }
}