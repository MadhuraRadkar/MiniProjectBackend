using MiniProject.Model;
using MiniProject.Repositories;

namespace MiniProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;
        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddCategory(Category category)
        {
            return await repo.AddCategory(category);
        }

        public async Task<int> DeleteCategory(int id)
        {
            return await repo.DeleteCategory(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await repo.GetCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await repo.GetCategoryById(id);
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return await repo.UpdateCategory(category);
        }

    }
}
