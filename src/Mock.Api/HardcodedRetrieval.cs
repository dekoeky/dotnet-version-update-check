
using System.Text.Json;
using Wvk.Dotnet.UpdateCheck;
using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Mock.Api;

public class HardcodedRetrieval : IRetrieval
{
    private readonly string _root;

    public HardcodedRetrieval(string root)
    {
        _root = root;
    }
    public async Task<ReleasesIndexResponse?> GetReleasesIndexResponse(CancellationToken cancellationToken = default)
    {
        var str = System.IO.File.OpenRead(Path.Combine(_root, FileNames.ReleasesIndex));

        return await JsonSerializer.DeserializeAsync<ReleasesIndexResponse>(str, cancellationToken: cancellationToken);
    }

    public async Task<ReleaseMetadataResponse?> GetReleaseMetadataResponse(string channel, CancellationToken cancellationToken)
    {
        var str = System.IO.File.OpenRead(Path.Combine(_root, FileNames.Channel(channel)));

        return await JsonSerializer.DeserializeAsync<ReleaseMetadataResponse>(str, cancellationToken: cancellationToken);
    }
}
