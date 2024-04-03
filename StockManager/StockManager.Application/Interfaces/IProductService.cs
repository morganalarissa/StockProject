using StockManager.Application.DTOs;
using StockManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<ProductDTO> Update(ProductDTO productDTO);
        Task<ProductDTO> Delete(int id);
        Task<ProductDTO> SelectById(int id);
        Task<IEnumerable<ProductDTO>> SelectAll();
    }
}
