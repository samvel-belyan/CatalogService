using DAL.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public Task<Product> GetProduct(int id)
    {
        return _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Product> UpdateProduct(Product category)
    {
        _dbContext.Update(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }
}
