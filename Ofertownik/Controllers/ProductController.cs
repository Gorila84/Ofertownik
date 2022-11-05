using Microsoft.AspNetCore.Mvc;
using Models;
using Ofertownik.Repositories.IRpositories;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            if (await _productRepository.ValidateProduct(productDTO.ProductName, productDTO.PurchasePrice, productDTO.UserId))
            {
                BadRequest("Materiał o podanej nazwie i cenie już istnieje.");
            }

            var addProduct = await _productRepository.AddProduct(productDTO);
            return Ok(addProduct);


        }

        [HttpGet("getProduct/{id}")]
        public async Task<IActionResult> GetProductById(int id, string userId)
        {
            var product = await _productRepository.GetProduct(id, userId);
            return Ok(product);
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts(string userId)
        {
            var product = await _productRepository.GetAllProducts(userId);
            return Ok(product);
        }

        [HttpPut("editProduct/{id}")]
        public async Task<IActionResult> EditProduct(string userId, int id, ProductDTO productDTO)
        {
            var productForUpdate = await _productRepository.UpdateProduct(userId, id, productDTO);
            return Ok(productForUpdate);
        }

        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id, string userId)
        {
            var ProductForRemove = await _productRepository.DeleteProduct(id, userId);
            return Ok(ProductForRemove);
        }

    }
}
