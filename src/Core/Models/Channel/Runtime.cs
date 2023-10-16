using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class Runtime : Shared
{
    [JsonPropertyName("vs-version")] public string? VsVersion { get; set; }
    [JsonPropertyName("vs-mac-version")] public string? VsMacVersion { get; set; }
}