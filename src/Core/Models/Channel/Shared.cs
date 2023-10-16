using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public abstract class Shared
{
    [JsonPropertyName("version")] public required string Version { get; set; }
    [JsonPropertyName("version-display")] public required string VersionDisplay { get; set; }
    [JsonPropertyName("files")] public required File[] Files { get; set; }
}