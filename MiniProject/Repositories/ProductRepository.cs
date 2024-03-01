using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

       

        public async Task<int> AddProduct(Product product)
        {
            int result = 0;
           
            await db.Products.AddAsync(product);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProduct(int id)
        {
            int result = 0;
            var product = await db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                db.Products.Remove(product);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
       

        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            // return await db.Products.ToListAsync();
            var res = await (from p in db.Products
                             join c in db.Categories
                             on p.Cid equals c.Cid
                             select new Product
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Price = p.Price,
                                 ImageUrl = p.ImageUrl,
                                 Cid = p.Cid,
                                 Cname = c.Cname,
                             }).ToListAsync();
            return res;
        }

      

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;
            var p = await db.Products.Where(x=>x.Id== product.Id).FirstOrDefaultAsync();
            if(p != null)
            {
               p.Name = product.Name;
                p.Price = product.Price;
                p.ImageUrl = product.ImageUrl;
                p.Cid = product.Cid;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }


}
