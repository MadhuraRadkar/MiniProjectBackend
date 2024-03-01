using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly ApplicationDbContext db;
        public OrdersRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Orders>> MyOrders(int Rid)
        {
            var result = await (from o in db.Orders
                                join p in db.Products
                                on o.Id equals p.Id
                                where o.Rid == Rid
                                select new Orders
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    ImageUrl = p.ImageUrl,
                                }).ToListAsync();
            return result;
        }

        public async Task<int> BuyNow(Orders orders)
        {
            int result = 0;
            orders.Quantity = 1;
            await db.Orders.AddAsync(orders);
            result = await db.SaveChangesAsync();
            return result;
        }
    }
}
