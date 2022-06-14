using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CatalogDbContext : DbContext
{
    private const string DbConnection = "*";

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConnection);
        }
    }
}
