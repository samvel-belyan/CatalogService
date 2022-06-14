using Domain.Models;

namespace DAL.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProduct(int id);
    Task<List<Product>> GetAllProducts();
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int id);
}
