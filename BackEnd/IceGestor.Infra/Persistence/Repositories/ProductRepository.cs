﻿using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;

namespace IceGestor.Infra.Persistence.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly IceGestorDbContext _context;
    public ProductRepository(IceGestorDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
}
