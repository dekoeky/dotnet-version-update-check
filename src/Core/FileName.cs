namespace Wvk.Dotnet.UpdateCheck;

/// <summary>
/// A centralized way of calculating the filenames.
/// </summary>
public static class FileNames
{
    public const string ReleasesIndex = "releases-index.json";
    public static string Channel(string channel) => $"channel-{channel}.json";
}
