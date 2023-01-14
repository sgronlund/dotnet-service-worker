using TestService;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Can add multiple service here, will do
        // as an example
        services.AddHostedService<Worker>();
        services.AddHostedService<DummyService>();
    })
    .Build();

await host.RunAsync();
