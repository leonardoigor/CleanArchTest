using CleanApi.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanApi.Domain.RepositoriesInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getAll();
        Task<Product> getById(int? id);

        Task AddAsync(Product product);
        Task<int> Update(Product product);
        Task<int> Remove(Product product);
        bool ProductExists(int id);
    }
}
