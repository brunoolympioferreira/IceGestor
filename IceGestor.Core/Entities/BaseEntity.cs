namespace IceGestor.Core.Entities;
public abstract class BaseEntity
{
    protected BaseEntity() { }
    public int Id { get; private set; }

    public int ToUnitTest()
    {
        return Id = 1;
    }
}
