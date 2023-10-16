using System.Reflection;

namespace Core.Tests.TestFiles;

[AttributeUsage(AttributeTargets.Method)]
internal class TestForAllReleaseIndexTestFilesAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
        => TestFileDiscovery
            .DiscoverReleaseIndexTestFiles()
            .Select(p => new object[] { p });

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data) => $"{methodInfo.Name} - {data![0]}";
}
