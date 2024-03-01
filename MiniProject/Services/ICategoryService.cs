using MiniProject.Model;

namespace MiniProject.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int id);
    }
}
