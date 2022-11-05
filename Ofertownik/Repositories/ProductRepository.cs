using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Ofertownik.Data;
using Ofertownik.Data.Model;
using Ofertownik.Repositories.IRpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofertownik.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db,
                                  IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            Product productToAdd = _mapper.Map<ProductDTO, Product>(productDTO);
            productToAdd.CreateDate = DateTime.Now;
            productDTO.ProductName = productDTO.ProductName.ToLower();
            var Product = await _db.Products.AddAsync(productToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(Product.Entity);

        }

        public async Task<bool> DeleteProduct(int productId, string userId)
        {
            var productForDelete = await _db.Products.FirstOrDefaultAsync(x => x.Id == productId
                                                                                && x.UserId == userId);
            if (productForDelete != null)
            {
                _db.Products.Remove(productForDelete);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts(string userId)
        {
            IEnumerable<ProductDTO> products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(
                                                       await _db.Products.Where(x => x.UserId == userId).ToListAsync());
            return products;
        }

        public async Task<ProductDTO> GetProduct(int productId, string userId)
        {
            ProductDTO product = _mapper.Map<Product, ProductDTO>(
                                                       await _db.Products.FirstOrDefaultAsync(x => x.Id == productId
                                                                                                    && x.UserId == userId));
            return product;
        }

        public async Task<ProductDTO> UpdateProduct(string userId, int productId, ProductDTO productDTO)
        {
            try
            {
                if (productId == productDTO.Id)
                {
                    Product product = await _db.Products.FirstOrDefaultAsync(x => x.Id == productId && x.UserId == userId);
                    Product productForUpdate = _mapper.Map<ProductDTO, Product>(productDTO, product);
                    productForUpdate.UpdateDate = DateTime.Now;
                    productForUpdate.ProductName = productForUpdate.ProductName.ToLower();
                    var productUpdate = _db.Products.Update(productForUpdate);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Product, ProductDTO>(productUpdate.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;

            }




        }

        public async Task<bool> ValidateProduct(string productName, double productPrice, string userId)
        {
            var product = await _db.Products.Where(x => x.ProductName == productName
                                                      && x.PurchasePrice == productPrice
                                                      && x.UserId == userId).FirstOrDefaultAsync();

            if (product != null)
            {
                return true;
            }
            return false;
        }
    }
}
