using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class AspnetCoreRuntime : Shared
{
    [JsonPropertyName("version-aspnetcoremodule")] public string[]? VersionAspnetCoreModule { get; set; }
    [JsonPropertyName("vs-version")] public string? VsVersion { get; set; }
}