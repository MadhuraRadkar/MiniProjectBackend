using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext db;
        public CartRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddToCart(Cart cart)
        {
            int result = 0;
            cart.Qty = 1;
            await db.Carts.AddAsync(cart);
           // await db.carts.AddAsync(cart);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteFromCart(int id)
        {
            int res = 0;
            var result = await db.Carts.Where(x => x.CartId == id).FirstOrDefaultAsync();
            if (result != null)
            {
                db.Carts.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public async Task<IEnumerable<Cart>> GetCart(int Rid)
        {
            var result = await(from c in db.Carts
                               join p in db.Products
                               on c.Id equals p.Id
                               where c.Rid == Rid
                               select new Cart
                               {
                                   CartId = c.CartId,
                                   Id = p.Id,
                                   Name = p.Name,
                                   Price = p.Price,
                                   ImageUrl = p.ImageUrl,
                                   Rid=c.Rid
                               }).ToListAsync();
            return result;
        }
    }
}
