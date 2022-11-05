using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface IProductRepository
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<ProductDTO> UpdateProduct(string userId, int productId, ProductDTO productDTO);
        Task<IEnumerable<ProductDTO>> GetAllProducts(string userId);
        Task<ProductDTO> GetProduct(int productId, string userId);

        Task<bool> DeleteProduct(int productId, string userId);

        Task<bool> ValidateProduct(string productName, double productPrice, string userId);
    }
}
