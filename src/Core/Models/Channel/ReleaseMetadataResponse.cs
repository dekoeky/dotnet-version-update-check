using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class ReleaseMetadataResponse
{
    [JsonPropertyName("channel-version")]
    public required string ChannelVersion { get; set; }
    [JsonPropertyName("latest-release")]
    public required string LatestRelease { get; set; }
    [JsonPropertyName("latest-release-date")]
    public required string LatestReleaseDate { get; set; }
    [JsonPropertyName("latest-runtime")]
    public required string LatestRuntime { get; set; }
    [JsonPropertyName("latest-sdk")]
    public required string LatestSdk { get; set; }
    [JsonPropertyName("release-type")]
    public required string ReleaseType { get; set; }
    [JsonPropertyName("support-phase")]
    public required string SupportPhase { get; set; }
    [JsonPropertyName("lifecycle-policy")]
    public required string LifecyclePolicy { get; set; }
    [JsonPropertyName("releases")]
    public required Release[] Releases { get; set; }
}
