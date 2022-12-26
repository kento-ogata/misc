using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreTest;

public class TestEntityEntityTypeConfiguration : IEntityTypeConfiguration<TestEntity>
{
    public void Configure(EntityTypeBuilder<TestEntity> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id);

        builder.OwnsMany(entity => entity.OwnedEntities, nav =>
        {
            nav.WithOwner(owned => owned.TestEntity)
                .HasForeignKey(owned => owned.TestEntityId);
            nav.Property(owned => owned.TestEntityId);
            nav.Property(owned => owned.Id);
            nav.HasKey(owned => owned.Id);
            nav.Property(owned => owned.Interval);
        });
    }
}
