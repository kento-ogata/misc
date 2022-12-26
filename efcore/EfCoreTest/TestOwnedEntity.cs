using NodaTime;

namespace EfCoreTest;

public record class TestOwnedEntity(Guid Id, TestEntity TestEntity)
{
    public Guid Id { get; private set; } = Id;

    public TestEntity TestEntity { get; private set; } = TestEntity;
    public Guid TestEntityId { get; private set; } = TestEntity is not null ? TestEntity.Id : Guid.Empty;

    public DateInterval Interval { get; set; } = new DateInterval(LocalDate.MinIsoValue, LocalDate.MaxIsoValue);

#nullable disable warnings
    private TestOwnedEntity() : this(default, default) { }
}
