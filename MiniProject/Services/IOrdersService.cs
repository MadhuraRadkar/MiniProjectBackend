using MiniProject.Model;

namespace MiniProject.Services
{
    public interface IOrdersService
    {
        Task<int> BuyNow(Orders orders);
        Task<IEnumerable<Orders>> MyOrders(int Rid);
    }
}
