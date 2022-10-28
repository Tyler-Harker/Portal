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

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        try
        {
            var host = await StartSiloAsync();
            await RunMigrationAsync();
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

        static async Task<IHost> StartSiloAsync()
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
                        options.ConfigureBlobServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
                    });

                    c.UseLocalhostClustering()
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

        static async Task RunMigrationAsync()
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


            var migrationGrain = client.GetInternalGrain(new MigrationGrainId());

            await migrationGrain.Apply(new CreateInitialMigration());

            client.Dispose();
        }
    }
}