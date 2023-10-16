using Wvk.Dotnet.UpdateCheck;
using Wvk.Dotnet.UpdateCheck.Comparison;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Checker.Services;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDotnetVersionRetrieval _client;
    private static readonly TimeSpan Delay = TimeSpan.FromSeconds(10);
    private readonly IEqualityComparer<ReleaseIndex> _comparer = new ReleaseIndexComparison();

    public Worker(ILogger<Worker> logger, IDotnetVersionRetrieval client)
    {
        _logger = logger;
        _client = client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Delay);
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

            ProcessNewReply(reply.ReleasesIndex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving versions");
        }
    }

    private void ProcessNewReply(IEnumerable<ReleaseIndex> newestData)
    {
        bool changes = false;
        var dict = newestData.ToDictionary(d => d.ChannelVersion, d => d);

        foreach (var key in _current.Keys.Union(dict.Keys))
        {
            if (!dict.TryGetValue(key, out var @new))
            {
                _logger.LogInformation("Version {key} seems to be removed", key);
                _current.Remove(key);
                changes = true;
            }
            else if (!_current.TryGetValue(key, out var old))
            {
                _logger.LogInformation("Version {key} discovered!", key);
                _current.Add(key, dict[key]);
                changes = true;
            }
            else
            {
                if (_comparer.Equals(old, @new)) continue;

                changes = true;

                if (old.Security != @new.Security)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.Security), old.Security, @new.Security);

                if (old.ReleasesJson != @new.ReleasesJson)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.ReleasesJson), old.ReleasesJson, @new.ReleasesJson);

                if (old.EolDate != @new.EolDate)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.EolDate), old.EolDate, @new.EolDate);

                if (old.LatestRelease != @new.LatestRelease)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.LatestRelease), old.LatestRelease, @new.LatestRelease);

                if (old.LatestReleaseDate != @new.LatestReleaseDate)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.LatestReleaseDate), old.LatestReleaseDate, @new.LatestReleaseDate);

                if (old.LatestRuntime != @new.LatestRuntime)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.LatestRuntime), old.LatestRuntime, @new.LatestRuntime);

                if (old.LatestSdk != @new.LatestSdk)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.LatestSdk), old.LatestSdk, @new.LatestSdk);

                if (old.Product != @new.Product)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.Product), old.Product, @new.Product);

                if (old.ReleaseType != @new.ReleaseType)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.ReleaseType), old.ReleaseType, @new.ReleaseType);

                if (old.SupportPhase != @new.SupportPhase)
                    _logger.LogInformation("Version {key}: {property} changed from {oldValue} to {newValue}",
                        key, nameof(ReleaseIndex.SupportPhase), old.SupportPhase, @new.SupportPhase);

                _current[key] = @new;
            }
        }

        if (!changes)
            _logger.LogDebug($"No changes detected at this time");
    }

    private readonly Dictionary<string, ReleaseIndex> _current = new();
}
