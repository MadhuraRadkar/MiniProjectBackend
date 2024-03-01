using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categories.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCategory(int id)
        {
            int result = 0;
            var category = await db.Categories.Where(x => x.Cid == id).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categories.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await db.Categories.Where(x => x.Cid == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var c = await db.Categories.Where(x => x.Cid == category.Cid).FirstOrDefaultAsync();
            if (c != null)
            {

                c.Cid = category.Cid;
                c.Cname = category.Cname;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
