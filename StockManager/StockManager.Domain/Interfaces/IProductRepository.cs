using StockManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task <Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
        Task<Product> SelectById(int id);
        Task<IEnumerable<Product>> SelectAll();
        
    }
}
