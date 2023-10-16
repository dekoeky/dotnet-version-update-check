using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class Cve
{
    [JsonPropertyName("cve-id")]
    public required string Id { get; set; }
    [JsonPropertyName("cve-url")]
    public required string Url { get; set; }
}