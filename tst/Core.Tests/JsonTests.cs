using System.Text.Json;
using Core.Tests.TestFiles;
using Wvk.Dotnet.UpdateCheck.Models.Channel;
using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Core.Tests;

[TestClass]
public class JsonTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
#if DEBUG
        WriteIndented = true,
#else
        WriteIndented = false,
#endif
    };

    [DataTestMethod]
    [TestForAllReleaseIndexTestFiles]
    public void DeserializeReleasesIndexResponse(string path)
    {
        //Arrange
        var json = System.IO.File.ReadAllText(path);

        //Act
        var result = JsonSerializer.Deserialize<ReleasesIndexResponse>(json, Options);

        //Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ReleasesIndex);
        Assert.IsTrue(result.ReleasesIndex.Any());
        CollectionAssert.AllItemsAreNotNull(result.ReleasesIndex);
    }

    [DataTestMethod]
    [TestForAllChannelMetaDataTestFiles]
    public void DeserializeReleaseMetadataResponse(string path)
    {
        //Arrange
        var json = System.IO.File.ReadAllText(path);

        //Act
        var result = JsonSerializer.Deserialize<ReleaseMetadataResponse>(json, Options);

        //Assert
        Assert.IsNotNull(result);
    }
}
