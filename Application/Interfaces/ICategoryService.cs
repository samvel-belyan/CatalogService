using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task DeleteCategory(int id);
}
