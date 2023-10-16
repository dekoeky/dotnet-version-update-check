using Wvk.Dotnet.UpdateCheck;

namespace Checker.Services;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDotnetVersionRetrieval _client;
    private static readonly TimeSpan delay = TimeSpan.FromSeconds(10);

    public Worker(ILogger<Worker> logger, IDotnetVersionRetrieval client)
    {
        _logger = logger;
        _client = client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(delay);
        while (!stoppingToken.IsCancellationRequested)
        {
            await CheckForNewVersions(stoppingToken);
            await timer.WaitForNextTickAsync(stoppingToken);
        }
    }

    private async Task CheckForNewVersions(CancellationToken stoppingToken)
    {
        try
        {
            var reply = await _client.GetDotnetReleases(stoppingToken) ?? throw new NullReferenceException("The reply was empty");

            foreach (var version in reply)
                _logger.LogInformation("Discovered {ChannelVersion}", version.ChannelVersion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving versions");
        }
    }
}
