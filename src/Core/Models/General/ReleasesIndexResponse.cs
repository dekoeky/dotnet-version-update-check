using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.General;

public class ReleasesIndexResponse
{
    [JsonPropertyName("$schema")]
    public required string Schema { get; set; }

    [JsonPropertyName("releases-index")]
    public required ReleaseIndex[] ReleasesIndex { get; set; }
}
