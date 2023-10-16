using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.General;

public class ReleaseIndex
{
    [JsonPropertyName("channel-version")]
    public required string ChannelVersion { get; set; }

    [JsonPropertyName("latest-release")]
    public required string LatestRelease { get; set; }

    [JsonPropertyName("latest-release-date")]
    public required string LatestReleaseDate { get; set; }

    [JsonPropertyName("security")]
    public bool Security { get; set; }

    [JsonPropertyName("latest-runtime")]
    public required string LatestRuntime { get; set; }

    [JsonPropertyName("latest-sdk")]
    public required string LatestSdk { get; set; }

    [JsonPropertyName("product")]
    public required string Product { get; set; }

    [JsonPropertyName("release-type")]
    public required string ReleaseType { get; set; }

    [JsonPropertyName("support-phase")]
    public required string SupportPhase { get; set; }

    [JsonPropertyName("eol-date")]
    public string? EolDate { get; set; }

    [JsonPropertyName("releases.json")]
    public required Uri ReleasesJson { get; set; }
}
