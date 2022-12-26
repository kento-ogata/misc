namespace EfCoreTest;

public class TestEntity
{
    public TestEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    private HashSet<TestOwnedEntity> _ownedEntities { get; set; } = new();
    public ISet<TestOwnedEntity> OwnedEntities => _ownedEntities;
}
