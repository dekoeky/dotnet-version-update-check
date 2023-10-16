namespace Wvk.Dotnet.UpdateCheck;


internal static class Urls
{
    public const string Dotnet = "https://dotnetcli.azureedge.net/dotnet/release-metadata/releases-index.json";

    public static string ForChannel(string channel) => $"https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/{channel}/releases.json";
    public const string VisualStudio = "https://aka.ms/vs/channels";
}
