using CleanApi.Domain.Entities.Product;
using CleanApi.Domain.RepositoriesInterfaces;
using CleanApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanApi.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Product> model;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            model = _context.Products;
        }
        public async Task AddAsync(Product product)
        {
            model.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> getAll() => await model.ToListAsync();

        public async Task<Product> getById(int? id) => await _context.Products
                    .FirstOrDefaultAsync(m => m.Id == id);

        public bool ProductExists(int id) => _context.Products.Any(e => e.Id == id);

        public async Task<int> Remove(Product product)
        {
            _context.Products.Remove(product);
         return   await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Product product)
        {
            model.Update(product);
           return await _context.SaveChangesAsync();
        }

    }
}
