

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SnapshotConfiguration : IEntityTypeConfiguration<Snapshot>
{
    public void Configure(EntityTypeBuilder<Snapshot> builder)
    {
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.OwnsMany(s => s.Releases).ToJson();
    }
}