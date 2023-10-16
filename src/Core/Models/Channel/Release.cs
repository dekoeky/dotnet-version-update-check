using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.Channel;

public class Release
{
    [JsonPropertyName("release-date")]
    public required string ReleaseDate { get; set; }
    [JsonPropertyName("release-version")]
    public required string ReleaseVersion { get; set; }
    [JsonPropertyName("security")]
    public bool Security { get; set; }
    [JsonPropertyName("cve-list")]
    public Cve[]? CveList { get; set; }
    [JsonPropertyName("release-notes")]
    public string? ReleaseNotes { get; set; }

    [JsonPropertyName("sdk")]
    public required Sdk Sdk { get; set; }
    [JsonPropertyName("sdks")]
    public Sdk[]? Sdks { get; set; }
    [JsonPropertyName("runtime")]
    public Runtime? Runtime { get; set; }
    [JsonPropertyName("aspnetcore-runtime")]
    public AspnetCoreRuntime? AspnetCoreRuntime { get; set; }
    [JsonPropertyName("windowsdesktop")]
    public WindowsDesktop? WindowsDesktop { get; set; }
}