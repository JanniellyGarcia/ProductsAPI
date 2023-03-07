using ProductsAPI.Domain.DataTransferObject;
using ProductsAPI.Domain.Models;

namespace ProductsAPI.Service.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task UpdateProductAsync(ProductRequest product, int id);
        Task<ProductModel> CreateProductAsync(ProductRequest product);
        Task DeleteProductAsync(int id);

    }
}
