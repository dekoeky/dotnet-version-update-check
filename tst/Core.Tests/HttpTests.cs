using Core.Tests.TestFiles;
using Wvk.Dotnet.UpdateCheck;

namespace Core.Tests;

[TestClass]
public class HttpTests
{
    private static readonly IDotnetVersionRetrieval Client = new DotnetVersionRetrievalClient();

    [TestMethod]
    public async Task GetDotnetReleases()
    {
        //Act
        var result = await Client.GetDotnetReleases();

        //Assert
        Assert.IsNotNull(result);
    }

    [DataTestMethod]
    [TestForAllChannels]
    public async Task GetSpecificRelease(string channel)
    {
        //Act
        var result = await Client.GetSpecificRelease(channel);

        //Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetSpecificReleases()
    {
        //Act
        var result = await Client.GetSpecificReleases();

        //Assert
        Assert.IsNotNull(result);
        CollectionAssert.AllItemsAreNotNull(result.Keys);
        CollectionAssert.AllItemsAreNotNull(result.Values);
        Assert.IsTrue(result.Keys.Any());
    }
}
