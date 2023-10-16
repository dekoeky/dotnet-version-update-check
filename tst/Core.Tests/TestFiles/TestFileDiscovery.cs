namespace Core.Tests.TestFiles;

/// <summary>
/// Discovery of test files for unit tests.
/// </summary>
internal static class TestFileDiscovery
{
    private const string RootDir = "doc/json";

    public static IEnumerable<string> DiscoverReleaseIndexTestFiles()
        => Directory.EnumerateFiles(RootDir, "releases-index.json", SearchOption.AllDirectories).Select(Path.GetFullPath);

    public static IEnumerable<string> DiscoverReleaseMetadataTestFiles()
        => Directory.EnumerateFiles(RootDir, "channel-*.json", SearchOption.AllDirectories).Select(Path.GetFullPath);
}
