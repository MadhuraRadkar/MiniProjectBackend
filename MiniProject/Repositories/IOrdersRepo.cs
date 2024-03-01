using MiniProject.Model;

namespace MiniProject.Repositories
{
    public interface IOrdersRepo
    {
        Task<int> BuyNow(Orders orders);
        Task<IEnumerable<Orders>> MyOrders(int Rid);
    }
}
