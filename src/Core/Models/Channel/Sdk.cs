using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

// ReSharper disable once ClassNeverInstantiated.Global
public class Sdk : Shared
{
    [JsonPropertyName("runtime-version")] public string? RuntimeVersion { get; set; }
    [JsonPropertyName("vs-version")] public string? VsVersion { get; set; }
    [JsonPropertyName("vs-mac-version")] public string? VsMacVersion { get; set; }
    [JsonPropertyName("vs-support")] public string? VsSupport { get; set; }
    [JsonPropertyName("vs-mac-support")] public string? VsMacSupport { get; set; }
    [JsonPropertyName("csharp-version")] public string? CSharpVersion { get; set; }
    [JsonPropertyName("fsharp-version")] public string? FSharpVersion { get; set; }
    [JsonPropertyName("vb-version")] public string? VbVersion { get; set; }
}