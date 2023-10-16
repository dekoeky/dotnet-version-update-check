using Wvk.Dotnet.UpdateCheck;

namespace Core.Tests.TestFiles;

/// <summary>
/// Discovery of test files for unit tests.
/// </summary>
internal static class TestFileDiscovery
{
    private const string RootDir = "doc/json";

    public static IEnumerable<string> DiscoverReleaseIndexTestFiles()
        => Directory.EnumerateFiles(RootDir, FileNames.ReleasesIndex, SearchOption.AllDirectories).Select(Path.GetFullPath);

    public static IEnumerable<string> DiscoverReleaseMetadataTestFiles()
        => Directory.EnumerateFiles(RootDir, FileNames.Channel("*"), SearchOption.AllDirectories).Select(Path.GetFullPath);
}
