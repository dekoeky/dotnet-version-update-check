namespace Core.Tests.TestFiles;

/// <summary>
/// <see cref="TestFileDiscovery"/> related tests.
/// </summary>
[TestClass]
public class TestFileDiscoveryTests
{
    [TestMethod]
    public void DiscoverReleaseMetadataTestFiles()
    {
        //Act
        var result = TestFileDiscovery.DiscoverReleaseMetadataTestFiles().ToArray();

        //Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public void DiscoverReleaseIndexTestFiles()
    {
        //Act
        var result = TestFileDiscovery.DiscoverReleaseIndexTestFiles().ToArray();

        //Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }
}
