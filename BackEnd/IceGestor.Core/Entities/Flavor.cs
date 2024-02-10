namespace IceGestor.Core.Entities;
public class Flavor : BaseEntity
{
    public Flavor(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public Product Product { get; set; }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
