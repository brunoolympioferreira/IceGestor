﻿namespace IceGestor.Core.Entities;
public class Category : BaseEntity
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void Update(string name)
    {
        Name = name;
    }
}
