using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Mock.Api;

public interface IRetrieval
{
    public Task<ReleasesIndexResponse?> GetReleasesIndexResponse(CancellationToken cancellationToken = default);
    public Task<ReleaseMetadataResponse?> GetReleaseMetadataResponse(string channel, CancellationToken cancellationToken = default);
}
