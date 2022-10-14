using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Portal.Grains;

try
{
    var host = await StartSiloAsync();
    Console.WriteLine("\n\n Press Enter to terminate... \n\n");
    Console.ReadLine();
    await host.StopAsync();
    return 0;
}
catch(Exception ex)
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
                options.UseJson = true;
                options.ConfigureBlobServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
            });

            c.UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "portal";
            })
            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(OrganizationGrain).Assembly).WithReferences())
            .ConfigureLogging(logging => logging.AddConsole());

            
        });
    var host = builder.Build();
    await host.StartAsync();
    return host;
}
