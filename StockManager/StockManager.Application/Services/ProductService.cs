using AutoMapper;
using StockManager.Application.DTOs;
using StockManager.Application.Interfaces;
using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var updatedProduct = await _repository.Update(product);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }

        public async Task<ProductDTO> Delete(int id)
        {
            
            var deletedProduct = await _repository.Delete(id);
            return _mapper.Map<ProductDTO>(deletedProduct);
        }
        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var createdProduct = await _repository.Create(product);
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<ProductDTO> SelectById(int id)
        {
           var product = await _repository.SelectById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> SelectAll()
        {
            var products = await _repository.SelectAll();
           return _mapper.Map<IEnumerable<ProductDTO>>(products);

            
        }



    }
}
