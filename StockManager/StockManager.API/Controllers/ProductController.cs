using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManager.Application.DTOs;
using StockManager.Application.Interfaces;
using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infra.Data.Repositories;

namespace StockManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost]
        
        public async Task<ActionResult> CreateProduct(ProductDTO productDTO)
        {
            var productDTOCreated = await _productService.Create(productDTO);

            if (productDTOCreated == null)
            {
                return BadRequest("Error saving product.");
            }
            return Ok(new { message = "Product created!" });
        }


        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDTO productDTO)
        {
            var productDTOUpdated = await _productService.Update(productDTO);

            if (productDTOUpdated == null)
            {
                return BadRequest("Error updating product.");
            }
            return Ok(new { message = "Product updated!" });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var productDTODeleted = await _productService.Delete(id);

            if (productDTODeleted == null)
            {
                return BadRequest("Error deleting product.");
            }
            return Ok(new { message = "Product deleted!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelectProductById(int id)
        {
            var productDTO = await _productService.SelectById(id);
            if (productDTO == null)
            {
                return NotFound("Product not found");
            }

            return Ok(productDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelectAllProducts()
        {
            var productsDTO = await _productService.SelectAll();
            return Ok(productsDTO);
        }



    }
}
