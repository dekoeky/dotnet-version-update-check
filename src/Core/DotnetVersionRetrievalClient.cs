using System.Text.Json;
using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Wvk.Dotnet.UpdateCheck;

public class DotnetVersionRetrievalClient : IDotnetVersionRetrieval
{
    private readonly HttpClient _client;

    public DotnetVersionRetrievalClient()
    {
        _client = new HttpClient();
    }

    public DotnetVersionRetrievalClient(HttpClient client)
    {
        _client = client;
    }

    public Task<ReleasesIndexResponse?> GetDotnetReleases(CancellationToken token = default)
        => Get<ReleasesIndexResponse>(Urls.Dotnet, token);

    public async Task<Dictionary<ReleaseIndex, ReleaseMetadataResponse>?> GetSpecificReleases(CancellationToken token = default)
    {
        var index = (await GetDotnetReleases(token))?.ReleasesIndex ?? throw new Exception("Could not retrieve Releases Index");

        var tasks = index.ToDictionary(i => i, i => GetSpecificRelease(i.ChannelVersion, token));

        await Task.WhenAll(tasks.Values);

        return tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result ?? throw new Exception($"Could not retrieve channel {kv.Key.ChannelVersion} MetaData"));
    }

    public Task<ReleaseMetadataResponse?> GetSpecificRelease(string channel, CancellationToken token = default)
        => Get<ReleaseMetadataResponse>(Urls.ForChannel(channel), token);

    private async Task<T?> Get<T>(string uri, CancellationToken token = default) where T : class
        => await Get<T>(new Uri(uri), token);

    private async Task<T?> Get<T>(Uri uri, CancellationToken token = default) where T : class
    {
        using var httpResponse = await _client.GetAsync(uri, token);

        httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

        var contentStream = await httpResponse.Content.ReadAsStreamAsync(token);

        try
        {
            return await JsonSerializer.DeserializeAsync<T>(contentStream, options: null, token);
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON.");
        }

        return null;
    }
}
