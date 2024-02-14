namespace IceGestor.Core.Entities;
public class Category : BaseEntity
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public virtual Product Product { get; set; }

    public void Update(string name)
    {
        Name = name;
    }
}
