using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class File
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("rid")]
    public string? Rid { get; set; }
    [JsonPropertyName("url")]
    public required string Url { get; set; }
    [JsonPropertyName("hash")]
    public required string Hash { get; set; }
}