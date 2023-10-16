using Microsoft.AspNetCore.Mvc;
using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Mock.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DotnetController : ControllerBase
{
    private readonly ILogger<DotnetController> _logger;
    private readonly IRetrieval _retrieval;

    public DotnetController(ILogger<DotnetController> logger, IRetrieval retrieval)
    {
        _logger = logger;
        _retrieval = retrieval;
    }

    [HttpGet("index", Name = "GetReleasesIndexResponse")]
    public async Task<ReleasesIndexResponse?> GetReleasesIndexResponse(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"{nameof(GetReleasesIndexResponse)} request for channel");

        var indexResponse = await _retrieval.GetReleasesIndexResponse(cancellationToken);

        foreach (var item in indexResponse?.ReleasesIndex ?? Enumerable.Empty<ReleaseIndex>())
            item.ReleasesJson = CalculateUrl(item.ChannelVersion);

        return indexResponse;
    }


    [HttpGet("release/{channel}", Name = "GetReleaseMetadataResponse")]
    public async Task<ReleaseMetadataResponse?> GetReleaseMetadataResponse(string channel, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"{nameof(GetReleasesIndexResponse)} request for channel {{channel}}", channel);
        return await _retrieval.GetReleaseMetadataResponse(channel, cancellationToken);
    }

    private Uri CalculateUrl(string channel)
    {
        var s = Request.Scheme + "://" + Request.Host + $"/Dotnet/release/{channel}";

        return new Uri(s);
    }
}
