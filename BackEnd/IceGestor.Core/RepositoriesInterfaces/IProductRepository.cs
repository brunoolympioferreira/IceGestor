﻿using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IProductRepository
{
    Task AddAsync(Product product);
    void Update(Product product);
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
}
