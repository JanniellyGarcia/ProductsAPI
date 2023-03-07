using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.DataTransferObject;
using ProductsAPI.Domain.Models;
using ProductsAPI.Infrastructure.Data;
using ProductsAPI.Service.Interfaces;

namespace ProductsAPI.Service
{
    public class ProductService : IProductRepository
    {
        private readonly ProductsDBContext _dBContext;
        public ProductService(ProductsDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var products = await _dBContext.Products.ToListAsync();
            return products;
        }
        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var searchedProduct = await _dBContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (searchedProduct is null)
                throw new Exception($"Product Not Found for ID: {id}. STATUS CODE: {StatusCodes.Status404NotFound}");

            return searchedProduct;
        }
        public async Task<ProductModel> CreateProductAsync(ProductRequest product)
        {
            var newProduct = new ProductModel()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            await _dBContext.Products.AddAsync(newProduct);
            await _dBContext.SaveChangesAsync();

            return newProduct;

        }
        public async Task UpdateProductAsync(ProductRequest product, int id)
        {

            var searchedProduct = await GetProductByIdAsync(id);
            searchedProduct.Name = product.Name;
            searchedProduct.Price = product.Price;
            searchedProduct.Description = product.Description;



            _dBContext.Products.Update(searchedProduct);
            await _dBContext.SaveChangesAsync();


        }


        public async Task DeleteProductAsync(int id)
        {
            var searchedProduct = await GetProductByIdAsync(id);

            _dBContext.Products.Remove(searchedProduct);
            await _dBContext.SaveChangesAsync();
        }





    }
}
