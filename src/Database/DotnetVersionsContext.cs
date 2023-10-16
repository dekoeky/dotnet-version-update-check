using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Database;

public class DotnetVersionsContext : DbContext
{
    public DbSet<Snapshot> Snapshots { get; set; }

    // public BloggingContext()
    // {
    //     var folder = Environment.SpecialFolder.LocalApplicationData;
    //     var path = Environment.GetFolderPath(folder);
    //     DbPath = System.IO.Path.Join(path, "blogging.db");
    // }

    // // The following configures EF to create a Sqlite database file in the
    // // special "local" folder for your platform.
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}