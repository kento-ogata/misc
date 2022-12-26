using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> dbContextConfigure) : base(dbContextConfigure)
    {

    }

    public DbSet<TestEntity> TestEntities => Set<TestEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
