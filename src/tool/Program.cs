
using Database;
using Microsoft.EntityFrameworkCore;
using Wvk.Dotnet.UpdateCheck;

const string DbPath = "bloggin.db";
var options = new DbContextOptionsBuilder<DotnetVersionsContext>()
    .UseSqlite($"Data Source={DbPath}")
    .Options;
await using var context = new DotnetVersionsContext(options);


var client = new DotnetVersionRetrievalClient();
var response = await client.GetDotnetReleases();

await context.Database.EnsureCreatedAsync();
await context.Snapshots.AddAsync(new Snapshot{
    Created = DateTime.Now,
    Releases = response.ReleasesIndex
});
await context.SaveChangesAsync();

