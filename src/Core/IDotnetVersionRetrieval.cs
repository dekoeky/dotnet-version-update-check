using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Wvk.Dotnet.UpdateCheck;

public interface IDotnetVersionRetrieval
{
    public Task<ReleasesIndexResponse?> GetDotnetReleases(CancellationToken token = default);
    public Task<Dictionary<ReleaseIndex, ReleaseMetadataResponse>?> GetSpecificReleases(CancellationToken token = default);
    public Task<ReleaseMetadataResponse?> GetSpecificRelease(string channel, CancellationToken token = default);
}
