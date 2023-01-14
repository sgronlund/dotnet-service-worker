namespace TestService;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

public class DummyService : BackgroundService
{
    private readonly ILogger<DummyService> _logger;
    private readonly IHostApplicationLifetime _hostApplitcationLifetime;

    public DummyService(ILogger<DummyService> logger, IHostApplicationLifetime hostApplitcationLifetime) 
    {
        _logger = logger;
        _hostApplitcationLifetime = hostApplitcationLifetime;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("DummyService running at: {time}", DateTimeOffset.Now);
            await Task.Delay(10000, stoppingToken);
            //DI IHostApplicationLifetime to force the app to stop, simple enough. lesson learned :P
            _hostApplitcationLifetime.StopApplication();
        }
    }
}