using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts(int categoryId, int skip, int count);
    Task<Product> GetProduct(int id);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int productId);
}
