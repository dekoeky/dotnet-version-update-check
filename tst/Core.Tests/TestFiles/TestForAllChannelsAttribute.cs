using System.Reflection;

namespace Core.Tests.TestFiles;

[AttributeUsage(AttributeTargets.Method)]
internal class TestForAllChannelsAttribute : Attribute, ITestDataSource
{
    private static IEnumerable<string> Channels()
    {
        yield return "1.0";
        yield return "1.1";
        yield return "2.0";
        yield return "2.1";
        yield return "2.2";
        yield return "3.0";
        yield return "3.1";
        yield return "5.0";
        yield return "6.0";
        yield return "7.0";
        yield return "8.0";

    }
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
        => Channels().Select(channel => new object[] { channel });

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data) => $"{methodInfo.Name} - {data![0]}";
}
